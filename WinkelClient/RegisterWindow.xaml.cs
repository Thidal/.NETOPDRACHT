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
using System.Windows.Shapes;
using WinkelClient.WinkelService;

namespace WinkelClient
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Register_OK(object sender, RoutedEventArgs e)
        {
            using (WinkelServiceClient proxy = new WinkelServiceClient())
            {
                string username = UsernameText.Text;
                proxy.Register(username);
            }
        }
    }
}
