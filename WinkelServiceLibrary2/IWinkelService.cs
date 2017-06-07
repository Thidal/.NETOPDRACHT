using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WinkelServiceLibrary2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWinkelService" in both code and config file together.
    [ServiceContract]
    public interface IWinkelService
    {
        [OperationContract]
        Boolean Login(string username, string password);

        [OperationContract]
        void Register(string username);

        [OperationContract]
        List<Product> getProduct();

        [OperationContract]
        double getSaldo(string u);

        [OperationContract]
        void buy_product(string p, string u);

        [OperationContract]
        List<Product> getInventory(string username);

        [OperationContract]
        string ReverseString(string s);

        
    }

    [DataContract]
    public class Customer
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public double Money { get; set; }
        [DataMember]
        public int InventoryEntityId { get; set; }
    }

    [DataContract]
    public class Inventory
    {
        [DataMember]
        public int Id { get; set; }
    }

    [DataContract]
    public class Product
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public string Stock { get; set; }
    }

    public class ProductInventory
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int InventoryEntityId { get; set; }
        [DataMember]
        public int ProductEntityId { get; set; }
    }


}
