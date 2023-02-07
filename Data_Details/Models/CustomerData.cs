using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Details.Models
{
    public class CustomerData
    {
        public List<CustomerData> customerDataModel { get; set; }
    }
    public class customerDataModel
    {
        public int id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string gender { get; set; }
        public string Product_name { get; set; }
        public string Price { get; set; }

    }
}
