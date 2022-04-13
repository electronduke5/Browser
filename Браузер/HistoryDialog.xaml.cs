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
using System.Collections;
using System.Collections.ObjectModel;
using System.IO;

namespace Браузер
{
    /// <summary>
    /// Логика взаимодействия для HistoryDialog.xaml
    /// </summary>
    public partial class HistoryDialog : Window
    {
        ObservableCollection<History> histories;

        public string nameFile = Directory.GetCurrentDirectory() + @"\History.dat";
        History history = new History();

        MainWindow window = new MainWindow();

        public HistoryDialog()
        {

            InitializeComponent();


            histories = new ObservableCollection<History>();

            histories = Serialization.Get<ObservableCollection<History>>(nameFile);

            historyKList.ItemsSource = histories;

            this.Closing += HistoryDialog_Closing;


        }

        private void HistoryDialog_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(1);
        }

        private void btDeleteElement_Click(object sender, RoutedEventArgs e)
        {
           
                historyKList.Items.Remove(historyKList.SelectedItem);
        }

        private void btGoHome_Click(object sender, RoutedEventArgs e)
        {
            window.Show();
            this.Hide();
        }

        private void btCloseAll_Click(object sender, RoutedEventArgs e)
        {

            //historyKList.ItemsSource = null;
            histories.Clear();
            File.Delete(nameFile);

           // Serialization.Save(histories, nameFile);

        }
    }
}
