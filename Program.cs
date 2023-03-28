using System.Threading.Tasks;
using Grpc.Net.Client;
using gRPCClient;

class Program
{
    public static async Task Main(string[] args)
    {
        // The port number must match the port of the gRPC server.
        using var channel = GrpcChannel.ForAddress("https://localhost:5001/");
        var client = new Greeter.GreeterClient(channel);
        var reply = await client.SayHelloAsync(
                        new HelloRequest { Name = "Eric" });
        Console.WriteLine("Greeting: " + reply.Message);
        reply = await client.SayHelloAsync(
                        new HelloRequest { Name = "Antoine" });
        Console.WriteLine("Greeting: " + reply.Message);
    }
}