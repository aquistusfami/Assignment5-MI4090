/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment5_MI4090;

/// <summary>
/// Lớp LabRoom đại diện cho phòng nghiên cứu
/// </summary>
public class LabRoom 
{
  public string LabRoomId { get; private set; }
  public string LabRoomName { get; private set; }
  public int Space { get; private set; }
  private readonly List<Device> devices = new List<Device>();

  /// <summary>
  /// Constructor khởi tạo thông tin cần thiết của LabRoom
  /// </summary>
  /// <param name="id">Mã phòng</param>
  /// <param name="name">Tên phòng</param>
  /// <param name="space">Sức chứa</param>
  public LabRoom(string id, string name, int space){
    if(string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Mã phòng không được trống.", nameof(id));
    if(space < 0) throw new ArgumentOutOfRangeException(nameof(space), "Sức chưa không được âm.");
    this.LabRoomId = id;
    this.LabRoomName = name;
    this.Space = space;
  }

  /// <summary>
  /// Thêm thiết bị 
  /// </summary>
  /// <param name="device">Thiết bị</param>
  public void AddDevice(Device device)
  {
    if (device == null) throw new ArgumentNullException(nameof(device), "Thiết bị không được rỗng.");
    if (devices.Count >= Space) throw new InvalidOperationException("Phòng đã đạt sức chứa tối đa.");
    if (FindDevice(device.DeviceId) != null) throw new InvalidOperationException($"Thiết bị với ID {device.DeviceId} đã tồn tại trong danh sách.");
    devices.Add(device);
  }

  /// <summary>
  /// Tìm thiết bị
  /// </summary>
  /// <param name="id">Mã thiết bị</param>
  /// <returns>Thiết bị tìm thấy hoặc null</returns>
  public Device? FindDevice(string id)
  {
    if (string.IsNullOrWhiteSpace(id)) return null;
    foreach (var dev in devices)
    {
      // khong phan biet hoa, thuong
      if (dev.DeviceId.Equals(id, StringComparison.OrdinalIgnoreCase))
      {
        return dev;
      }
    }
    return null;
  }

  /// <summary>
  /// Xóa thiết bị
  /// </summary>
  /// <param name="id">Mã thiết bị</param>
  /// <returns>True nếu xóa thành công, false nếu không có thiết bị hoặc null</returns>
  public bool RemoveDevice(string id)
  {
    if (string.IsNullOrWhiteSpace(id)) return false;
    Device? devi = FindDevice(id);
    return devi != null && devices.Remove(devi);
  }

  /// <summary>
  /// Tính tổng chi phí bảo dưỡng của phòng
  /// </summary>
  /// <returns>Chi phí bảo dưỡng các thiết bị của phòng</returns>
  public decimal CalculateAnnualMaintenanceCost()
  {
    decimal totalMCost = 0.0m;
    foreach (var dev in devices)
    {
      totalMCost += dev.CalculateAnnualMaintenanceCost();
    }
    return totalMCost;
  }

  /// <summary>
  /// Lấy danh sách các thiết bị cần bảo trì
  /// </summary>
  /// <returns>Danh sách thiết bị cần bảo trì</returns>
  public List<Device> GetDevicesRequiringMaintenance()
  {
    List<Device> rmdevices = new List<Device>();
    foreach (var dev in devices)
    {
      if (dev.Status == DeviceStatus.UnderMaintenance || (DateTime.Now.Year - dev.UsedYear > 5))
      {
        rmdevices.Add(dev);
      }
    }
    return rmdevices;
  }

  public void DisplayInfo()
  {
    Console.WriteLine($"<!> Các thiết bị của Lab {LabRoomName} - id: {LabRoomId} là:");
    Console.WriteLine($"------------------------------------------------------------");
    foreach (var dev in devices)
    {
      Console.WriteLine(dev);
      Console.WriteLine();
    }
  }
}
