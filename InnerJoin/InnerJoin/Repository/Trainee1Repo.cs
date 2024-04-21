using InnerJoin.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace InnerJoin.Repository
{
    public class Trainee1Repo
    {
        private SqlConnection con;
        private void Connection()
        {
            string str = ConfigurationManager.ConnectionStrings["dbconnection"].ToString();
            con = new SqlConnection(str);
        }
        public bool AddTrainee1(Trainee1Model traineeModel)
        {
            Connection();
            SqlCommand com = new SqlCommand("AddTrainne1Data", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("Address", traineeModel.Address);
            com.Parameters.AddWithValue("EnrollNo", traineeModel.EnrollNo);
            com.Parameters.AddWithValue("Department", traineeModel.Department);  
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
        public List<Trainee1Model> GetAllTrainee1Data()
        {
            Connection();
            List<Trainee1Model> traineeList1 = new List<Trainee1Model>();
            SqlCommand com = new SqlCommand("GetTrainee1Data", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                traineeList1.Add(
                    new Trainee1Model
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Address = Convert.ToString(dr["Address"]),
                        EnrollNo = Convert.ToString(dr["EnrollNo"]),
                        Department = Convert.ToString(dr["Department"])
                    }
                    );
            }
            return traineeList1;
        }
        public List<MergeModel> GetAllTraineeMergeData()
        {
            Connection();
            List<MergeModel> mergeList = new List<MergeModel>();
          
            SqlCommand com = new SqlCommand("CombineData", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                mergeList.Add(
                    new MergeModel
                    {    
                        Name = Convert.ToString(dr["Name"]),                    
                        Email = Convert.ToString(dr["Email"]),
                        Password = Convert.ToString(dr["Password"]),
                        Address = Convert.ToString(dr["Address"]),
                        EnrollNo = Convert.ToString(dr["EnrollNo"]),
                        Department = Convert.ToString(dr["Department"])
                    }
                    );
            }
            return mergeList;
        }
    }
}