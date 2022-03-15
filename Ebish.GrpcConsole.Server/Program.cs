namespace Ebish.GrpcConsole.Server;

using Endpoint;
using Grpc.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProtoBuf.Grpc.Server;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("gRPC Server\n");

        const int Port = 30051;

        Server server = new Server
        {
            Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
        };

        server.Services.AddCodeFirst(new HelloService());

        IHost host = CreateHostBuilder(args).Build();
        _ = host.Services.GetRequiredService<Program>();

        server.Start();

        Console.WriteLine("gRPC server listening on port " + Port);
        Console.WriteLine("Press any key to stop the server...");
        Console.Read();

        server.ShutdownAsync().Wait();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services
                    .AddTransient<Program>();
            });

        return builder;
    }
}
