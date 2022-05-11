using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;



internal class Product
{
        public int ProductID { get; set; }
        public int ProductName { get; set; }
        public Category Category { get; set; }
}
