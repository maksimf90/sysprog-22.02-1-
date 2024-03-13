using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sysprog_22._02_1_
{
    public class Product
    {

       
        public string name;
        public string price;
        public  string image;
        public string vendor;
        
        public Product(string vendor, string name, string price, string image)
        {
            
            this.name = name;
            this.price = price;
            this.image = image;
            this.vendor = vendor;
        }
        
    }
}
