using Microsoft.AspNetCore.Http;
using PustokAB204.Business.Exceptions;

namespace PustokAB204.Business.Extensions;

public static class Helper
{
    public static string SaveFile(string rootPath, string folder, IFormFile file)
    {
        if (file.ContentType != "image/png" && file.ContentType != "image/jpeg")
            throw new ImageContentTypeException("Fayl formati duzgun deyil!");

        if (file.Length > 2097152)
            throw new ImageSizeException("Sheklin olcusu max 2mb ola biler!");

        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        string path = rootPath + $@"\{folder}\" + fileName;

        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            file.CopyTo(fileStream);
        }

        return fileName;
    }

    public static void DeleteFile(string rootPath, string folder, string fileName)
    {
        string path = rootPath + $@"\{folder}\" + fileName;
        if (!File.Exists(path))
            throw new Exceptions.FileNotFoundException("fayl tapilmadi");

        File.Delete(path);
    }
}
