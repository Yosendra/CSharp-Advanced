class Program
{
    static void Main()
    {
        DriveInfo driveInfo = new("c:");
        Console.WriteLine($"Name : {driveInfo.Name}");
        Console.WriteLine($"DriveType : {driveInfo.DriveType}");
        Console.WriteLine($"VolumeLabel : {driveInfo.VolumeLabel}");
        Console.WriteLine($"RootDirectory : {driveInfo.RootDirectory}");
        Console.WriteLine($"TotalSize : {driveInfo.TotalSize / 1024 / 1024 / 1024} GB");
        Console.WriteLine($"AvailableFreeSpace : {driveInfo.AvailableFreeSpace / 1024 / 1024 / 1024} GB");

        Console.ReadKey();
    }
}