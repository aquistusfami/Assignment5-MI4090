/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment5_MI4090;

public class NetworkPrinter : Printer, INetworkable
{
  public string? IpAddress { get; private set; }
  public bool IsConnected { get; private set; }

  public NetworkPrinter(string id, string name, int usedYear, decimal price, DeviceStatus status, PrinterType type, int printedPage, bool isColor)
  : base(id, name, usedYear, price, status, type, printedPage, isColor)
  {
  }

  public void Connect(string ip)
  {
    if (string.IsNullOrWhiteSpace(ip)) throw new ArgumentException("Địa chỉ IP không được rỗng", nameof(ip));
    if (IsConnected) throw new InvalidOperationException("Máy in đang kết nối mạng!");
    this.IpAddress = ip;
    this.IsConnected = true;
  }

  public void Disconnect()
  {
    this.IpAddress = null;
    this.IsConnected = false;
  }

  public override string ToString()
  {
    return base.ToString() + Environment.NewLine + 
    $"[-] Địa chỉ IP: {IpAddress}" + Environment.NewLine +
    $"[-] Trạng thái kết nối: {IsConnected}";
  }
}
