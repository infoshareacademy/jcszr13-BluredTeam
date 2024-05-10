using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PP0.StaticClasses
{
    internal static class OperationsWithJson
    {
        private static readonly JsonSerializerOptions _options = new() { WriteIndented = true };

        internal static List<T> DeserilizeJson<T>(string fileName) {
            Stream streamJson = new FileStream(fileName,FileMode.Open,FileAccess.Read);
            return JsonSerializer.Deserialize<List<T>>(streamJson, _options);
        }

    }
}
