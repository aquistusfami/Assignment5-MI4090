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
    decimal cost = 0.04m*this.Price;
    if (PrintedPage > 100000) cost += 500_000m;
    if (IsColor) cost += 300_000m;
    return cost;
  }

  public override string ToString()
  {
    return base.ToString() + Environment.NewLine +
    $"-> Loại máy in: {Type}" + Environment.NewLine +
    $"-> Số trang đã in: {PrintedPage:N0} trang" + Environment.NewLine +
    $"-> Có in màu: {IsColor}" + Environment.NewLine +
    $"-> Tiền bảo dưỡng: {CalculateAnnualMaintenanceCost():N0} VND";
  }
}
