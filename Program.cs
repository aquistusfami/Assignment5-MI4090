/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
namespace Assignment5_MI4090;

class Program
{
    static void Main(string[] args)
    {
        Computer cp1 = new Computer("DV01", "Asus vivobook", 2023, 15_000_000m, DeviceStatus.Active , 16, "Intel i3 - 8145u", true);
        cp1.DisplayDeviceInfo();
        Console.WriteLine();
        Projector pj1 = new Projector("DV02", "Máy chiếu Canon", 2023, 17_000_000m, DeviceStatus.Active , 650, 3001);
        pj1.DisplayDeviceInfo();
        Console.WriteLine();
        Printer pt1 = new Printer("DV03", "Máy in HP", 2023, 10_000_000m, DeviceStatus.Active , PrinterType.Laser, 50000, true);
        pt1.DisplayDeviceInfo();
        cp1.Connect("192.168.0.1");
        Console.WriteLine();
        cp1.DisplayDeviceInfo();
        NetworkPrinter np1 = new NetworkPrinter("DV04", "Máy in Canon", 2023, 10_000_000m, DeviceStatus.Active , PrinterType.Laser, 50000, true);
        np1.Connect("192.168.0.1");
        Console.WriteLine();
        np1.DisplayDeviceInfo();
    }
}
