/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment5_MI4090;

public class Computer : Device, INetworkable 
{
  public int RamStorage { get; private set; }
  public string Processor { get; private set; }
  public bool HasGPU { get; private set; }
  public string? IpAddress { get; private set; }
  public bool IsConnected { get; private set; }

  public Computer(string id, string name, int usedYear, decimal price, DeviceStatus status, int ramStorage, string processor, bool hasGPU) : base(id, name, usedYear, price, status)
  {
    this.RamStorage = ramStorage;
    this.Processor = processor;
    this.HasGPU = hasGPU;
  }

  public override decimal CalculateAnnualMaintenanceCost()
  {
    int spentTime = DateTime.Now.Year - this.UsedYear;
    if (spentTime > 5 && this.HasGPU == true)
    {
      return 0.08m*Price;
    } 
    else if (spentTime > 5 && this.HasGPU == false) 
    {
      return 0.06m*Price;
    }
    else if (spentTime <= 5 && this.HasGPU == true)
    {
      return 0.07m*Price;
    } 
    else return 0.05m*Price;
  }

  public void Connect(string ip)
  {
    if (string.IsNullOrWhiteSpace(ip)) throw new ArgumentException("Địa chỉ IP không được rỗng", nameof(ip));
    if (IsConnected) throw new InvalidOperationException("Máy tính đang kết nối mạng!");
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
    $"-> Dung lượng RAM: {RamStorage:N0} GB" + Environment.NewLine +
    $"-> Chip xử lý: {Processor}" + Environment.NewLine + 
    $"-> GPU: {HasGPU}" + Environment.NewLine + 
    $"-> Tiền bảo dưỡng: {CalculateAnnualMaintenanceCost():N0} VND" + Environment.NewLine +
    $"[-] Địa chỉ IP: {IpAddress}" + Environment.NewLine +
    $"[-] Trạng thái kết nối: {IsConnected}";
  }
}
