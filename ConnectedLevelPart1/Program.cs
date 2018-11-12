using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ConnectedLevelPart1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                //string isTest = ConfigurationManager.AppSettings["isTest"].ToString();
                string connectionString = ConfigurationManager
                    .ConnectionStrings["UserConnectionString"].ConnectionString;

                sqlConnection.ConnectionString = connectionString;

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                //sqlCommand = sqlConnection.CreateCommand(); вариант создания команды
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select * from users";
                //sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    string login = reader["login"].ToString();
                    string password = reader["password"].ToString();
                    //DateTime? updateDate = null;
                    //if(reader["updateDateTime"] != null)
                    //{
                    //    updateDate = DateTime.Parse(reader["updateDateTime"].ToString());
                    //}
                }
                reader.Close();

                //SqlCommand insertCommand = new SqlCommand();
                //insertCommand.Connection = sqlConnection;
                //insertCommand.CommandText = "insert into users values (4, 'user1', 'pass', null)";
                //insertCommand.ExecuteNonQuery();

                //SqlCommand createTableCommand = new SqlCommand();
                //createTableCommand.Connection = sqlConnection;
                //createTableCommand.CommandText = "create table Employees(ID int NOT NULL CONSTRAINT PK_Emplyees PRIMARY KEY," +
                //    "Name nvarchar(MAX) NOT NULL," +
                //    "Email nvarchar(MAX)," +
                //    "Position nvarchar(MAX))";
                //createTableCommand.ExecuteNonQuery();

                //SqlCommand createDataBaseCommand = new SqlCommand();
                //createDataBaseCommand.Connection = sqlConnection;
                //createDataBaseCommand.CommandText = ("CREATE DATABASE TEST_DB");
                //createDataBaseCommand.ExecuteNonQuery();

                SqlCommand createDataBaseCommand = new SqlCommand();
                createDataBaseCommand.Connection = sqlConnection;
                createDataBaseCommand.CommandText = ("USE TEST_DB");
                createDataBaseCommand.ExecuteNonQuery();

                SqlCommand createTableCommand = new SqlCommand();
                createTableCommand.Connection = sqlConnection;
                createTableCommand.CommandText = "create table Employees(ID int NOT NULL CONSTRAINT PK_Emplyees PRIMARY KEY," +
                    "Name nvarchar(MAX) NOT NULL," +
                    "Email nvarchar(MAX)," +
                    "Position nvarchar(MAX))";
                createTableCommand.ExecuteNonQuery();

            }

        }
    }
}
