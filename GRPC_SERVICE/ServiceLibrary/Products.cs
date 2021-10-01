using System;
using System.Collections.Generic;

namespace ServiceLibrary
{
    public class Products
    {
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string TouchScreen { get; set; }
        public string WearableMonitor { get; set; }
        public string AlarmManagement { get; set; }
        public float ScreenSize { get; set; }
        public string YourProduct { get; set; }
        public void  FindProduct(Products sp)
        {
            Products IntellivueMX40 = new Products()
            {
                ProductName = "Intellivue",
                ProductNumber = "MX40",
                TouchScreen = "YES",
                WearableMonitor = "YES",
                AlarmManagement = "YES",
                ScreenSize = 30.5f
            };
            Products Intellivuex3 = new Products()
            {
                ProductName = "Intellivue",
                ProductNumber = "X3",
                TouchScreen = "YES",
                WearableMonitor = "NO",
                AlarmManagement = "YES",
                ScreenSize = 15.5f
            };
            Products IntellivueMX450 = new Products()
            {
                ProductName = "Intellivue",
                ProductNumber = "MX450",
                TouchScreen = "YES",
                WearableMonitor = "NO",
                AlarmManagement = "YES",
                ScreenSize = 30.48f
            };
            Products IntellivueMP5 = new Products()
            {
                ProductName = "Intellivue",
                ProductNumber = "MP5",
                TouchScreen = "YES",
                WearableMonitor = "NO",
                AlarmManagement = "YES",
                ScreenSize = 30.734f
            };
            List<Products> productList = new List<Products>();
            productList.AddRange(new List<Products>() { IntellivueMX40, Intellivuex3, IntellivueMX450, IntellivueMP5 });          
            bool flag = false;          
            foreach (var p in productList)
            {
                if (sp.ScreenSize == p.ScreenSize && sp.AlarmManagement.Equals(p.AlarmManagement) && sp.TouchScreen.Equals(p.TouchScreen) && sp.WearableMonitor.Equals(p.WearableMonitor))
                {                 
                    sp.YourProduct = "Superb!!! you can buy " + p.ProductName + p.ProductNumber;
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                sp.YourProduct = "Sorry there is no products with this features!!!!!";
            }            
        }
    }
}
