# newme-purchase
#### Migration:
- To create a new migration run the command below in the terminal in the path "src/Newme.Purchase.Infrastructure".

1. dotnet ef --startup-project ../Newme.Purchase.API/  migrations add initial -c PurchaseCommandContext -v
2. dotnet ef --startup-project ../Newme.Purchase.API/  database update

#### Rabbitmq
- To enable rabbitmq run the command below on terminal.

1. rabbitmq-server

- Queues and TrackingsExchanges must be previously created to run the project.

#### Swagger
- https://localhost:7164/swagger/index.html

