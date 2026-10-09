/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
namespace Assignment5_MI4090;

class Program
{
    static void Main(string[] args)
    {   
        // Khởi tạo dữ liệu
        Computer cp1 = new Computer("CP1", "Asus GL552VX", 2018, 15_000_000m, DeviceStatus.Active , 16, "Intel i5 - 6300HQ", true);
        Computer cp2 = new Computer("CP2", "Thinkpad P14s Gen 5", 2024, 35_000_000m, DeviceStatus.Active , 32, "AMD Ryzen 7 PRO 8840HS", false);

        Projector pj1 = new Projector("DV02", "Máy chiếu Canon", 2023, 17_000_000m, DeviceStatus.Active , 650, 3001);

        Printer pt1 = new Printer("PT01", "Máy in HP", 2023, 10_000_000m, DeviceStatus.Active , PrinterType.Laser, 100001, true);
        NetworkPrinter np1 = new NetworkPrinter("DV04", "Máy in Canon", 2023, 10_000_000m, DeviceStatus.UnderMaintenance , PrinterType.Laser, 50000, true);

        LabRoom lr1 = new LabRoom("LR01", "FAMI AI Lab", 250);
        LabRoom lr2 = new LabRoom("LR02", "FAMIsec Lab", 100);

        // Thêm thiết bị
        lr1.AddDevice(cp1);

        // thêm trùng mã 
        try
        {
            lr1.AddDevice(cp1);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"<Error>: {ex.Message}");
        }
        Console.WriteLine($"------------------------------------------------------------");
        lr1.AddDevice(cp2);
        lr1.AddDevice(pt1);
        lr2.AddDevice(pj1);
        lr2.AddDevice(np1);

        // in ds thiết bị từng phòng
        lr1.DisplayInfo();
        Console.WriteLine($"------------------------------------------------------------");
        lr2.DisplayInfo();

        // tổng chi phí bảo dưỡng từng phòng
        Console.WriteLine($"------------------------------------------------------------");
        Console.WriteLine("Chi phí phòng {0} - {1}: {2} VND",lr1.LabRoomName,lr1.LabRoomId,lr1.CalculateAnnualMaintenanceCost());
        Console.WriteLine("Chi phí phòng {0} - {1}: {2} VND",lr2.LabRoomName,lr2.LabRoomId,lr2.CalculateAnnualMaintenanceCost());

        // liệt kê thiết bị cần bảo trì 
        Console.WriteLine($"------------------------------------------------------------");
        List<Device> drm1 = lr1.GetDevicesRequiringMaintenance();
        foreach (var dev in drm1)
        {
            Console.WriteLine("<-> {0} - {1}", dev.DeviceId, dev.DeviceName);
        }
        List<Device> drm2 = lr2.GetDevicesRequiringMaintenance();
        foreach (var dev in drm2)
        {
            Console.WriteLine("<-> {0} - {1}", dev.DeviceId, dev.DeviceName);
        }

        // kết nối mạng cho các thiết bị = method
        Console.WriteLine($"------------------------------------------------------------");
        cp1.Connect("168.192.1.1");
        cp2.Connect("168.192.1.1");
        np1.Connect("168.192.1.1");

        Console.WriteLine(cp1);
        Console.WriteLine(cp2);
        Console.WriteLine(np1);

        cp1.Disconnect();
        cp2.Disconnect();
        np1.Disconnect();
        // duyệt các thiết bị qua interface và thực hiện kết nối cùng 1 wifi 
        Console.WriteLine($"------------------------------------------------------------");
        List<INetworkable> ndevs = new List<INetworkable>();
        ndevs.Add(cp1);
        ndevs.Add(cp2);
        ndevs.Add(np1);

        foreach (INetworkable dev in ndevs)
        {
            dev.Connect("168.192.1.1");
        }
        foreach (INetworkable dev in ndevs)
        {
            Console.WriteLine(dev);
        }
    }
}
