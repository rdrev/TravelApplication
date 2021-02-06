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
    /// Логика взаимодействия для BrigadeEditorPage.xaml
    /// </summary>
    public partial class BrigadeEditorPage : Page
    {
        public BrigadeEditorPage()
        {
            InitializeComponent();

            DGB.ItemsSource = ДорожнаяБазаEntities.GetДорожнаяБазаEntities().Бригады.ToList();
        }

        private void AddBrig_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.Navigate(new AddBriPage(new Бригады()));
        }

        private void CleBtn_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.GoBack();
        }

        private void TBB_TextChanged(object sender, TextChangedEventArgs e)
        {
            DGB.ItemsSource = ДорожнаяБазаEntities.GetДорожнаяБазаEntities().Бригады.ToList().Where(p => p.Название.ToLower().Contains(TBB.Text.ToLower()));
        }

        private void UpdBriBtn_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.Navigate(new AddBriPage((sender as Button).DataContext as Бригады));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DGB.ItemsSource = ДорожнаяБазаEntities.GetДорожнаяБазаEntities().Бригады.ToList().Where(p => p.Название.ToLower().Contains(TBB.Text.ToLower()));

        }

        private void DelBriBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы дельствительно хотете удалить пазицию", "Подверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ДорожнаяБазаEntities.GetДорожнаяБазаEntities().Бригады.Remove((sender as Button).DataContext as Бригады);
                ДорожнаяБазаEntities.GetДорожнаяБазаEntities().SaveChanges();
                DGB.ItemsSource = ДорожнаяБазаEntities.GetДорожнаяБазаEntities().Бригады.ToList();
            }
        }
    }
}
