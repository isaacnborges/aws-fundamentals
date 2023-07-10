using Amazon.SQS;
using Amazon.SQS.Model;
using SqsPublisher;
using System.Text.Json;

var sqsClient = new AmazonSQSClient();

var customer = new CustomerCreated
{
    Id = Guid.NewGuid(),
    Email = "isaacnborges@gmail.com",
    FullName = "Isaac Nunes Borges",
    DateOfBirth = new DateTime(1993, 10, 20),
    GitHubUsername = "isaacnborges"
};

var queueUrlResponse = await sqsClient.GetQueueUrlAsync("customers");

var sendMessageRequest = new SendMessageRequest
{
    QueueUrl = queueUrlResponse.QueueUrl,
    MessageBody = JsonSerializer.Serialize(customer),
    MessageAttributes = new Dictionary<string, MessageAttributeValue>
    {
        {
            "MessageType", new MessageAttributeValue
            {
                DataType = "String",
                StringValue = nameof(CustomerCreated)
            }
        }
    },
    
};

var response = sqsClient.SendMessageAsync(sendMessageRequest);

Console.WriteLine(response);