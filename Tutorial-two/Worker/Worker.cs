using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading;

namespace Worker
{
    //A worker process running in the backgound will pop the tasks and eventually execute the job
    //By default, RabbitMQ use Round-Robin dispatching to distribute messages to the consumers.
    class Worker
    {
        public static void Main(string[] args)
        {
            //Connect to a RabbitMQ node on the lcoal machine
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //Declare a queue
                    channel.QueueDeclare(queue: "task_queue",
                                        // durable: false,
                                        durable: true,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                    //Fair Dispatch, use this setting to tell RabbitMQ not to give more than one messages to a worker at a time
                    channel.BasicQos(prefetchSize:0, prefetchCount:1, global: false);
                    Console.WriteLine(" [*] Waiting for messages.");

                    //Tell the server to deliver worker the messages from the queue
                    //Provide a callback since messages are pushed asynchronously                    
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (modal, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(" [x] Received {0}", message);

                        int dots = message.Split('.').Length - 1;
                        Thread.Sleep(dots * 1000);

                        Console.WriteLine(" [x] Done");

                        //Manual message acknowledgement
                        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                        Console.WriteLine(" [x] Ack");
                    };

                    channel.BasicConsume(queue: "task_queue",
                                        //autoAck: true,
                                        autoAck: false,
                                        consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        }
    }
}
