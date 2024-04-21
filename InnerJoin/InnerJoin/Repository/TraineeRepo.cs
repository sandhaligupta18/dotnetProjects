using InnerJoin.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InnerJoin.Repository
{
    public class TraineeRepo
    {

        private SqlConnection con;
        private void Connection()
        {
            string str = ConfigurationManager.ConnectionStrings["dbconnection"].ToString();
            con = new SqlConnection(str);
        
        }
        public bool AddTrainee(TraineeModel traineeModel)
        {
            Connection();
            SqlCommand com = new SqlCommand("AddTrainneData", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("Name", traineeModel.Name);
            com.Parameters.AddWithValue("Age", traineeModel.Name);
            com.Parameters.AddWithValue("Email", traineeModel.Email);
            com.Parameters.AddWithValue("Password", traineeModel.Password);
            com.Parameters.AddWithValue("ConfirmPassword", traineeModel.ConfirmPassword);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if(i>= 1)
            {
                return true;
            }
            return false;
        }

        public List<TraineeModel> GetAllTraineeData()
        {
            Connection();
            List <TraineeModel> traineeList = new List<TraineeModel>();
            SqlCommand com = new SqlCommand("GetTraineeData", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sdr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            sdr.Fill(dt);
            con.Close();

            foreach (DataRow  dr in dt.Rows)
            {
                traineeList.Add(
                    new TraineeModel
                    {
                      Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Age = Convert.ToString(dr["Age"]),
                        Email = Convert.ToString(dr["Email"]),
                        Password = Convert.ToString(dr["Password"]),
                        ConfirmPassword = Convert.ToString(dr["ConfirmPassword"])
                    }

                    );
            }
            return traineeList;
        }
    }
}