/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
namespace Assignment5_MI4090;

public interface INetworkable
{
  public string? IpAddress { get; }
  public bool IsConnected { get; }
  
  public void Connect(string ipAddress);
  public void Disconnect();
}
