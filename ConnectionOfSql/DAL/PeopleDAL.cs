using ConnectionOfSql.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConnectionOfSql.DAL
{
    public class PeopleDAL
    {
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBcon"].ConnectionString.ToString());



        public List<People> GetPeopleList()
        {
            try
            {
                List<People> people = new List<People>();
                SqlCommand cmd = new SqlCommand("PeopleSP", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "GetPeoplList");
                DataTable dt = new DataTable();
                Con.Open();
                dt.Load(cmd.ExecuteReader());
                if (dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        People Person = new People();
                        Person.Id = Convert.ToInt32(dr["Id"]);
                        Person.Name = Convert.ToString(dr["Name"]);
                        Person.Phone = Convert.ToInt32(dr["Phone"]);
                        Person.Age = Convert.ToInt32(dr["Age"]);
                        Person.Gender = Convert.ToString(dr["Sex"]);
                        people.Add(Person);
                    }
                }
                Con.Close();
                return people;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}