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
    /// Логика взаимодействия для AddMaterialPage.xaml
    /// </summary>
    public partial class AddMaterialPage : Page
    {
        private СкладМатериала СкладМатериала = new СкладМатериала();

        public AddMaterialPage()
        {
            InitializeComponent();

            DataContext = СкладМатериала;

        }

        private void CleBtn_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.GoBack();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ДорожнаяБазаEntities.GetДорожнаяБазаEntities().СкладМатериала.Add(СкладМатериала);
                ДорожнаяБазаEntities.GetДорожнаяБазаEntities().SaveChanges();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
            MenegerFrame.Frame.GoBack();
        }
    }
}
