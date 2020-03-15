using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Caselist.TodoModel
{
    /// <summary>
    /// Создаем поля для наших
    /// колонок
    /// </summary>
    public class ToDoModel:INotifyPropertyChanged
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool is_done;
        public string text;

        public bool IsDone
        {
            get { return is_done; }
            set 
            {
                if (is_done == value)
                    return;
                is_done = value;
                onProperty("isdone");
            }
        }
        public string Text
        {
            get { return text; }
            set 
            {
                if (text == value)
                    return;
                text = value;
                onProperty("text");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void onProperty(string properName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properName));
            
        }
    }
}
