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
        public MainPage()
        {
            InitializeComponent();
        }

        //Страница задачь
        private void updateTab1()
        {
            var comboList = ДорожнаяБазаEntities.GetДорожнаяБазаEntities().Задачи.ToList();

            if (CBB1.SelectedIndex > 0)
                comboList = comboList.Where(p => p.Бригады == (CBB1.SelectedItem as Бригады)).ToList();

            DGT.ItemsSource = comboList;
        }

        //Редактор отчета
        private void BtnPer_Click(object sender, RoutedEventArgs e)
        {
            var report = new ReportEditorWindow((sender as Button).DataContext as Задачи);
            report.Show();
        }

        //Добавать задачу
        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.Navigate(new AddTaskPage(new Задачи()));
        }

        //Изменить задачу
        private void UpdTask_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.Navigate(new AddTaskPage((sender as Button).DataContext as Задачи));
        }

        //Удалить задачу
        private void DelTask_Click(object sender, RoutedEventArgs e)
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

        //Страница сотрудников
        private void updateTab2()
        {
            var comboList = ДорожнаяБазаEntities.GetДорожнаяБазаEntities().Сотрудники.ToList();

            if (CBB2.SelectedIndex > 0)
                comboList = comboList.Where(p => p.Бригады == (CBB2.SelectedItem as Бригады)).ToList();

            comboList = comboList.Where(p => p.Имя.ToLower().Contains(TBN.Text.ToLower())).ToList();

            LVC.ItemsSource = comboList;
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

        //Добавить бригаду
        private void AddBri_Click(object sender, RoutedEventArgs e)
        {

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

        //Страница склада
        private void updateTab3()
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
        }

    }
}
