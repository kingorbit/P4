using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;


internal class Territory
    {
        public int TerritoryID { get; set; }
        public string TerritoryDescription { get; set; }
        public Region Region { get; set; }
    }

