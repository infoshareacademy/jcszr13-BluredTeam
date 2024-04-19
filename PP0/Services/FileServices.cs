using Newtonsoft.Json;
using PP0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP0.Services
{
    internal class FileServices
    {
        
        private static string _użytkownik= "users.json";

      
        private static string _usersFilePath = @$"{AppDomain.CurrentDomain.BaseDirectory}/../../../Files/{_użytkownik}";


        public void SaveIntoBinDirectory(User user)
        {
            Save(user, _użytkownik);
        }

        public List<User> LoadFromBinDirectory()
        {
            return Load(_użytkownik);
        }

        private void Save(User user, string path)
        {
            var users = Load(path);

            users.Add(user);

            var userAsJson = JsonConvert.SerializeObject(users, Formatting.Indented);


            File.WriteAllText(path, userAsJson);
        }

        private List<User> Load(string path)
        {

            if (!File.Exists(path))
            {
                return new List<User>();
            }

            var usersJson = File.ReadAllText(path);


            if (string.IsNullOrWhiteSpace(usersJson))
            {
                return new List<User>();
            }

            var users = JsonConvert.DeserializeObject<List<User>>(usersJson);

            return users;
        }
    }
}

