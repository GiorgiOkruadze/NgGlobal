using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Services.Abstractions
{
    public interface IFileService
    {
        Task<string> GetDataFromFile(string filePath);
        Task<bool> WriteDataInFile(string filePath,string data);
    }
}
