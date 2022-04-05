﻿using Dapper;
using System.Data.SqlClient;


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

var joinresult2 = con.Query<Territory, Region, Territory>("SELECT * FROM Territories t JOIN Region r on t.TerritoriesID = r.TerritoriesID",
    (territory, region) =>
    {
        territory.Region = region;
        return territory;
    }, splitOn: "TerritoryID"
    );
foreach(var item in joinresult2)
{
    Console.WriteLine($"{item.Region.RegionID}:{item.TerritoryID}");
}




