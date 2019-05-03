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

namespace WebBrowser
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string url = "https://www.google.com";
        public MainWindow()
        {
            InitializeComponent();
            (tabs.Items[0] as TabItem).Content = new System.Windows.Controls.WebBrowser
            {
                Source = new Uri(url),
            };
        }

        private void CloseTab(object sender, RoutedEventArgs e)
        {
            tabs.Items.Remove(currentTab);
        }

        private void AddTab(object sender, RoutedEventArgs e)
        {
            StackPanel stackPanel = new StackPanel {
                Orientation = Orientation.Vertical
            };
            stackPanel.Children.Add(new Label {
                Content = "Новая страница"
            });
            stackPanel.Children.Add(new Button
            {
                Content = "x"
            });
            TabItem tabItem = new TabItem()
            {
                Header = new StackPanel
                {
                    
                }
            };
            tabs.Items.Insert(tabs.Items.Count - 1, currentTab);
            tabs.SelectedItem = tabs.Items[tabs.Items.Count - 1];

            (tabs.Items[tabs.Items.Count - 1] as TabItem).Content = new System.Windows.Controls.WebBrowser
            {
                Source = new Uri(url),
            };
        }
    }
}
