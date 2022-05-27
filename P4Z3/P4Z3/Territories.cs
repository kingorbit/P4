using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;


internal class Territories
{
    public int TerritoryID { get; set; }
    public int TerritoryDescription { get; set; }
    public int RegionID { get; set; }
    //public Region Region { get; set; }
}
