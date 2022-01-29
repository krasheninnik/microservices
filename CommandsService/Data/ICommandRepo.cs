using System.Collections.Generic;
using CommandsService.Models;

namespace CommandsService.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();

        // Platfroms related stuf
        IEnumerable<Platform> GetAllPlatforms();

        void CreatePlatform(Platform plat);

        bool PlatformExist(int platfromId);

        bool ExternalPlatformExist(int externalPlatformId);

        // Commands related stuf
        IEnumerable<Command> GetCommandsForPlatform(int platfromId);

        Command GetCommand(int platfromId, int commandId);

        void CreateCommand(int platformId, Command command);
    }
}