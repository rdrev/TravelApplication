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
    public partial class ReportEditorWindow : Window
    {
        private Задачи задача = new Задачи();

        public ReportEditorWindow(Задачи задача)
        {
            InitializeComponent();

            FlowDocument myFlowDoc = new FlowDocument();

            Paragraph myParagraph = new Paragraph();
            myParagraph.Inlines.Add(задача.Отчет);
            myFlowDoc.Blocks.Add(myParagraph);
            ReportBox.Document = myFlowDoc;

            this.задача = задача;
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(ReportBox.Document.ContentStart, ReportBox.Document.ContentEnd);
            задача.Отчет = textRange.Text;

            try
            {
                var task = ДорожнаяБазаEntities.GetДорожнаяБазаEntities().Задачи.Find(задача.КодЗадачи);
                task = задача;

                ДорожнаяБазаEntities.GetДорожнаяБазаEntities().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Close();
        }
    }
}
