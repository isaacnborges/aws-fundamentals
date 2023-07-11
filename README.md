# aws-fundamentals
Cloud Fundamentals: AWS Services for C# Developers


message request example
{
	"id": "67c338ae-9556-4aea-b800-02b69f8a7592",
    "fullName": "fafa",
    "email": "fdafdf@gmail.com",
    "gitHubUsername": "fafafds",
    "dateOfBirth": "1993-10-20"
}
------------------------------------------------------------------------------------
sqs access policy permissions
    {
      "Effect": "Allow",
      "Principal": {
        "Service": "sns.amazonaws.com"
      },
      "Action": "sqs:SendMessage",
      "Resource": "arn:aws:sqs:sa-east-1:641904260836:customers",
      "Condition": {
        "ArnEquals": {
          "aws:SourceArn": "arn:aws:sns:sa-east-1:641904260836:customers"
        }
      }
    }
------------------------------------------------------------------------------------
sns subcription filter

message attributes
{
  "MessageType": [
    "CustomerCreated"
  ]
}

message body
{
  "FullName": [
    "Isaac Nunes Borges"
  ]
}