using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Браузер
{
    /// <summary>
    /// Логика взаимодействия для ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : Window
    {
        MainWindow mainWindow = new MainWindow();

        public ColorPicker()
        {
            InitializeComponent();
            this.Closing += ColorPicker_Closing;
            
        }

        private void ColorPicker_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

                Brush brush = new SolidColorBrush(_ColorPiker.Color);
            mainWindow.Background = brush;

            mainWindow.Show();
            this.Hide();

        }
        public string path;
        private void btOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";


            if (file.ShowDialog() ?? false)
            {
                path = file.FileName;

            }
            mainWindow.Background = new ImageBrush(new BitmapImage(new Uri(path)));

            mainWindow.Show();
            this.Hide();
        }
    }
}
