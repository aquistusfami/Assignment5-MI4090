/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment5_MI4090;

/// <summary>
/// Lớp máy chiếu kế thừa từ Device
/// </summary>
public class Projector : Device
{
  public int Light { get; private set; }
  public int UsedHours { get; private set; }

  /// <summary>
  /// Constructor khởi tạo thông tin cần thiết cho máy chiếu
  /// </summary>
  /// <param name="id">Mã thiết bị</param>
  /// <param name="name">Tên thiết bị</param>
  /// <param name="usedYear">Năm đưa vào sử dụng</param>
  /// <param name="price">Giá mua</param>
  /// <param name="status">Trạng thái</param>
  /// <param name="light">Độ sáng</param>
  /// <param name="usedHours">Số giờ sử dụng bóng</param>
  public Projector(string id, string name, int usedYear, decimal price, DeviceStatus status, int light, int usedHours) : base(id, name, usedYear, price, status)
  {
    this.Light = light;
    this.UsedHours = usedHours;
  }

  /// <summary>
  /// Method tính toán chi phí bảo dưỡng
  /// </summary>
  /// <returns>Chi phí bảo dưỡng</returns>
  public override decimal CalculateAnnualMaintenanceCost()
  {
    if (this.UsedHours > 3000)
    {
      return 0.03m*this.Price + 1_500_000m;
    }
    else return 0.03m*this.Price;
  }

  public override string ToString()
  {
    return base.ToString() + Environment.NewLine +
    $"-> Độ sáng: {Light} lumen" + Environment.NewLine +
    $"-> Số giờ sử dụng bóng: {UsedHours:N0} giờ" + Environment.NewLine + 
    $"-> Tiền bảo dưỡng: {CalculateAnnualMaintenanceCost():N0} VND";
  }
}
