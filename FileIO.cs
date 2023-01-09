
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
        public BindingList<Product> loadFile()
        {
            var fileExist = File.Exists(this.Path);
            if (!fileExist)
            {
                File.CreateText(this.Path).Dispose();
                return new BindingList<Product>();
            }
            using (FileStream fs = new FileStream(this.Path, FileMode.Open))
            {
                return JsonSerializer.Deserialize<BindingList<Product>>(fs);
            }
        }
        // метод сохраняет данные в json
        public void saveData(BindingList<Product> products)
        {
            using (FileStream fs = new FileStream(this.Path, FileMode.Create))
            {
                JsonSerializer.Serialize<BindingList<Product>>(fs, products);
            }
        }
    }
}