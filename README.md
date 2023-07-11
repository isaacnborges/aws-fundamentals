# aws-fundamentals
Cloud Fundamentals: AWS Services for C# Developers

### Customers Api - message request example
``` json
{
    "id": "67c338ae-9556-4aea-b800-02b69f8a7592",
    "fullName": "Isaac Borges",
    "email": "email@email.com",
    "gitHubUsername": "isaacnborges",
    "dateOfBirth": "1993-01-01"
}
```
### SQS Access Policy permissions
``` json
    {
      "Effect": "Allow",
      "Principal": {
        "Service": "sns.amazonaws.com"
      },
      "Action": "sqs:SendMessage",
      "Resource": "arn:aws:sqs:queue-resource",
      "Condition": {
        "ArnEquals": {
          "aws:SourceArn": "arn:aws:sns:topic-source-arn"
        }
      }
    }
```    

### SNS Subcription Filter

message attributes
``` json
{
  "MessageType": [
    "CustomerCreated"
  ]
}
```

message body
``` json
{
  "FullName": [
    "Isaac Nunes Borges"
  ]
}
```