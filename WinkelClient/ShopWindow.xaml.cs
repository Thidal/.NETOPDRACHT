using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        string user;
        private object proxy;

        public ShopWindow(string username)
        {
            InitializeComponent();
            //this.listView1.DataContext = CreateDataTable();
            using (WinkelServiceClient proxy = new WinkelServiceClient())
            {
                SaldoLabel.Content = proxy.getSaldo(username);

                foreach (var p in proxy.getProduct())
                {
                    string naam = p.Name;
                    string voorraad = p.Stock;
                    string product = naam + "-" + voorraad;
                    listView1.Items.Add(product);
                }

                foreach (var i in proxy.getInventory(username))
                {
                    string naam = i.Name;
                    InventoryList.Items.Add(naam);
                }

                user = username;
            }

           
        }

        private void Buy_Button(object sender, RoutedEventArgs e)
        {
            using (WinkelServiceClient proxy = new WinkelServiceClient())
            {
                Boolean stock_check = true;

                if (listView1.SelectedItems.Count > 0)
                {
                    var item = listView1.SelectedItems[0];
                    string[] tokens = item.ToString().Split('-');
                    string produ = tokens[0];
                    var product = from i in proxy.getProduct()
                                  where i.Name.Equals(produ) select i;

                    foreach (var p in product)
                        if (p.Stock != "0") {
                            if (proxy.getSaldo(user) > p.Price)
                            {
                                InventoryList.Items.Add(produ);
                                proxy.buy_product(produ, user);

                                listView1.Items.Clear();

                                foreach (var p1 in proxy.getProduct())
                                {
                                    string naam = p1.Name;
                                    string voorraad = p1.Stock;
                                    string prod = naam + "-" + voorraad;
                                    listView1.Items.Add(prod);
                                }
                            }
                            else
                            {
                                MessageBox.Show("You haven't got enough money!");
                            }
                            SaldoLabel.Content = proxy.getSaldo(user);
                        }
                        else
                        {
                            MessageBox.Show("This item is out of stock");
                        }
                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
            }
        }

        DataTable CreateDataTable()
        {
            DataTable tbl = new DataTable("Shopping cart");
            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("Price", typeof(double));
            tbl.Columns.Add("Stock", typeof(string));
                using (WinkelServiceClient shopProxy = new WinkelServiceClient())
                {
                foreach (var p in shopProxy.getProduct())
                {
                    tbl.Rows.Add(p.Name, p.Price, p.Stock);
                }
                }
            return tbl;
        }

        private void Back_Button_click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            using (WinkelServiceClient proxy = new WinkelServiceClient())
            {
                listView1.Items.Clear();

                foreach (var p1 in proxy.getProduct())
                {
                    string naam = p1.Name;
                    string voorraad = p1.Stock;
                    string prod = naam + "-" + voorraad;
                    listView1.Items.Add(prod);
                }
            }
            MessageBox.Show("Products have been updated");
        }
    }
}
