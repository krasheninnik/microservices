Нужно собрать docker образы и запушить на docker hub.
Затем подменить в k8s/ commands-depl.yaml и platforms-depl.yaml докер образы
Для того, чтобы запустить deployments:

kubectl apply -f platforms-depl.yaml  
kubectl apply -f commands-depl.yaml  
kubectl apply -f mssql-plat-depl.yaml  
kubectl apply -f rabbitmq-depl.yaml  
(and others..)
