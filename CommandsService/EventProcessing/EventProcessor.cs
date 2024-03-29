using System;
using System.Text.Json;
using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using CommandsService.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CommandsService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }

        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.PlatformPublished:
                    AddPlatform(message);
                    break;

                case EventType.Undetermined:
                    break;
            }
        }

        private EventType DetermineEvent(string notificatoinMessage)
        {
            Console.WriteLine("--> Determing Event");

            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificatoinMessage);

            switch (eventType.Event)
            {
                case "Platform_Published":
                    Console.WriteLine("--> PlatformPublished Event detected");
                    return EventType.PlatformPublished;
                default:
                    Console.WriteLine("--> Undetermined Event detected");
                    return EventType.Undetermined;
            };
        }

        private void AddPlatform(string platformPublishedMessage)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<ICommandRepo>();

                var platformPublishedDto = JsonSerializer.Deserialize<PlatformPublishedDto>(platformPublishedMessage);

                try
                {
                    var plat = _mapper.Map<Platform>(platformPublishedDto);

                    if (!repo.ExternalPlatformExist(plat.ExternalID))
                    {
                        repo.CreatePlatform(plat);
                        repo.SaveChanges();
                        Console.WriteLine($"--> Added platform with external id {plat.ExternalID}");
                    }
                    else
                    {
                        Console.WriteLine($"--> Platform already exist...");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not add Platfromto db {ex.Message}");
                }
            }
        }
    }

    enum EventType
    {
        PlatformPublished,
        Undetermined
    }
}