using System;
using RabbitMQ.Client;
using System.Text;

namespace Send
{
    //Producer: sending messages to RabbitMQ
    class Send
    {
        public static void Main(string[] args)
        {
            // Connect to a RabbitMQ node on the local machine
            // If you wanted to connect to a node on a different machine, we'd simply sepcify its hostname or IP address.
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //Declare a queue
                    channel.QueueDeclare(queue: "hello", 
                                        durable: false, 
                                        exclusive: false, 
                                        autoDelete: false, 
                                        arguments: null);

                    Console.WriteLine(" Input your message, then press [enter]");                    
                    string message = Console.ReadLine();

                    //string message = "Hello World!";
                    var body = Encoding.UTF8.GetBytes(message);

                    //Publish message to the queue
                    channel.BasicPublish(exchange: "",
                                        routingKey: "hello",
                                        basicProperties: null,
                                        body: body);
                    
                    Console.WriteLine(" [x] Sent {0}", message);                    
                }
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
