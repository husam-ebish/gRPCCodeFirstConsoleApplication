namespace Ebish.GrpcConsole.Endpoint;

using Contract;

public class HelloService : IHelloService
{
    public Task<HelloReplyData> SayHelloAsync(HelloRequestData requestData)
    {
        return Task.FromResult(
            new HelloReplyData
            {
                HelloMessage = $"Hello {requestData.Name} :)"
            });
    }
}
