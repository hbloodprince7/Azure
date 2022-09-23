using Azure;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System;
using System.Threading.Tasks;

namespace QueuesQuickstartV12
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Azure Queue Storage client library v12 - .NET quickstart sample\n");
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=manvith;AccountKey=aOvwTMdqAk3AOwxMjoV88foH1Q0iKftkOliTCE7djokGvCNMqvlFmwq1lGHYQiFnX9DEpm2cDKUB+AStoENTFQ==;EndpointSuffix=core.windows.net";
            // Create a unique name for the queue
            string queueName = "quickstartqueues-" + Guid.NewGuid().ToString();

            Console.WriteLine($"Creating queue: {queueName}");

            // Instantiate a QueueClient which will be
            // used to create and manipulate the queue
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            // Create the queue
            await queueClient.CreateAsync();
            Console.WriteLine("\nAdding messages to the queue...");

            // Send several messages to the queue
            await queueClient.SendMessageAsync("First message");
            await queueClient.SendMessageAsync("Second message");

            // Save the receipt so we can update this message later
            SendReceipt receipt = await queueClient.SendMessageAsync("Third message");
            Console.WriteLine("\nPeek at the messages in the queue...");

            // Peek at messages in the queue

            Console.WriteLine("\nUpdating the third message in the queue...");

            // Update a message using the saved receipt from sending the message
            await queueClient.UpdateMessageAsync(receipt.MessageId, receipt.PopReceipt, "Third message has been updated");


        }
    }
}