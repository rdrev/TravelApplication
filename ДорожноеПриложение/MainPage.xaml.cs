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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private Сотрудники сотрудник = null;

        public MainPage(Сотрудники сотрудник)
        {
            InitializeComponent();

            this.сотрудник = сотрудник;

            if (сотрудник.Доступ == "1")
            {
                AddTask.Visibility = Visibility.Visible;
                UpdTask.Visibility = Visibility.Visible;
                DelTask.Visibility = Visibility.Visible;
                CBB1.Visibility = Visibility.Visible;

                AddEmp.Visibility = Visibility.Visible;
                BriBtn.Visibility = Visibility.Visible;
                LVC.Visibility = Visibility.Visible;
                LVC0.Visibility = Visibility.Hidden;
                CBB2.Visibility = Visibility.Visible;

                AddMaterial.Visibility = Visibility.Visible;
                Payment.Visibility = Visibility.Visible;
                Plis.Visibility = Visibility.Visible;
                Min.Visibility = Visibility.Visible;
                DelMat.Visibility = Visibility.Visible;
            }
            else
            {
                AddTask.Visibility = Visibility.Hidden;
                UpdTask.Visibility = Visibility.Hidden;
                DelTask.Visibility = Visibility.Hidden;
                CBB1.Visibility = Visibility.Hidden;

                AddEmp.Visibility = Visibility.Hidden;
                BriBtn.Visibility = Visibility.Hidden;
                LVC0.Visibility = Visibility.Visible;
                LVC.Visibility = Visibility.Hidden;
                CBB2.Visibility = Visibility.Hidden;

                AddMaterial.Visibility = Visibility.Hidden;
                Payment.Visibility = Visibility.Hidden;
                Plis.Visibility = Visibility.Hidden;
                Min.Visibility = Visibility.Hidden;
                DelMat.Visibility = Visibility.Hidden;
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //Страница задачь
        public void updateTab1()
        {
            var comboList = ДорожнаяБазаEntities.GetДорожнаяБазаEntities().Задачи.ToList();

            if (CBB1.SelectedIndex > 0)
                comboList = comboList.Where(p => p.Бригады == (CBB1.SelectedItem as Бригады)).ToList();
            
            if(сотрудник.Доступ == "1")
                DGT.ItemsSource = comboList;
            else
                DGT.ItemsSource = comboList.Where(p => p.Бригада == сотрудник.Бригада);
        }

        //Редактор отчета
        private void BtnPer_Click(object sender, RoutedEventArgs e)
        {
            var report = new ReportEditorWindow((sender as Button).DataContext as Задачи);
            report.Show();
        }
        
        //Упровлять росходами
        private void MatBtn_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.Navigate(new MatConPage((sender as Button).DataContext as Задачи, сотрудник));
        }

        //Добавать задачу
        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.Navigate(new AddTaskPage(new Задачи()));
        }

        //Изменить задачу
        private void UpdTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.Navigate(new AddTaskPage((sender as Button).DataContext as Задачи));
        }

        //Удалить задачу
        private void DelTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы дельствительно хотете удалить задачу", "Подверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ДорожнаяБазаEntities.GetДорожнаяБазаEntities().Задачи.Remove((sender as Button).DataContext as Задачи);
                ДорожнаяБазаEntities.GetДорожнаяБазаEntities().SaveChanges();
                updateTab1();
            }
        }

        //Обновить список при изменение 
        private void CBB1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateTab1();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //Страница сотрудников
        public void updateTab2()
        {
            var comboList = ДорожнаяБазаEntities.GetДорожнаяБазаEntities().Сотрудники.ToList();

            if (CBB2.SelectedIndex > 0)
                comboList = comboList.Where(p => p.Бригады == (CBB2.SelectedItem as Бригады)).ToList();

            comboList = comboList.Where(p => p.Имя.ToLower().Contains(TBN.Text.ToLower())).ToList();

            if (сотрудник.Доступ == "1")
                LVC.ItemsSource = comboList;
            else
                LVC0.ItemsSource = comboList.Where(p => p.Бригада == сотрудник.Бригада);
        }

        //Обновить список при изменение
        private void CBB2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateTab2();
        }

        //Обновить список при изменение
        private void TBN_TextChanged(object sender, TextChangedEventArgs e)
        {
            updateTab2();
        }

        //Добавить сотрудника
        private void AddEmp_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.Navigate(new AddEmpPage(new Сотрудники()));
        }

        //Редактор бригад 
        private void BriBtn_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.Navigate(new BrigadeEditorPage());
        }

        //Изменить сотрурдника
        private void UpdEmp_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.Navigate(new AddEmpPage((sender as Button).DataContext as Сотрудники));
        }

        //Удалить Сотрудника
        private void DelEmp_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы дельствительно хотете уволить сотрудника", "Подверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ДорожнаяБазаEntities.GetДорожнаяБазаEntities().Сотрудники.Remove((sender as Button).DataContext as Сотрудники);
                ДорожнаяБазаEntities.GetДорожнаяБазаEntities().SaveChanges();
                updateTab2();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //Страница склада
        public void updateTab3()
        {
            var comboList = ДорожнаяБазаEntities.GetДорожнаяБазаEntities().СкладМатериала.ToList();

            comboList = comboList.Where(p => p.МатериалНаз.ToLower().Contains(TBM.Text.ToLower())).ToList();

            DGW.ItemsSource = comboList;
        }

        //Добавить материал
        private void AddMaterial_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.Navigate(new AddMaterialPage());
        }

        //Обновить список при изменение
        private void TBM_TextChanged(object sender, TextChangedEventArgs e)
        {
            updateTab3();
        }

        //Обновить при изменение
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Updata();
            }
        }

        //Окно поставки материала
        private void PlisBtn_Click(object sender, RoutedEventArgs e)
        {
            var win = new PlisWindow((sender as Button).DataContext as СкладМатериала, this);
            win.Show();
        }

        //Окно убали материала
        private void MinBtn_Click(object sender, RoutedEventArgs e)
        {
            var win = new MInWindow((sender as Button).DataContext as СкладМатериала, this);
            win.Show();
        }

        //удаление материала
        private void DelMatBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы дельствительно хотете удалить пазицию", "Подверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ДорожнаяБазаEntities.GetДорожнаяБазаEntities().СкладМатериала.Remove((sender as Button).DataContext as СкладМатериала);
                ДорожнаяБазаEntities.GetДорожнаяБазаEntities().SaveChanges();
                updateTab3();
            }
        }

        //Обновление всех даных
        public void Updata()
        {
            updateTab1();
            updateTab2();
            updateTab3();

            var comboList = ДорожнаяБазаEntities.GetДорожнаяБазаEntities().Бригады.ToList();

            comboList.Insert(0, new Бригады
            {
                Название = "Все"
            });
            CBB1.ItemsSource = comboList;
            CBB2.ItemsSource = comboList;

            CBB1.SelectedIndex = 0;
            CBB2.SelectedIndex = 0;
        }

        private void Payment_Click(object sender, RoutedEventArgs e)
        {
            var win = new PaymentPeriodWindow();
            win.Show();
        }
    }
}
