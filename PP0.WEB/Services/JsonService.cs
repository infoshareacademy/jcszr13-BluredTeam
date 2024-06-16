using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PP0.WEB.Services
{
    internal static class JsonService
    {
        private static readonly JsonSerializerOptions _options = new() { WriteIndented = true };

        internal static List<T> DeserilizeJson<T>(string fileName) {
            using Stream streamJson = new FileStream(fileName,FileMode.Open,FileAccess.Read);
            return JsonSerializer.Deserialize<List<T>>(streamJson, _options);
        }

        internal static void SerializeToJson<T>(List<T> list, string fileName) { 
                string jsonString = JsonSerializer.Serialize(list, _options);
                File.WriteAllText(fileName, jsonString);
        }

    }
}
