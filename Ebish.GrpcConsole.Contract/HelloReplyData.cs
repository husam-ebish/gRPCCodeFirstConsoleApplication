namespace Ebish.GrpcConsole.Contract;

using System.Runtime.Serialization;

[DataContract]
public class HelloReplyData
{
    [DataMember(Order = 1)]
    public string HelloMessage { get; set; } = string.Empty;
}
