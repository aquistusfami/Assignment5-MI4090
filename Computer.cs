/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment5_MI4090;

/// <summary>
/// Lớp Computer kế thừa Device và hợp đồng interface với INetworkable
/// </summary>
public class Computer : Device, INetworkable 
{
  public int RamStorage { get; private set; }
  public string Processor { get; private set; }
  public bool HasGPU { get; private set; }
  public string? IpAddress { get; private set; }
  public bool IsConnected { get; private set; }

  /// <summary>
  /// Constructor khởi tạo computer với các thông tin cần thiết 
  /// </summary>
  /// <param name="id">Mã máy tính</param>
  /// <param name="name">Tên máy tính</param>
  /// <param name="usedYear">Năm đưa vào sử dụng</param>
  /// <param name="price">Giá mua</param>
  /// <param name="status">Trạng thái</param>
  /// <param name="ramStorage">Dung lượng RAM</param>
  /// <param name="processor">CPU của máy</param>
  /// <param name="hasGPU">Có card rời không</param>
  /// <returns></returns>
  public Computer(string id, string name, int usedYear, decimal price, DeviceStatus status, int ramStorage, string processor, bool hasGPU) : base(id, name, usedYear, price, status)
  {
    this.RamStorage = ramStorage;
    this.Processor = processor;
    this.HasGPU = hasGPU;
  }

  /// <summary>
  /// Method tính chi phí bảo dưỡng của máy tính
  /// </summary>
  /// <returns>Chi phí bảo dưỡng (decimal)</returns>
  public override decimal CalculateAnnualMaintenanceCost()
  {
    int spentTime = DateTime.Now.Year - this.UsedYear;
    decimal rate = 0.05m;
    if (HasGPU) rate += 0.02m;
    if (spentTime > 5) rate += 0.01m;
    return rate * Price;
  }

  /// <summary>
  /// Method kết nối mạng xây dựng từ Interface
  /// </summary>
  /// <param name="ip">Địa chỉ IP</param>
  public void Connect(string ip)
  {
    if (string.IsNullOrWhiteSpace(ip)) throw new ArgumentException("Địa chỉ IP không được rỗng", nameof(ip));
    if (IsConnected) throw new InvalidOperationException("Máy tính đang kết nối mạng!");
    this.IpAddress = ip;
    this.IsConnected = true;
  }

  /// <summary>
  /// Method ngắt kết nối mạng
  /// </summary>
  public void Disconnect()
  {
    this.IpAddress = null;
    this.IsConnected = false;
  }
  
  /// <summary>
  /// Method override chuỗi thông tin của Device
  /// </summary>
  /// <returns>Chuỗi thông tin của máy tính</returns>
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
