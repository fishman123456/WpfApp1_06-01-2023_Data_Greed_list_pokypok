
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace WpfApp1_06_01_2023_Data_Greed_list_pokypok
{
    // класс для работы с сохранением данных в файл json
    internal class FileIO
    {
        // поле только для чтения для задания пути сохранения
        private readonly string Path;
        // конструктор объекта 
        public FileIO(string path)
        {
            this.Path = path;
        }
        // метод возвращает BindingList с данными при загрузке, пустой если файла не существует


        public BindingList<Product> LoadData()
        {
            var fileExist = File.Exists(this.Path);
            if (!fileExist)
            {
                File.CreateText(this.Path).Dispose();
                return new BindingList<Product>();
            }
            using (var reader = File.OpenText(Path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Product>>(fileText);
            }
        }




        // метод сохраняет данные в json
        public void SaveData(object products)

        {
            using (StreamWriter writer = File.CreateText(Path))
            {
                string output = JsonConvert.SerializeObject(products);
                writer.Write(output);
            }
        }
    }
}