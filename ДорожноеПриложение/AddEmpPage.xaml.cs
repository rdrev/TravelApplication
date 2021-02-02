using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
using Microsoft.Win32;

namespace ДорожноеПриложение
{
   
    public partial class AddEmpPage : Page
    {
        private Сотрудники сотрудник = new Сотрудники();

        public AddEmpPage(Сотрудники сотрудник)
        {
            this.сотрудник = сотрудник;

            InitializeComponent();
            DataContext = сотрудник;
            CBB.ItemsSource = ДорожнаяБазаEntities.GetДорожнаяБазаEntities().Бригады.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (password1.Password == password2.Password)
                {
                    сотрудник.Пароль = password1.Password;
                    if (сотрудник.КодСотрудника == 0)
                    {
                        ДорожнаяБазаEntities.GetДорожнаяБазаEntities().Сотрудники.Add(сотрудник);
                        ДорожнаяБазаEntities.GetДорожнаяБазаEntities().SaveChanges();
                    }
                    else
                    {
                       var emp = ДорожнаяБазаEntities.GetДорожнаяБазаEntities().Сотрудники.Find(сотрудник.КодСотрудника);
                        emp = сотрудник;

                        ДорожнаяБазаEntities.GetДорожнаяБазаEntities().SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MenegerFrame.Frame.GoBack();
        }

        private void ObzBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

            Nullable<bool> result = openFileDialog.ShowDialog();

 
            if (result == true)
            {
                string filename = openFileDialog.FileName;
                var img = File.ReadAllBytes(filename);
                var path = System.IO.Path.Combine(Environment.CurrentDirectory, "Bilder", filename);
                var uri = new Uri(path);
                var bitmap = new BitmapImage(uri);

                сотрудник.Фото = img;

                ipmegePoto.Source = bitmap;
            }
        }

        private void CleBtn_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.GoBack();
        }
    }
}
