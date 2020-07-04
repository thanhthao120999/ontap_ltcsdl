using System;
using System.Collections.Generic;
using System.Text;

namespace LTCSDL.DAL
{
    using LTCSDL.Common.DAL;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class De7Rep : GenericRep<NorthwindContext, Orders>
    {
        // Câu 2 cho 1A
        public object Cau1A_getOrderByEmployeeNameWithPaging(string keyword, int page, int size)
        {
            List<object> res = new List<object>();
            var cnn = (SqlConnection)Context.Database.GetDbConnection();
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet(); // bien ds chua toan bo du lieu duoc tra ve
                var cmd = cnn.CreateCommand();
                cmd.CommandText = "De7_cauA_findOrdersByEmployeeNameWithPaging"; // cung ten voi store procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@keyword", keyword); // cu phap dua tham so vao
                cmd.Parameters.AddWithValue("@page", page);
                cmd.Parameters.AddWithValue("@size", size);
                da.SelectCommand = cmd;
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            STT = row["STT"],
                            OrderID = row["OrderID"], // ten cac cot phai trung voi ten cot trong table
                            EmployeeID = row["EmployeeID"],
                            CustomerID = row["CustomerID"],
                            FirstName = row["FirstName"],
                            LastName = row["LastName"],
                            OrderDate = row["OrderDate"],
                            ShipName = row["ShipName"],
                            ShipAddress = row["ShipAddress"]
                        };
                        res.Add(x);
                    }
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                cnn.Close();
            }
            return res;
        }

        // Câu 2 cho 1B
        public object cau1B_findOrderByCustomerNameWithPaging(string keyword, int page, int size)
        {
            List<object> res = new List<object>();
            var cnn = (SqlConnection)Context.Database.GetDbConnection();
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet(); // bien ds chua toan bo du lieu duoc tra ve
                var cmd = cnn.CreateCommand();
                cmd.CommandText = "De7_cau1b_findOrderByCustomerNameWithPaging"; // cung ten voi store procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@keyword", keyword); // cu phap dua tham so vao
                cmd.Parameters.AddWithValue("@page", page);
                cmd.Parameters.AddWithValue("@size", size);
                da.SelectCommand = cmd;
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            STT = row["STT"],
                            OrderID = row["OrderID"], // ten cac cot phai trung voi ten cot trong table
                            EmployeeID = row["EmployeeID"],
                            CustomerID = row["CustomerID"],
                            CompanyName = row["CompanyName"],
                            ContactName = row["ContactName"],
                            OrderDate = row["OrderDate"],
                            ShipName = row["ShipName"],
                            ShipAddress = row["ShipAddress"]
                        };
                        res.Add(x);
                    }
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                cnn.Close();
            }
            return res;
        }

        // Câu 2 cho 1C
        public object cau1C_findOrderByProductNameWithPaging(string keyword, int page, int size)
        {
            List<object> res = new List<object>();
            var cnn = (SqlConnection)Context.Database.GetDbConnection();
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet(); // bien ds chua toan bo du lieu duoc tra ve
                var cmd = cnn.CreateCommand();
                cmd.CommandText = "De7_cau1C_findOrderByProductNameWithPaging"; // cung ten voi store procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@keyword", keyword); // cu phap dua tham so vao
                cmd.Parameters.AddWithValue("@page", page);
                cmd.Parameters.AddWithValue("@size", size);
                da.SelectCommand = cmd;
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            STT = row["STT"],
                            OrderID = row["OrderID"], // ten cac cot phai trung voi ten cot trong table
                            EmployeeID = row["EmployeeID"],
                            CustomerID = row["CustomerID"],
                            ProductName = row["ProductName"],
                            OrderDate = row["OrderDate"],
                            ShipName = row["ShipName"],
                            ShipAddress = row["ShipAddress"]
                        };
                        res.Add(x);
                    }
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                cnn.Close();
            }
            return res;
        }

        // Câu 3A
        public object Cau3A_findOrderByProductNameWithPaging_LinQ(string keyword, int page, int size)
        {
            var query = Context.Orders.Join(Context.OrderDetails, a => a.OrderId, b => b.OrderId, (a, b) => new
                {
                    a.OrderId,
                    b.ProductId
                }).Join(Context.Products, a => a.ProductId, b => b.ProductId, (a, b) => new
                {
                    a.OrderId,
                    a.ProductId,
                    b.ProductName
                });
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.ProductName.Contains(keyword));
            var offset = (page - 1) * size;
            var total = query.Count();
            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = query.OrderBy(x => x.OrderId).Skip(offset).Take(size).ToList();
            var res = new
            {
                Data = data,
                TotalRecord = total,
                TotalPages = totalPage,
                Page = page,
                Size = size
            };
            return res;
        }
    }
}
