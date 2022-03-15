namespace Ebish.GrpcConsole.Contract;

using System.ServiceModel;

[ServiceContract]
public interface IHelloService
{
    Task<HelloReplyData> SayHelloAsync(HelloRequestData requestData);
}
