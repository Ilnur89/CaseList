using Caselist.TodoModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caselist.SaveDate
{
    public class FileService
    {
        private readonly string Path;

        public FileService(string path)
        {
            Path = path;
        }
        public BindingList<ToDoModel> Load()
        {
            var filexist = File.Exists(Path);
            if (!filexist)
            {
                File.CreateText(Path).Dispose();
                return new BindingList<ToDoModel>();
            }
            using(var reader= File.OpenText(Path))
            {
                var fileExist = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<ToDoModel>>(fileExist);
            }
        }

        public void Save(object _todoDateList )
        {
            using(StreamWriter writer = File.CreateText(Path))
            {
                string output = JsonConvert.SerializeObject(_todoDateList);
                writer.Write(output);
            }
        }
        

    }
}
