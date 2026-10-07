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
    }
}
