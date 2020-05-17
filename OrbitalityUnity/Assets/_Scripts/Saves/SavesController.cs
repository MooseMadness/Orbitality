using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Saves
{
    public class SavesController
    {
        public SavesController()
        {
            var savesFolder = $"{Application.persistentDataPath}/Saves";
            if (!Directory.Exists(savesFolder))
                Directory.CreateDirectory(savesFolder);
        }

        public T LoadData<T>(string fileName)
        {
            var formatter = new BinaryFormatter();

            var fullName = GetFullName(fileName);
            T data;
            using (var fs = new FileStream(fullName, FileMode.Open))
                data = (T)formatter.Deserialize(fs);

            return data;
        }

        public bool IsDataExist(string fileName)
        {
            var fullName = GetFullName(fileName);
            return File.Exists(fullName);
        }

        public void RemoveData(string fileName)
        {
            var fullName = GetFullName(fileName);
            File.Delete(fullName);
        }

        public void SaveData<T>(string fileName, T data)
        {
            var fullName = GetFullName(fileName);
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fullName, FileMode.Create))
                formatter.Serialize(fs, data);
        }

        private string GetFullName(string fileName)
        {
            return $"{Application.persistentDataPath}/Saves/{fileName}";
        }
    }
}