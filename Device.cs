/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment5_MI4090;

public enum DeviceStatus 
{
  Active,
  UnderMaintenance,
  Retired
}

public abstract class Device 
{
  public string DeviceId { get; private set; }
  public string DeviceName { get; private set; }
  public int UsedYear { get; private set; }
  public decimal Price { get; private set; }
  public DeviceStatus Status { get; private set; }

  public Device(string id, string name, int usedYear, decimal price, DeviceStatus status)
  {
    if(string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Mã thiết bị không được trống.", nameof(id));
    if(usedYear > 2026) throw new ArgumentOutOfRangeException(nameof(usedYear),"Năm đưa vào sử dụng không lớn hơn năm hiện tại (2026).");
    if(price <= 0) throw new ArgumentOutOfRangeException(nameof(price), "Giá mua không được <= 0.");
    this.DeviceId = id;
    this.DeviceName = name;
    this.UsedYear = usedYear;
    this.Price = price;
    this.Status = status;
  }

  public abstract decimal CalculateAnnualMaintenanceCost();
  public virtual void DisplayDeviceInfo()
  {
    Console.WriteLine($"(+) Mã thiết bị: {DeviceId}");
    Console.WriteLine($"(+) Tên thiết bị: {DeviceName}");
    Console.WriteLine($"(+) Năm đưa vào sử dụng: {UsedYear}");
    Console.WriteLine($"(+) Giá mua: {Price:N0} VND");
    Console.WriteLine($"(+) Trạng thái hoạt động: {Status}");
  }
}
