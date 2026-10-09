/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment5_MI4090;

public class Projector : Device
{
  public int Light { get; private set; }
  public int UsedHours { get; private set; }

  public Projector(string id, string name, int usedYear, decimal price, DeviceStatus status, int light, int usedHours) : base(id, name, usedYear, price, status)
  {
    this.Light = light;
    this.UsedHours = usedHours;
  }

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
