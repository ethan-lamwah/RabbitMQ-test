## RabbitMQ Tutorials
1. "Hello World!"
2. Work queues
    * Distributing tasks among workers(the [competing consumers pattern][3])
    * Setting `prefetch = 1` tells RabbitMQ not to dispatch more than one new message to a worker at a time
    > ![Work queues](https://www.rabbitmq.com/img/tutorials/prefetch-count.png)
3. Publish/Subscribe
    * Sending messages to many consumers at a time
    * Introducing ***exchange*** in this model. On one side, it receives messages from producers and the other side it pushes them to  subscribed queues.
    * The relationship between *exchange* and queues is called ***binding***
    * use `fanout` exchange type
    > ![Publish/Subscribe messaging modal](https://www.rabbitmq.com/img/tutorials/python-three-overall.png)
4. Routing
    * use `direct` exchange type
    * Specify the *binding/routing key*
    * The routing algorithm behind a *direct* exchange is simple - a message goes to the queues whose `binding key` exactly matches the `routing key` of the message.
    
    > ![messaging modal using direct exhcange type and routing](https://www.rabbitmq.com/img/tutorials/python-four.png)

5. Topics
    * use `topic` exchange type
    * its `routing key` must be a list of words delimited by *dots*
    * two important special cases for
    binding keys:
        * `*`(start) can substitude for exactly one word
        * `#`(hash) can substitude for zero or more words
    > ![messaging modal using topic exchange type](https://www.rabbitmq.com/img/tutorials/python-five.png)

6. Remote procedure call (RPC)
    * build an RPC system: a client and a scalable RPC server
    *





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

### Listing exchanges
use `rabbitmaqctl list_exchanges` to list the exchanges on the server

### Listing bindings
use `rabbitmqctl list_bindings` to list existing bindings

### How to solve "TCP connection succeeded but Erlang distribution failed" ?
>Make sure the same `.erlang.cookie` file is being used in `C:\Windows\System32\config\systemprofile` and `C:\Users\{username}`




<!-- URL HERE -->
[1]: http://localhost:15672/
[2]: https://www.rabbitmq.com/tutorials/tutorial-two-dotnet.html
[3]: https://www.enterpriseintegrationpatterns.com/patterns/messaging/CompetingConsumers.html
