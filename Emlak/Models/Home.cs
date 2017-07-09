using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Emlak.Models
{
    public class Home:IDisposable
    {
        SqlConnection con;
        public String Area { get; set; }
        public int BedRooms { get; set; }
        public int BathRooms { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Address { get; set; }
        public int Price { get; set; }

        public  List<Home> getAllHomes()
        {
            List<Home> list = new List<Home>();
            Home home = new Home();
            con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DAL"].ConnectionString);
            con.Open();
            String sqlQuery = String.Format("Select * from HouseForSell_DB");
            SqlCommand com = new SqlCommand(sqlQuery,con);
            SqlDataReader sda= com.ExecuteReader();
            while(sda.Read()){
                home.BathRooms = sda.GetInt32(3);
                home.BedRooms = sda.GetInt32(2);
                home.Area = sda.GetString(1);
                home.State = sda.GetString(5);
                home.City = sda.GetString(4);
                home.Address = sda.GetString(6);
                home.Price = sda.GetInt32(7);
                list.Add(home);
            }
            return list; 
        }
        public void Dispose()
        {
            if (con != null && con.State == System.Data.ConnectionState.Open)
                con.Close();
        }

    }
}