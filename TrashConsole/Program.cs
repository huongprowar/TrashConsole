using System.Runtime.Serialization;

class Program
{
    static string rootFolder = "D:\\Study\\TrashConsole\\";

    static void Main(string[] args)
    {
        DeleteMetaFile();
    }

    static void ModifyAllFileName()
    {
        Console.WriteLine("Enter extension: ");
        string key = Console.ReadLine();
        int currentOrder = 1;
        string folderPath = rootFolder;
        List<string> folderDirectories = Directory.GetDirectories(folderPath, "*", SearchOption.AllDirectories).ToList();
        foreach (string directory in folderDirectories)
        {
            if (Directory.Exists(directory))
            {
                string[] filePaths = Directory.GetFiles(directory);

                foreach (string fullFilePath in filePaths)
                {
                    if (!fullFilePath.Contains(key)) continue;
                    string filePath = Path.GetDirectoryName(fullFilePath);
                    string newFileName = Path.ChangeExtension(currentOrder.ToString(), key);

                    // Đổi tên file
                    string newFilePath = Path.Combine(filePath, newFileName);
                    File.Move(fullFilePath, newFilePath);
                    Console.WriteLine(newFilePath);
                    currentOrder++;
                }
            }
        }
    }

    static void DeleteMetaFile()
    {
        Console.Write("Input directory path: ");
        string inputDirectoryPath= Console.ReadLine();
        List<string> folderDirectories = Directory.GetDirectories(inputDirectoryPath, "*", SearchOption.AllDirectories).ToList();
        foreach (string directory in folderDirectories)
        {
            if (Directory.Exists(directory))
            {
                string[] filePaths = Directory.GetFiles(directory);

                foreach (string filePath in filePaths)
                {

                    if (filePath.Contains("meta"))
                    {
                        File.Delete(filePath);
                    }

                }                
            }            
        }
    }
    static void ChangeFileName()
    {
        Console.WriteLine("Change filename!!!!!");
        Console.Write("Enter key: ");
        string key = Console.ReadLine();
        Console.Write("Enter last index: ");
        int lastIndex = Convert.ToInt32(Console.ReadLine());

        string folderPath = rootFolder + key;
        string newFileExtension = ".png"; // Phần mở rộng của file mới
        int currentOrder = 1;
        try
        {
            if (Directory.Exists(folderPath))
            {
                string[] filePaths = Directory.GetFiles(folderPath);

                foreach (string filePath in filePaths)
                
                {                    
                    string file = Path.GetFileName(filePath);
                    string[] splitFileName = file.Split('.');
                    int fileIndex = currentOrder + lastIndex;

                    string newFileName = key + fileIndex.ToString();
                    Console.WriteLine(newFileName);
                    newFileName = Path.ChangeExtension(newFileName, newFileExtension);

                    // Đổi tên file
                    string newFilePath = Path.Combine(folderPath, newFileName);
                    File.Move(filePath, newFilePath);
                    currentOrder++;
                }

                Console.WriteLine("Đổi tên tất cả các file thành công.");
            }
            else
            {
                Console.WriteLine("Thư mục không tồn tại.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
        }
    }
}
