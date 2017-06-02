using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WinkelClient.WinkelService;


namespace WinkelClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            using (WinkelServiceClient proxy = new WinkelServiceClient())
            {
                string username = UserText.Text;
                string password = PassText.Text;
                if(proxy.Login(username, password))
                {
                    ShopWindow window = new ShopWindow();
                    window.Show();
                    Close();
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow window = new RegisterWindow();
            window.Show();
            Close();
        }
    }
}
