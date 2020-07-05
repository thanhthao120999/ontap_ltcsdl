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
    public class De6Rep : GenericRep<NorthwindContext, Products>
    {
        public object Cau1A_getproductbykeyword(string key, int page, int size)
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
                cmd.CommandText = "getproductbykeyword"; // cung ten voi store procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@key", key); // cu phap dua tham so vao
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
                            ProductID = row["ProductID"], // ten cac cot phai trung voi ten cot trong table
                           
                            CategoryName = row["CategoryName"],
                            ProductName = row["ProductName"],
                            UnitPrice = row["UnitPrice"],
                            
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
        public object Cau1b_getProductbyCategoryID(int CategoryID, int page, int size)
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
                cmd.CommandText = "getProductbyCategoryID"; // cung ten voi store procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID); // cu phap dua tham so vao
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
                            ProductID = row["ProductID"], // ten cac cot phai trung voi ten cot trong table

                            CategoryName = row["CategoryName"],
                            ProductName = row["ProductName"],
                            UnitPrice = row["UnitPrice"],

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
        public object Cau1c_getProductbyPriceMinMax(double MinPrice, double MaxPrice, int page, int size)
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
                cmd.CommandText = "getProductbyPriceMinMax"; // cung ten voi store procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MinPrice", MinPrice); // cu phap dua tham so vao
                cmd.Parameters.AddWithValue("@MaxPrice", MaxPrice);
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
                            ProductID = row["ProductID"], // ten cac cot phai trung voi ten cot trong table

                           
                            ProductName = row["ProductName"],
                            UnitPrice = row["UnitPrice"],

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
    }
}
