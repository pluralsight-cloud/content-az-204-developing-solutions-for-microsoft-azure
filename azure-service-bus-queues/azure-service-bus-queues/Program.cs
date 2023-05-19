namespace Azure_Service_Bus_Lab
{
    using Microsoft.Azure.ServiceBus;
    using System;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        // Connection String for the namespace can be obtained from the Azure portal under the 
        // 'Shared Access policies' section.
        const string ServiceBusConnectionString = "_______________";
        const string QueueName = "myqueue";
        static IQueueClient queueClient;

        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            queueClient = new QueueClient(ServiceBusConnectionString, QueueName);

            // Send Messages
            Console.WriteLine("Sending 10 messages.");
            await SendMessagesAsync(10);
            Console.WriteLine("Sent 10 messages.");
            Console.WriteLine("======================================================");
            Console.WriteLine("Press any key to begin receiving messages.");
            Console.WriteLine("======================================================");
            Console.ReadKey();

            // Register QueueClient's MessageHandler and receive messages in a loop
            Console.WriteLine("Receiving messages.");
            RegisterOnMessageHandlerAndReceiveMessages();
            Console.WriteLine("Received messages.");
            Console.WriteLine("======================================================");
            Console.WriteLine("Press any key to exit application.");
            Console.WriteLine("======================================================");
            Console.ReadKey();

            await queueClient.CloseAsync();
        }



        static async Task SendMessagesAsync(int numberOfMessagesToSend)
        {
            try
            {
                for (var i = 0; i < numberOfMessagesToSend; i++)
                {
                    // Create a new message to send to the queue
                    string messageBody = $"Message {i}";
                    var message = new Message(Encoding.UTF8.GetBytes(messageBody));

                    // Write the body of the message to the console
                    Console.WriteLine($"     Sending message: {messageBody}");

                    // Send the message to the queue
                    /*
                        CompleteAsync
                        SendAsync
                        ScheduleMessageAsync
                     */
                    await queueClient.__________________(message);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"     {DateTime.Now} :: Exception: {exception.Message}");
            }
        }



        static void RegisterOnMessageHandlerAndReceiveMessages()
        {
            // Configure the MessageHandler Options in terms of exception handling, number of concurrent messages to deliver etc.
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                // Maximum number of Concurrent calls to the callback `ProcessMessagesAsync`, set to 1 for simplicity.
                // Set it according to how many messages the application wants to process in parallel.
                MaxConcurrentCalls = 1,

                // Indicates whether MessagePump should automatically complete the messages after returning from User Callback.
                // False below indicates the Complete will be handled by the User Callback as in `ProcessMessagesAsync` below.
                AutoComplete = false
            };

            // Register the function that will process messages
            /*
                RegisterMessageHandler
                RegisterSessionHandler
                RegisterPlugin
             */
            queueClient.__________________(ProcessMessagesAsync, messageHandlerOptions);
        }

        static async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            // Process the message
            Console.WriteLine($"     Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");

            // Complete the message so that it is not received again.
            // This can be done only if the queueClient is created in ReceiveMode.PeekLock mode (which is default).
            // You may chose to not call CompleteAsync() or AbandonAsync() etc.
            /*
                CompleteAsync
                AbandonAsync
             */

            await queueClient.__________________(message.SystemProperties.LockToken);
        }

        // Use this Handler to look at the exceptions received on the MessagePump
        static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            Console.WriteLine($"     Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");
            return Task.CompletedTask;
        }
    }
}