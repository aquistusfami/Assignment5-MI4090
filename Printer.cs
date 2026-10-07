/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment5_MI4090;

public enum PrinterType
{
  Laser,
  Phun
}

public class Printer : Device 
{
  public PrinterType Type { get; private set; }
  public int PrintedPage { get; private set; }
  public bool IsColor { get; private set; }

  public Printer(string id, string name, int usedYear, decimal price, DeviceStatus status, PrinterType type, int printedPage, bool isColor)
  : base(id, name, usedYear, price, status)
  {
    this.Type = type;
    this.PrintedPage = printedPage;
    this.IsColor = isColor;
  }

  public override decimal CalculateAnnualMaintenanceCost()
  {
    if (this.PrintedPage > 100000 && this.IsColor == true) 
    {
      return 0.04m*this.Price + 800_000m;
    } 
    else if (this.PrintedPage > 100000 && this.IsColor == false) 
    {
      return 0.04m*this.Price + 500_000m;
    }
    else if (this.PrintedPage <= 100000 && this.IsColor == true)
    {
      return 0.04m*this.Price + 300_000m;
    }
    else return 0.04m*this.Price;
  }

  public override void DisplayDeviceInfo()
  {
    base.DisplayDeviceInfo();
    Console.WriteLine($"-> Loại máy in: {Type}");
    Console.WriteLine($"-> Số trang đã in: {PrintedPage:N0} trang");
    Console.WriteLine($"-> Có in màu: {IsColor}");
    Console.WriteLine($"-> Tiền bảo dưỡng: {CalculateAnnualMaintenanceCost():N0} VND");
  }
}
