using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WinkelServiceLibrary2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WinkelService" in both code and config file together.
    public class WinkelService : IWinkelService
    {
        public Boolean Login(string username, string password)
        {
            
            using (WinkelModelContainer wmc = new WinkelModelContainer())
            {
                var login_query = from c in wmc.CustomerEntitySet
                                  where c.Name.Equals(username)
                                  select c.Password;

                

                foreach(var i in login_query)
                {
                    if (password.Equals(i))
                    {
                        Console.WriteLine("Customer has been logged in");
                        return true;
                    }
                }
                Console.WriteLine("Login has been a failure");
                return false;
            }
        }

        public double getSaldo(string u)
        {
            double muney = 0;
            using (WinkelModelContainer wmc = new WinkelModelContainer())
            {
                
                var saldo_query = from s in wmc.CustomerEntitySet
                                  where s.Name.Equals(u)
                                  select s.Money;

                

                foreach (var s in saldo_query)
                {
                    muney += s;

                }
               
                return muney;
            }
        }

        public String ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public void Register(string username)
        {
            string naam = "";
            if (username != "" || username != null)
            {     
                using (WinkelModelContainer wmc = new WinkelModelContainer())
                {
                    var check_query = from klant in wmc.CustomerEntitySet
                                      where klant.Name.Equals(username)
                                      select klant;

                    foreach(var klant in check_query)
                    {
                        naam = klant.Name;
                    }

                    if (naam.Equals(username))
                    {
                        Console.WriteLine("This username already exists");
                    }
                    else
                    {
                        string password = ReverseString(username);
                        CustomerEntity c = new CustomerEntity();
                        c.Name = username;
                        c.Password = password;
                        c.Money = 100;
                        InventoryEntity i = new InventoryEntity();
                        c.InventoryEntityId = i.Id;
                        wmc.InventoryEntitySet.Add(i);
                        wmc.CustomerEntitySet.Add(c);
                        wmc.SaveChanges();
                        Console.WriteLine("Customer has been added");  
                    }

                    
                }

            }
            else
            {
                Console.WriteLine("Something went wrong while adding the new customer");
            }
        }

        public Product TranslateProductEntityToProduct(ProductEntity pe)
        {
            Product p = new Product();
            p.Id = pe.Id;
            p.Name = pe.Name;
            p.Price = pe.Price;
            p.Stock = pe.Stock;
            return p;
        }

        public List<Product> getProduct()
        {
            using (WinkelModelContainer wmc = new WinkelModelContainer())
            {
                List<Product> producten = new List<Product>();
                string number = "0";
                var product_query = from p in wmc.ProductEntitySet
                                    select p;

                foreach(var p in product_query)
                {
                    if (!p.Stock.Equals(number))
                    {
                        producten.Add(TranslateProductEntityToProduct(p));
                    }
                    
                    
                }
                return producten;
            }
        }

        public void buy_product(string p, string u)
        {
            double prijs = 0;
            double saldo = 0;
            int id = 0;
            int id2 = 0;
            string[] tokens = p.Split('-');
            Console.Write(tokens[0]);
            using (WinkelModelContainer wmc = new WinkelModelContainer())
            {
                var product_query = from product in wmc.ProductEntitySet
                            where product.Name.Equals(p)
                            select product;

                var saldo_query = from klant in wmc.CustomerEntitySet
                                  where klant.Name.Equals(u)
                                  select klant;


                foreach(var product in product_query)
                {
                    prijs += product.Price;
                    id += product.Id;
                    string stock = product.Stock;
                    int stock_int = Convert.ToInt32(stock);
                    stock_int -= 1;
                    stock = Convert.ToString(stock_int);
                    product.Stock = stock;
                }

                foreach (var klant in saldo_query)
                {
                    klant.Money -= prijs;
                    saldo += klant.Money;
                    id2 += klant.InventoryEntityId;
                }

                ProductInventoryEntity PIE = new ProductInventoryEntity();
                PIE.ProductEntityId = id;
                PIE.InventoryEntityId = id2;

                wmc.ProductInventoryEntitySet.Add(PIE);

                wmc.SaveChanges();
                Console.WriteLine("Product has been bought");

            }
        }

        public List<Product> getInventory(string username)
        {
            int inv_id = 0;
            int pro_id = 0;
            using (WinkelModelContainer wmc = new WinkelModelContainer())
            {

                List<Product> inventory = new List<Product>();
                var query2 = from u in wmc.CustomerEntitySet
                             where u.Name.Equals(username)
                             select u;

                foreach (var w in query2)
                {
                    inv_id = w.InventoryEntityId;
                    var product_query = from p in wmc.ProductInventoryEntitySet
                                        where p.InventoryEntityId.Equals(inv_id)
                                        select p;

                    foreach (var p in product_query)
                    {
                        pro_id = p.ProductEntityId;
                        var query3 = from d in wmc.ProductEntitySet
                                     where d.Id.Equals(pro_id)
                                     select d;

                        foreach (var g in query3)
                        {
                            inventory.Add(TranslateProductEntityToProduct(g));
                        }              
                    }   
                }
                return inventory;
            }
        }



        //public IEnumerable<ProductEntity> getInventory()
        //{
        //using (WinkelModelContainer wmc = new WinkelModelContainer())
        //{

        //}
        //}
    }
}
