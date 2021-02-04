using System;
using System.Collections.Generic;
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

namespace ДорожноеПриложение
{
    public partial class AddTaskPage : Page
    {
        private Задачи задача = new Задачи();

        public AddTaskPage(Задачи задача)
        {
            this.задача = задача;

            InitializeComponent();
            задача.Дата = DateTime.Today;
            DataContext = задача; 
            CBK.ItemsSource = ДорожнаяБазаEntities.GetДорожнаяБазаEntities().Категории.ToList(); 
            CBB.ItemsSource = ДорожнаяБазаEntities.GetДорожнаяБазаEntities().Бригады.ToList();
        }

        private void CleBtn_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.GoBack();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(задача.КодЗадачи == 0)
                {
                    ДорожнаяБазаEntities.GetДорожнаяБазаEntities().Задачи.Add(задача);
                    ДорожнаяБазаEntities.GetДорожнаяБазаEntities().SaveChanges();
                }
                else
                {
                    var task = ДорожнаяБазаEntities.GetДорожнаяБазаEntities().Задачи.Find(задача.КодЗадачи);
                    task = задача;

                    ДорожнаяБазаEntities.GetДорожнаяБазаEntities().SaveChanges();
                }
            }
            catch (Exception ex)     
            {
                MessageBox.Show(ex.Message);
            }

            MenegerFrame.Frame.GoBack();
        }
    }
}
