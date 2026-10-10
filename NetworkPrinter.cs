/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment5_MI4090;

/// <summary>
/// Lớp máy in có mạng kế thừa printer và interface 
/// </summary>
public class NetworkPrinter : Printer, INetworkable
{
  public string? IpAddress { get; private set; }
  public bool IsConnected { get; private set; }

  /// <summary>
  /// Constructor khởi tạo thông tin cần thiết cho máy in có mạng
  /// </summary>
  /// <param name="id">Mã thiết bị</param>
  /// <param name="name">Tên thiết bị</param>
  /// <param name="usedYear">Năm đưa vào sử dụng</param>
  /// <param name="price">Giá mua</param>
  /// <param name="status">Trạng thái</param>
  /// <param name="type">Loại máy in</param>
  /// <param name="printedPage">Số trang đã in</param>
  /// <param name="isColor">Có in màu không</param>
  public NetworkPrinter(string id, string name, int usedYear, decimal price, DeviceStatus status, PrinterType type, int printedPage, bool isColor)
  : base(id, name, usedYear, price, status, type, printedPage, isColor)
  {
  }

  /// <summary>
  /// Method kết nối mạng xây dựng từ interface
  /// </summary>
  /// <param name="ip"></param>
  public void Connect(string ip)
  {
    if (string.IsNullOrWhiteSpace(ip)) throw new ArgumentException("Địa chỉ IP không được rỗng", nameof(ip));
    if (IsConnected) throw new InvalidOperationException("Máy in đang kết nối mạng!");
    this.IpAddress = ip;
    this.IsConnected = true;
  }
  
  /// <summary>
  /// Ngắt kết nối
  /// </summary>
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
