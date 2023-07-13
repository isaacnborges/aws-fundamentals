using Amazon.S3;
using Amazon.S3.Model;
using System.Text;

var s3Client = new AmazonS3Client();

#region upload
await using var inputStream = new FileStream("./image.jpg", FileMode.Open, FileAccess.Read);

var putObjectRequest = new PutObjectRequest
{
    BucketName = "isaacawscourse",
    Key = "images/image.jpg",
    ContentType = "images/jpeg",
    InputStream = inputStream
};

await s3Client.PutObjectAsync(putObjectRequest);

await using var inputStream2 = new FileStream("./movies.csv", FileMode.Open, FileAccess.Read);

var putObjectRequest2 = new PutObjectRequest
{
    BucketName = "isaacawscourse",
    Key = "files/movies.csv",
    ContentType = "text/csv",
    InputStream = inputStream2
};

await s3Client.PutObjectAsync(putObjectRequest2);
#endregion

#region download
var getObjectRequest = new GetObjectRequest
{
    BucketName = "isaacawscourse",
    Key = "files/movies.csv",
};

var response = await s3Client.GetObjectAsync(getObjectRequest);

using var memoryStream = new MemoryStream();
response.ResponseStream.CopyTo(memoryStream);

var text = Encoding.Default.GetString(memoryStream.ToArray());
Console.WriteLine(text);
#endregion