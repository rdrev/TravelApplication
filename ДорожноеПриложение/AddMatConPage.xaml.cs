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
    public partial class AddMatConPage : Page
    {
        private СписокРасходов cписокРасходов = new СписокРасходов();
        private Задачи Задачи = null;

        public AddMatConPage(Задачи задача)
        {
            DataContext = cписокРасходов;

            InitializeComponent();

            CBM.ItemsSource = ДорожнаяБазаEntities.GetДорожнаяБазаEntities().СкладМатериала.ToList();
            this.Задачи = задача;
        }

        private void CleBtn_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.GoBack();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cписокРасходов.Задачи = Задачи;

                var sr = ДорожнаяБазаEntities.GetДорожнаяБазаEntities().СписокРасходов.ToList().Find(p => p.Задачи == Задачи && p.СкладМатериала == cписокРасходов.СкладМатериала);
                if (sr != null)
                {
                    sr.КолисчествоРасхода += cписокРасходов.КолисчествоРасхода;
                }
                else
                    ДорожнаяБазаEntities.GetДорожнаяБазаEntities().СписокРасходов.Add(cписокРасходов);

                var minZ = ДорожнаяБазаEntities.GetДорожнаяБазаEntities().СкладМатериала.ToList().Find(p => p == cписокРасходов.СкладМатериала);

                if (minZ.Количиство - cписокРасходов.КолисчествоРасхода > 0)
                    minZ.Количиство -= cписокРасходов.КолисчествоРасхода;
                else
                {
                    MessageBox.Show("на складе всего " + minZ.Количиство.ToString());
                    return;
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
