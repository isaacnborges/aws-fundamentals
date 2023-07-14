# aws-fundamentals
Cloud Fundamentals: AWS Services for C# Developers - Made by [Nick Chapsas](https://www.youtube.com/@nickchapsas)

### Summary

- [AWS SQS](https://aws.amazon.com/sqs/) -> Simple Queue Service
- [AWS SNS](https://aws.amazon.com/sns/) -> Simple Notification Service
- [AWS DynamoDB](https://aws.amazon.com/dynamodb/)
- [AWS S3](https://aws.amazon.com/s3/) -> Simple Storage Service
- [AWS Secrets Manager](https://aws.amazon.com/secrets-manager/)
- [AWS Lambda](https://aws.amazon.com/lambda/)

#### Customers Api - message request example
``` json
{
    "id": "67c338ae-9556-4aea-b800-02b69f8a7592",
    "fullName": "Isaac Borges",
    "email": "email@email.com",
    "gitHubUsername": "isaacnborges",
    "dateOfBirth": "1993-01-01"
}
```
#### SQS Access Policy permissions
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

#### SNS Subcription Filter

- message attributes
``` json
{
  "MessageType": [
    "CustomerCreated"
  ]
}
```

- message body
``` json
{
  "FullName": [
    "Isaac Nunes Borges"
  ]
}
```

#### Secret Manager Example
```
ApiKey
Development_Weather.Api_OpenWeatherMapApi__ApiKey
```

### AWS Lambda 

- invoke example
```
aws lambda invoke --function-name SimpleLambda --cli-binary-format raw-in-base64-out --payload '{ "Hello": "From Console" }' response.json
```

```
Get-Content \.response.json
```

#### [.NET Core CLI]((https://docs.aws.amazon.com/lambda/latest/dg/csharp-package-cli.html))
```
dotnet tool install -g Amazon.Lambda.Tools
```

```
dotnet lambda invoke-function SimpleLambda --payload '{ "Hello": "From Console" }'
```

- templates
```
dotnet new -i Amazon.Lambda.Templates
```

#### Lambda policy permissions to access DynamoDB
```json
{
	"Sid": "APIAccessForDynamoDBStreams",
	"Effect": "Allow",
	"Action": [
		"dynamodb:GetRecords",
		"dynamodb:GetShardIterator",
		"dynamodb:DescribeStream",
		"dynamodb:ListStreams"
	],
	"Resource": "arn:aws:dynamodb:[region]:[codeNumber]:table/customers/stream/*"
}
```

#### Deploy and invoke functions
- ```dotnet lambda deploy-function SimpleLambda```
- ```dotnet lambda invoke-function SimpleLambda```
- ```dotnet lambda invoke-function SimpleLambda --payload '{ "From DotNet Cli" }'```

#### Deploy serverless
- ```dotnet lambda deploy-serverless SimpleHttpLambda```
- ```dotnet lambda delete-serverless SimpleHttpLambda```
- ```dotnet lambda deploy-function SimpleHttpLambda```

### [AWS-Lambda-Dotnet](https://github.com/aws/aws-lambda-dotnet/tree/master/Tools/LambdaTestTool)

- ```dotnet tool install -g Amazon.Lambda.TestTool-6.0```
- ```dotnet lambda-test-tool-6.0```

#### Debug Lambda
- Attach to process -> dotnet lambda-test-tool-6.0

#### Deploy functions
- ```dotnet lambda deploy-function SimpleLambda```
- ```dotnet lambda deploy-function SimpleHttpLambda```
- ```dotnet lambda deploy-function SimpleSqsLambda```
- ```dotnet lambda deploy-function SimpleSnsLambda```
- ```dotnet lambda deploy-function SimpleDynamoDbLambda```
- ```dotnet lambda deploy-function SimpleS3Lambda```
- ```dotnet lambda deploy-function SimpleApiLambda```