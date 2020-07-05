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
    public class De5Rep: GenericRep<NorthwindContext, Employees>
    {
        public object Cau1C_searchemployeebykeyword(string keyword, int page, int size)
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
                cmd.CommandText = "searchemployeebykeyword"; // cung ten voi store procedure
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
                            EmployeeID = row["EmployeeID"], // ten cac cot phai trung voi ten cot trong table

                            LastName = row["LastName"],
                            FirstName = row["FirstName"],
                            Title = row["Title"],

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
