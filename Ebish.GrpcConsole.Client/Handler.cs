using Ebish.GrpcConsole.Contract;

namespace Ebish.GrpcConsole.Client;

public class Handler
{
    private readonly IHelloService helloService;

    public Handler(IHelloService helloService)
    {
        this.helloService = helloService;
    }

    public async Task<HelloReplyData> GreetAsync(string name)
    {
        try
        {
            return await this.helloService.SayHelloAsync(new HelloRequestData { Name = name });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
}