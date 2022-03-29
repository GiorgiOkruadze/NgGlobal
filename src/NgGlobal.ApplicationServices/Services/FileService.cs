using NgGlobal.ApplicationServices.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Services
{
    public class FileService : IFileService
    {
        public async Task<string> GetDataFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using StreamReader sr = new StreamReader(filePath);
                return await sr.ReadToEndAsync();
            }
            else
            {
                File.Create(filePath).Close();
            }

            return null;
        }

        public async Task<bool> WriteDataInFile(string filePath, string data)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }

                using StreamWriter streamWriter = new StreamWriter(filePath, false);
                await streamWriter.WriteAsync(data);
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
