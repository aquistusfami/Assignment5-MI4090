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
    this.IpAddress = ip;
    this.IsConnected = true;
  }

  public void Disconnect()
  {
    this.IpAddress = string.Empty;
    this.IsConnected = false;
  }

  public override void DisplayDeviceInfo()
  {
    base.DisplayDeviceInfo();
    Console.WriteLine($"[-] Địa chỉ IP: {IpAddress}");
    Console.WriteLine($"[-] Trạng thái kết nối: {IsConnected}");
  }
}
