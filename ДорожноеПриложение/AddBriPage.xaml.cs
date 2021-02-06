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
    /// Логика взаимодействия для AddBriPage.xaml
    /// </summary>
    public partial class AddBriPage : Page
    {
        private Бригады бригада = new Бригады();

        public AddBriPage(Бригады бригада)
        {
            InitializeComponent();

            this.бригада = бригада;

            DataContext = бригада;
        }

        private void CleBtn_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.GoBack();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(бригада.КодБригады == 0)
                {
                    ДорожнаяБазаEntities.GetДорожнаяБазаEntities().Бригады.Add(бригада);
                }   
                else
                {
                    var bri = ДорожнаяБазаEntities.GetДорожнаяБазаEntities().Бригады.Find(бригада.КодБригады);
                    bri = бригада;
                }

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
