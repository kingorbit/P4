using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;


string connection = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Northwind; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

var con = new SqlConnection(connection);

var result = con.Query<Region>("SELECT * FROM Region");

foreach (var item in result)
{
    Console.WriteLine($"{item.RegionID}: {item.RegionDescription}");
}
var RegionToInsert = new Region()
{
    RegionID = 5,
    RegionDescription = "Nowy region"
};
var insertresult = con.Execute("INSERT INTO Region(RegionID, RegionDescription) VALUES(@RegionID, @RegionDescription)",
  RegionToInsert
    );

//var joinresult = con.Query<Product, Category, Product>("SELECT * FROM Prodcts p JOIN Categories c on p.CategoriesID = c.CategoryID",
//    (product, category) =>
//    {
//        product.Category = category;
//        return product;

//    },splitOn: "CategoryID"
//    );

//foreach (var item in joinresult)
//{
//    Console.WriteLine($"{item.ProductName}: {item.Category.CategoryName}");
//}

var parameters = new { Test = "A%" };
var join2 = con.Query<Region, Territories, Region>("SELECT * FROM Region AS r JOIN Territories AS t on r.RegionID = t.RegionID WHERE TerritoryDescription LIKE @Test ",
    (region, territories) =>
    {
        region.Territories = territories;
        return region;
    }, parameters,
    splitOn: "RegionID");
foreach (var item in join2)
{
    Console.WriteLine($"{item.RegionDescription}:{item.Territories.TerritoryDescription}");
}





