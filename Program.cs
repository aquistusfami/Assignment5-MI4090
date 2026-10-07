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
    }
}
