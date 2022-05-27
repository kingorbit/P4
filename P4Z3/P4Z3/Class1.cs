using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;



internal class Region
{
	public int RegionID { get; set; }
	public string RegionDescription { get; set; }
	public Territories Territories { get; set; }
}
