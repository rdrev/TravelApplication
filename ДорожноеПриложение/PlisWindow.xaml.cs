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
using System.Windows.Shapes;

namespace ДорожноеПриложение
{
    /// <summary>
    /// Логика взаимодействия для PlisWindow.xaml
    /// </summary>
    public partial class PlisWindow : Window
    {
        private СкладМатериала складМатериала = null;

        private MainPage mainPage = null;

        public PlisWindow(СкладМатериала складМатериала, MainPage mainPage)
        {
            InitializeComponent();

            this.складМатериала = складМатериала;
            this.mainPage = mainPage;

            MaterialBox.Text = складМатериала.МатериалНаз;
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var material = ДорожнаяБазаEntities.GetДорожнаяБазаEntities().СкладМатериала.Find(складМатериала.КодМатериала);
                float kol_vo = float.Parse(PlisBox.Text);

                material.Количиство += kol_vo;

                ДорожнаяБазаEntities.GetДорожнаяБазаEntities().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            mainPage.updateTab3();

            this.Close();
        }
    }
}
