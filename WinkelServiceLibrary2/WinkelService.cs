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
                    else
                    {
                        Console.WriteLine("Login has been a failure");
                        return false;
                    }
                }
                return true;
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
            if(username != null) {
                
                using (WinkelModelContainer wmc = new WinkelModelContainer())
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
                    Console.WriteLine("Customer has been add");
                }

            }
            
            else
            {
                Console.WriteLine("fout");
            }
        }

        public List<String> getProduct()
        {
            using (WinkelModelContainer wmc = new WinkelModelContainer())
            {
                List<String> producten = new List<String>();
                var product_query = from p in wmc.ProductEntitySet
                                    select p.Name;

                foreach(var p in product_query)
                {
                    producten.Add(p);
                    
                }
                return producten;
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
