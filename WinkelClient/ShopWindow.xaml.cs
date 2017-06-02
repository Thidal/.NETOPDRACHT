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
    /// Interaction logic for ShopWindow.xaml
    /// </summary>
    public partial class ShopWindow : Window
    {
        public ShopWindow()
        {

            InitializeComponent();
            using (WinkelServiceClient proxy = new WinkelServiceClient())
            {
                foreach(var p in proxy.getProduct()){
                    this.ProductList.Items.Add(p);
                }

            }
        }

       
    }
}
