using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.Common;

namespace ДорожноеПриложение
{
    public partial class PaymentPeriodWindow : Window
    {
        public PaymentPeriodWindow()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new Thread(() =>
                {
                    Dispatcher.Invoke((Action)(() =>
                    {
                        using (SqlConnection connection =
                        new SqlConnection(@"Data Source=62.63.74.62,1433; Initial Catalog=ДорожнаяБаза; User ID=word; Password=0303"))
                        {
                            SqlCommand command = new SqlCommand("SELECT [Фамилия]" +
                                                                "  ,[Имя]" +
                                                                ",[Отчество] " +
                                                                "  , SUM(Цена) AS Цена " +
                                                              "FROM[dbo].[Сотрудники] " +
                                                                "INNER JOIN[dbo].[Бригады] " +
                                                                   "ON([dbo].[Сотрудники].Бригада = [dbo].[Бригады].КодБригады) " +
                                                               " INNER JOIN[dbo].[Задачи] " +
                                                                    "ON([dbo].[Бригады].[КодБригады] = [dbo].[Задачи].[Бригада])  " +
                                                             "   INNER JOIN[dbo].[Категории] " +
                                                                    "ON([dbo].[Задачи].[Категория] = [dbo].[Категории].[КодКатегории])" +
                                                             " WHERE[Дата] > @s AND[Дата] < @po " +
                                                              "GROUP BY [Фамилия] " +
                                                                ",[Имя] " +
                                                                 ",[Отчество]", connection);
                            command.Parameters.AddWithValue("@s", sData.SelectedDate);
                            command.Parameters.AddWithValue("@po", poData.SelectedDate);

                            connection.Open();
                            SqlDataReader sqlDataReader = command.ExecuteReader();

                            var aplication = new Excel.Application();
                            aplication.SheetsInNewWorkbook = 1;

                            int startRowIndex = 1;

                            Excel.Workbook workbook = aplication.Workbooks.Add(Type.Missing);

                            Excel.Worksheet worksheet = aplication.Worksheets.Item[1];

                            worksheet.Cells[1][startRowIndex] = "Фамилия";
                            worksheet.Cells[2][startRowIndex] = "Имя";
                            worksheet.Cells[3][startRowIndex] = "Отчество";
                            worksheet.Cells[4][startRowIndex] = "Выплота";

                            startRowIndex++;

                            while (sqlDataReader.Read())
                            {
                                worksheet.Cells[1][startRowIndex] = sqlDataReader["Фамилия"].ToString();
                                worksheet.Cells[2][startRowIndex] = sqlDataReader["Имя"].ToString();
                                worksheet.Cells[3][startRowIndex] = sqlDataReader["Отчество"].ToString();
                                worksheet.Cells[4][startRowIndex] = sqlDataReader["Цена"].ToString();

                                startRowIndex++;
                            }

                            sqlDataReader.Close();

                            aplication.Visible = true;
                        }
                    }));
                }).Start();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            this.Close();
        }
    }
}
