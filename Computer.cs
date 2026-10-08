/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment5_MI4090;

public class Computer : Device 
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
    int spentTime = 2026 - this.UsedYear;
    if (spentTime >= 5 && this.HasGPU == true)
    {
      return 0.08m*Price;
    } 
    else if (spentTime >= 5 && this.HasGPU == false) 
    {
      return 0.06m*Price;
    }
    else if (spentTime < 5 && this.HasGPU == true)
    {
      return 0.07m*Price;
    } 
    else return 0.05m*Price;
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
    Console.WriteLine($"-> Dung lượng RAM: {RamStorage:N0} GB");
    Console.WriteLine($"-> Chip xử lý: {Processor}");
    Console.WriteLine($"-> GPU: {HasGPU}");
    Console.WriteLine($"-> Tiền bảo dưỡng: {CalculateAnnualMaintenanceCost():N0} VND");
    Console.WriteLine($"[-] Địa chỉ IP: {IpAddress}");
    Console.WriteLine($"[-] Trạng thái kết nối: {IsConnected}");
  }
}
