namespace Ebish.GrpcConsole.Contract;

using System.Runtime.Serialization;

[DataContract]
public class HelloRequestData
{
    [DataMember(Order = 1)] 
    public string Name { get; set; } = string.Empty;
}