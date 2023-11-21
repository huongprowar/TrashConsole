using System.Runtime.Serialization;

class Program
{
    static string rootFolder = "D:\\Study\\TrashConsole\\";

    static void Main(string[] args)
    {
        ModifyAllFileName();
    }

    static void ModifyAllFileName()
    {
        string key = Console.ReadLine();
        int currentOrder = 0;
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
                    string newFilePath = Path.Combine(folderPath, newFileName);
                    File.Move(filePath, newFilePath);
                    Console.WriteLine(newFilePath);
                }
            }
        }
    }

    static void DeleteMetaFile()
    {
        string key = Console.ReadLine();
        string folderPath = rootFolder;
        List<string> folderDirectories = Directory.GetDirectories(folderPath, "*", SearchOption.AllDirectories).ToList();
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
        string key = Console.ReadLine();
        int lastIndex = Convert.ToInt32(Console.ReadLine());

        string folderPath = rootFolder + key;
        string newFileExtension = ".png"; // Phần mở rộng của file mới

        try
        {
            if (Directory.Exists(folderPath))
            {
                string[] filePaths = Directory.GetFiles(folderPath);

                foreach (string filePath in filePaths)
                
                {                    
                    string file = Path.GetFileName(filePath);
                    string[] splitFileName = file.Split('.');
                    int fileIndex = Convert.ToInt32(splitFileName[0]) + lastIndex;

                    string newFileName = key + fileIndex.ToString();
                    Console.WriteLine(newFileName);
                    newFileName = Path.ChangeExtension(newFileName, newFileExtension);

                    // Đổi tên file
                    string newFilePath = Path.Combine(folderPath, newFileName);
                    File.Move(filePath, newFilePath);

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
