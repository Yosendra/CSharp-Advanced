//  1. Create a folder "countries" in "c:\practice"
//  2. Create three folders "India", "UK", "USA" in "countries" folder
//  3. Create three files "capitals.txt", "sports.txt", and "population.txt" in "countries" folder
//  4. Move/rename "countries" as "world"
//  5. List the files of "world" folder
//  6. List the folders of "world" folder
//  7. Delete the "world" folder including its files and sub-folders.

class Program
{
    static void Main()
    {
        //  1. Create a folder "countries" in "c:\practice"
        string countriesFolderPath = @"c:\practice\countries";
        Directory.CreateDirectory(countriesFolderPath);
        Console.WriteLine("countries folder created.");

        //  2. Create three folders "India", "UK", "USA" in "countries" folder
        string indiaPath = countriesFolderPath + @"\India";
        string ukPath = countriesFolderPath + @"\UK";
        string usaPath = countriesFolderPath + @"\USA";
        Directory.CreateDirectory(indiaPath);
        Directory.CreateDirectory(ukPath);
        Directory.CreateDirectory(usaPath);
        Console.WriteLine("Sub-directories 'India', 'UK', 'USA' created");

        //  3. Create three files "capitals.txt", "sports.txt", and "population.txt" in "countries" folder
        string capitalFilePath = countriesFolderPath + @"\capitals.txt";
        string sportsFilePath = countriesFolderPath + @"\sports.txt";
        string populationFilePath = countriesFolderPath + @"\population.dat";
        File.Create(capitalFilePath).Close();
        File.Create(sportsFilePath).Close();
        File.Create(populationFilePath).Close();
        Console.WriteLine("Files 'capitals.txt', 'sports.txt', 'population.dat' created");

        //  4. Move/rename "countries" as "world"
        string worldFolderPath = @"c:\practice\world";
        Directory.Move(countriesFolderPath, worldFolderPath);
        Console.WriteLine("'countries' folder moved to 'world'");

        //  5. List the files of "world" folder
        string[] files = Directory.GetFiles(worldFolderPath, "*.txt");
        Console.WriteLine("\nFiles:");
        foreach (var file in files)
        {
            Console.WriteLine(file);
        }

        //  6. List the folders of "world" folder
        string[] directories = Directory.GetDirectories(worldFolderPath);
        Console.WriteLine("\nFolders:");
        foreach (var directory in directories)
        {
            Console.WriteLine(directory);
        }

        //  7. Delete the "world" folder including its files and sub-folders.
        Directory.Delete(worldFolderPath, recursive: true);
        Console.WriteLine("\n'world' folder deleted");

        Console.ReadKey();
    }
}