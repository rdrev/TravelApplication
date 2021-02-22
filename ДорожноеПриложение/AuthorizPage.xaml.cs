using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для AuthorizPage.xaml
    /// </summary>
    public partial class AuthorizPage : Page
    {
        public AuthorizPage()
        {
            InitializeComponent();
        }

        private void VxodBtn_Click(object sender, RoutedEventArgs e)
        {
            //просба подождать
            InfV.Visibility = Visibility.Visible;

            //открытие поотока 
            new Thread(() =>
            {
                Dispatcher.Invoke((Action)(() =>
                {//поиск пользователя
                    var vxod = ДорожнаяБазаEntities.GetДорожнаяБазаEntities().Сотрудники.ToList().Find(p => p.Логин == login.Text && p.Пароль == Convert.ToString(password.Password));
                    //проверка успеха поиска
                    if (vxod != null)
                        MenegerFrame.Frame.Navigate(new MainPage(vxod));//откртие главной формы 
                    else
                    {
                        InfV.Visibility = Visibility.Hidden;//скрытие надпись подаждать
                        MessageBox.Show("не верный лошин или пароль", "упс");//вывод собщене об ощибки
                    }
                }));
            }).Start();
        }
    }
}
