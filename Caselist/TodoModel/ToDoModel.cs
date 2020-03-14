using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caselist.TodoModel
{
    public class ToDoModel
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool is_done;
        public string text;

        public bool IsDone
        {
            get { return is_done; }
            set { is_done = value; }
        }
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
    }
}
