namespace Ebish.GrpcConsole.Client;

using Contract;
using Grpc.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProtoBuf.Grpc.Client;

public class Program
{
    private readonly Handler handler;

    public Program(Handler handler)
    {
        this.handler = handler;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("gRPC Client\n");

        IHost host = CreateHostBuilder(args).Build();
        _ = host.Services.GetRequiredService<Program>().Run();

        Console.Read();
    }

    public async Task Run()
    {
        try
        {
            HelloReplyData replay = await handler.GreetAsync("Husam");
            Console.WriteLine(replay.HelloMessage);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddTransient(
                    servicesProvider =>
                    {
                        Channel channel = new Channel("127.0.0.1:30051", ChannelCredentials.Insecure);
                        return channel;
                    });

                services.AddScoped<IHelloService>(services =>
                {
                    var grpcChannel = services.GetRequiredService<Channel>();
                    return grpcChannel.CreateGrpcService<IHelloService>();
                });

                services
                    .AddTransient<Handler>()
                    .AddTransient<Program>();
            });

        return builder;
    }
}
