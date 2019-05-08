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
            for (int i = 0; i < tabs.Items.Count; i++)
            {
                if (((tabs.Items[i] as TabItem).Header as StackPanel) != null &&
                    ((((tabs.Items[i] as TabItem).Header as StackPanel).Children[1] as Button) == (sender as Button)))
                {
                    tabs.Items.Remove(tabs.Items[i]);
                }
            }
        }

        private void AddTab(object sender, RoutedEventArgs e)
        {
            StackPanel stackPanel = new StackPanel {
                Orientation = Orientation.Horizontal
            };
            stackPanel.Children.Add(new Label {
                Content = "Новая страница"
            });
            Button button = new Button();
            button.Content = "x";
            button.Click += CloseTab;

            stackPanel.Children.Add(button);
            TabItem tabItem = new TabItem()
            {
                Header = stackPanel
            };
            tabItem.Content = new System.Windows.Controls.WebBrowser {
                Source = new Uri(url)
            };
            tabs.Items.Insert(tabs.Items.Count - 1, tabItem);
            tabs.SelectedItem = tabs.Items[tabs.Items.Count - 2];
        }
    }
}
