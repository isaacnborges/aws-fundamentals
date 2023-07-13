using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

var secretsManagerClient = new AmazonSecretsManagerClient();

var listSecretVersionsRequest = new ListSecretVersionIdsRequest
{
    SecretId = "ApiKey",
    IncludeDeprecated = true
};

var versionResponse = await secretsManagerClient.ListSecretVersionIdsAsync(listSecretVersionsRequest);
foreach (var version in versionResponse.Versions)
{
    Console.WriteLine(version.VersionId);
}

var request = new GetSecretValueRequest
{
    SecretId = "ApiKey",
    VersionId = "26366a5e-702a-4b6f-92e2-1fa7255635cc"
};

var response = await secretsManagerClient.GetSecretValueAsync(request);

Console.WriteLine(response.SecretString);

/*
var describeSecretRequest = new DescribeSecretRequest
{
    SecretId = "ApiKey"
};

var describeResponse = await secretsManagerClient.DescribeSecretAsync(describeSecretRequest);

Console.WriteLine();
*/
