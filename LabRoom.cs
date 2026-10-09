/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment5_MI4090;

public class LabRoom 
{
  public string LabRoomId { get; private set; }
  public string LabRoomName { get; private set; }
  public int Space { get; private set; }
  private readonly List<Device> devices = new List<Device>();

  public LabRoom(string id, string name, int space){
    if(string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Mã phòng không được trống.", nameof(id));
    if(space < 0) throw new ArgumentOutOfRangeException(nameof(space), "Sức chưa không được âm.");
    this.LabRoomId = id;
    this.LabRoomName = name;
    this.Space = space;
  }

  public void AddDevice(Device device)
  {
    if (device == null) throw new ArgumentNullException(nameof(device), "Thiết bị không được rỗng.");
    if (devices.Count >= Space) throw new InvalidOperationException("Phòng đã đạt sức chứa tối đa.");
    if (FindDevice(device.DeviceId) != null) throw new InvalidOperationException($"Thiết bị với ID {device.DeviceId} đã tồn tại trong danh sách.");
    devices.Add(device);
  }

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

  public bool RemoveDevice(string id)
  {
    if (string.IsNullOrWhiteSpace(id)) return false;
    Device? devi = FindDevice(id);
    return devi != null && devices.Remove(devi);
  }

  public decimal CalculateAnnualMaintenanceCost()
  {
    decimal totalMCost = 0.0m;
    foreach (var dev in devices)
    {
      totalMCost += dev.CalculateAnnualMaintenanceCost();
    }
    return totalMCost;
  }

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
