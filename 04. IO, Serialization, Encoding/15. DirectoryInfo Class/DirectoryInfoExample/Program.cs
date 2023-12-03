//1. Create a folder "countries" in "c:\practice"
//2. Create three folders "India", "UK", "USA" in "countries" folder
//3. Create three files "capitals.txt", "sports.txt", and "population.txt" in "countries" folder
//4. Move/rename "countries" as "world"
//5. List the files of "world" folder
//6. List the folders of "world" folder
//7. Delete the "world" folder including its files and sub-folders.

class Program
{
    static void Main()
    {
        // DirectoryInfo is not static class. It needs to be instantiated

        //1. Create a folder "countries" in "c:\practice"
        string countriesPath = @"c:\practice\countries\";
        DirectoryInfo directoryInfo = new(countriesPath);
        directoryInfo.Create();
        Console.WriteLine("countries folder created");

        //2. Create three folders "India", "UK", "USA" in "countries" folder
        directoryInfo.CreateSubdirectory("India");
        directoryInfo.CreateSubdirectory("UK");
        directoryInfo.CreateSubdirectory("USA");
        Console.WriteLine("'India', 'UK', 'USA' folders created");

        //3. Create three files "capitals.txt", "sports.txt", and "population.txt" in "countries" folder
        new FileInfo(directoryInfo.FullName + @"\capitals.txt").Create().Close();
        new FileInfo(directoryInfo.FullName + @"\sports.txt").Create().Close();
        new FileInfo(directoryInfo.FullName + @"\population.txt").Create().Close();
        Console.WriteLine("'capitals.txt', 'sports.txt', 'population.txt' files created");

        //4. Move/rename "countries" as "world"
        string worldPath = @"c:\practice\world\";
        directoryInfo.MoveTo(worldPath);
        Console.WriteLine("'countries' moved to 'world'");

        //5. List the files of "world" folder
        FileInfo[] files = directoryInfo.GetFiles();
        Console.WriteLine("\nFiles:");
        foreach (var file in files)
        {
            Console.WriteLine($"{file.FullName} {file.Length}");
        }

        //6. List the folders of "world" folder
        DirectoryInfo[] directories = directoryInfo.GetDirectories();
        Console.WriteLine("\nFolders:");
        foreach (var directory in directories)
        {
            Console.WriteLine(directory.FullName);
        }

        //7. Delete the "world" folder including its files and sub-folders.
        directoryInfo.Delete(true);
        Console.WriteLine("\nworld folder deleted");

        Console.ReadKey();
    }
}