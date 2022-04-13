using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.IO;


namespace Браузер
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        ObservableCollection<History> histories;
        List<Zakl> zakladki = new List<Zakl>();



        public MainWindow()
        {
            string path = Directory.GetCurrentDirectory() + @"\Zakladki.dat";

            InitializeComponent();
            histories = Serialization.Get<ObservableCollection<History>>(nameFile);
            
            this.Closing += MainWindow_Closing;
            AddTab("https://google.com");

            //Сохранение закладок в файл

            //using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            //{
            //    while (reader.PeekChar() > -1)
            //    {
            //        //zakladki.Add(new Zakl() { URL = reader.ReadString() });
            //        lbZakl.Items.Add(reader.ReadString());

            //    }
            //}


        }
        struct Zakl
        {
            public string URL;
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Сохранение закладок в файл

            //string path = Directory.GetCurrentDirectory() + @"\Zakladki.dat";

            //using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            //{

            //    foreach (Zakl zakl in zakladki)
            //        writer.Write(zakl.URL);
            //}
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser web = (WebBrowser)(tcTabs.SelectedItem as TabItem).Content;
            web.Refresh();
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser Browser = (WebBrowser)(tcTabs.SelectedItem as TabItem).Content;

            if (Browser.CanGoBack)
                Browser.GoBack();
        }
        private void btForward_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser Browser = (WebBrowser)(tcTabs.SelectedItem as TabItem).Content;

            if (Browser.CanGoForward)
                Browser.GoForward();
        }

        private void tbUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Search();
            }
        }
        private void Search()
        {
            WebBrowser Browser = (WebBrowser)(tcTabs.SelectedItem as TabItem).Content;

            if (!tbUrl.Text.Contains("https://www"))
                Browser.Source = new Uri("https://www.google.ru/search?q=" + tbUrl.Text);
        }

        private void btHistory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WebBrowser Browser = (WebBrowser)(tcTabs.SelectedItem as TabItem).Content;
            Browser.Navigate(btHistory.SelectedItem.ToString());
        }

        private void btNew_Tab_Click(object sender, RoutedEventArgs e)
        {
            AddTab("https://google.com");
        }
        private void AddTab(string url)
        {
            TabItem tabItem = new TabItem();
            WebBrowser webBrowser = new WebBrowser();
            
           
            webBrowser.Navigate(url);

            webBrowser.Navigated += WebBrowser_Navigated;

            Binding binding = new Binding("Source");
            binding.Source = webBrowser;
            tabItem.SetBinding(TabItem.HeaderProperty, binding);


            tabItem.Content = webBrowser;
            
            
            tcTabs.Items.Add(tabItem);
            tcTabs.SelectedIndex = tcTabs.Items.Count - 1;

            if (CountingBadge.Badge == null || Equals(CountingBadge.Badge, string.Empty))
                CountingBadge.Badge = 0;

            var next = int.Parse(CountingBadge.Badge.ToString() ?? "0") + 1;

            CountingBadge.Badge = next < 21 ? (object)next : null;
        }
        public string nameFile = Directory.GetCurrentDirectory() + @"\History.dat";

        private void WebBrowser_Navigated(object sender, NavigationEventArgs e)
        {
            WebBrowser Browser = (WebBrowser)(tcTabs.SelectedItem as TabItem).Content;

            (tcTabs.SelectedItem as TabItem).Header = Browser.Source.OriginalString;

            tbUrl.Text = Browser.Source.OriginalString;
            if (rbIncog.IsChecked == false)
            {
                btHistory.Items.Add(Browser.Source);

                histories.Add(new History() { Date = DateTime.Today.ToShortDateString(), Time = DateTime.Now.ToShortTimeString(), URL = tbUrl.Text });

                Serialization.Save(histories, nameFile);
            }
        }

        private void CountingButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (CountingBadge.Badge == null || Equals(CountingBadge.Badge, string.Empty))
                CountingBadge.Badge = 1;

            var next = int.Parse(CountingBadge.Badge.ToString() ?? "0") + 1;

            CountingBadge.Badge = next < 21 ? (object)next : null;
        }

        private void btDelete_Tab_Click(object sender, RoutedEventArgs e)
        {
            if (tcTabs.Items.Count > 1)
                tcTabs.Items.Remove(tcTabs.SelectedItem);

            if (CountingBadge.Badge == null || Equals(CountingBadge.Badge, string.Empty))
                CountingBadge.Badge = 0;
            if (CountingBadge.Badge.ToString() != "1")
            {


                var next = int.Parse(CountingBadge.Badge.ToString() ?? "0") - 1;

                CountingBadge.Badge = next < 21 ? (object)next : null;
            }
        }



        private void PickColor_Click(object sender, RoutedEventArgs e)
        {
            ColorPicker picker = new ColorPicker();

            picker.Show();
            this.Hide();
        }

        private void _History_Click(object sender, RoutedEventArgs e)
        {
            HistoryDialog historyDialog = new HistoryDialog();
            historyDialog.Show();

            this.Hide();
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void btAddZaklad_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser Browser = (WebBrowser)(tcTabs.SelectedItem as TabItem).Content;

            //Сохранение закладок в файл

            ////Zakladki.Add(Browser.Source.ToString());
            //zakladki.Add(new Zakl() { URL = Browser.Source.ToString() });
            lbZakl.Items.Add(Browser.Source);
        }
        private void btDeleteZaklad_Click(object sender, RoutedEventArgs e)
        {
            lbZakl.Items.Remove(lbZakl.SelectedItem);
        }

        private void btGoForZakl_Click(object sender, RoutedEventArgs e)
        {
            if (lbZakl.SelectedItems.Count != 0)
            {
                AddTab("https://google.com");
                WebBrowser Browser = (WebBrowser)(tcTabs.SelectedItem as TabItem).Content;
                Browser.Navigate(lbZakl.SelectedItem.ToString());
            }
        }

        private void btPrint_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser Browser = (WebBrowser)(tcTabs.SelectedItem as TabItem).Content;

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(Browser, "Print");
            }
        }

        private void btDuplicate_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser Browser = (WebBrowser)(tcTabs.SelectedItem as TabItem).Content;

            AddTab(Browser.Source.OriginalString);
        }

        private void btDeleteAllTabs_Click(object sender, RoutedEventArgs e)
        {
            for (int i = tcTabs.Items.Count - 1; i >= 0; i--)
                tcTabs.Items.RemoveAt(i);

            CountingBadge.Badge = 0;
            AddTab("https://google.com");

        }

       

        //private void btPin_Click(object sender, RoutedEventArgs e)
        //{
        //    WebBrowser Browser = (WebBrowser)(tcTabs.SelectedItem as TabItem).Content;
        //    //tcTabs.Items.MoveCurrentToPosition(tcTabs.SelectedIndex);
        //    tcTabs.Items.RemoveAt(tcTabs.SelectedIndex);
        //    tcTabs.Items.Insert(1, Browser);

        //}
    }
}
