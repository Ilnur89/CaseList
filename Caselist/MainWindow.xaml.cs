using Caselist.SaveDate;
using Caselist.TodoModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Caselist
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Создаем контейнер для списка дел
        /// </summary>
        private readonly string PATH= $"{Environment.CurrentDirectory}\\caselist.json";
        private BindingList<ToDoModel> _todoDateList;
        private FileService _fileserv;
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Делаем привязку
        /// наших дел к интерфейсу(<DateGrid/>)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileserv = new FileService(PATH);

            try
            {
               _todoDateList = _fileserv.Load();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

             dgTodolist.ItemsSource=_todoDateList;
            _todoDateList.ListChanged += _todoDateList_ListChanged;  //Когда будет что-то изменяться будет вызываться событие            
         }

        private void _todoDateList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _fileserv.Save(sender);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
            
        }
    }
}