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
    /// <summary>
    /// Логика взаимодействия для MatConPage.xaml
    /// </summary>
    public partial class MatConPage : Page
    {
        private Задачи задача = null;

        public MatConPage(Задачи задача, Сотрудники сотрудник)
        {
            InitializeComponent();

            this.задача = задача;

            if (сотрудник.Доступ == "1")
            {
                AddMaterial.Visibility = Visibility.Visible;
            }
            else
            {
                AddMaterial.Visibility = Visibility.Hidden;
            }

            updata();
        }

        private void TBM_TextChanged(object sender, TextChangedEventArgs e)
        {
            updata();
        }

        private void AddMaterial_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.Navigate(new AddMatConPage(задача));
        }

        private void updata()
        {
            var comboList = ДорожнаяБазаEntities.GetДорожнаяБазаEntities().СписокРасходов.ToList();

            comboList = comboList.Where(p => p.СкладМатериала.МатериалНаз.ToLower().Contains(TBM.Text.ToLower()) && p.Задача == задача.КодЗадачи).ToList();

            DGM.ItemsSource = comboList;
        }

        private void CleBtn_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.GoBack();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            updata();
        }
    }
}
