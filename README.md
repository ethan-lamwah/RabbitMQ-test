## RabbitMQ Tutorials
1. "Hello World!"
2. Work queues
    * Distributing tasks among workers(the [competing consumers pattern][3])



You may visit [RabbitMQ][2] for more tutorials

## RabbitMQ Command Prompt Note

### Erlang Cookie
C:\Users\Ethan.erlang.cookie

### Log
C:\Users\Ethan\AppData\Roaming\RabbitMQ\log

### Start the RabbitMQ Service
`rabbitmq-service start`

### Stop the RabbitMQ Service
`rabbitmq-service stop`

### Checking Node Status
`rabbitmqctl.bat status`

### Enable Management UI
`rabbitmq-plugins enable rabbitmq_management`

Portal: [RabbitMQ Management UI][1]

### To check what interface and port is used by a running node
`rabbitmq-diagnostics -s listeners`



<!-- URL HERE -->
[1]: http://localhost:15672/
[2]: https://www.rabbitmq.com/tutorials/tutorial-two-dotnet.html
[3]: https://www.enterpriseintegrationpatterns.com/patterns/messaging/CompetingConsumers.html
