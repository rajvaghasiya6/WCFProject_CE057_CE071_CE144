using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace hotelbooking
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        
        public bool addUser(string name, string email, string mobileno, string password)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            try
            {
                con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\SEM-6\hotelbooking\hotelbooking\Database1.mdf;Integrated Security=True";
                using (con)
                {
                    string command = "INSERT INTO hotelusers(name,email,mobileno,password)VALUES(@name,@email,@mobileno,@password)";
                    cmd = new SqlCommand(command, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@mobileno", mobileno);
                    cmd.Parameters.AddWithValue("@password", password);
                    int res = cmd.ExecuteNonQuery();
                    if (res == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                
            }
            catch (Exception err)
            {
                return false;
            }
            finally
            {
                if (con != null)
                {
                    con.Dispose();
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }
        }
        public bool addHotel(string hotelname, string address, string city, string rating, string rent)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            try
            {
                con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\SEM-6\hotelbooking\hotelbooking\Database1.mdf;Integrated Security=True";
                using (con)
                {
                    string command = "INSERT INTO hotels(hotelname,address,city,rating,rent)VALUES(@hotelname,@address,@city,@rating,@rent)";
                    cmd = new SqlCommand(command, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@hotelname", hotelname);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@rating", rating);
                    cmd.Parameters.AddWithValue("@rent", rent);
                    int res = cmd.ExecuteNonQuery();
                    if (res == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception err)
            {
                return false;
            }
            finally
            {
                if (con != null)
                {
                    con.Dispose();
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }
        }
        public bool checkUser(string email, string password)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            try
            {
                con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\SEM-6\hotelbooking\hotelbooking\Database1.mdf;Integrated Security=True";
                using (con)
                {
                    string command = "select * from hotelusers where email = '" + email + "' and password = '" + password + "'";
                    cmd = new SqlCommand(command, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    rdr.Close();
                }
            }
            catch (Exception err)
            {
                return false;
            }
            finally
            {
                if (con != null)
                {
                    con.Dispose();
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }
        }

        public List<hotel> getHotels()
        {
            List<hotel> hotels = new List<hotel>();
            hotel h;
            SqlConnection con = null;
            SqlCommand cmd = null;
            try
            {
                con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\SEM-6\hotelbooking\hotelbooking\Database1.mdf;Integrated Security=True";
                using (con)
                {
                    string command = "select * from hotels";
                    cmd = new SqlCommand(command, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        h = new hotel();
                        h.hotelname = rdr["hotelname"].ToString();
                        h.address = rdr["address"].ToString();
                        h.city = rdr["city"].ToString();
                        h.rating = rdr["rating"].ToString();
                        h.rent = rdr["rent"].ToString();
                        hotels.Add(h);
                    }
                    rdr.Close();
                    return hotels;
                }
            }
            catch (Exception err)
            {
                return hotels;
            }
            finally
            {
                if (con != null)
                {
                    con.Dispose();
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }
        }
    }
}
