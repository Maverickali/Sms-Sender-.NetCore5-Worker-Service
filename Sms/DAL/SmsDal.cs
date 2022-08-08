using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sms.Models;

namespace Sms.DAL
{
    public class SmsDal
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public SmsDal(IConfiguration configuration)
        {

            this._configuration = configuration;
            this._connectionString = "Data Source=127.0.0.1; Initial Catalog=DYNAMICSSMSONE;Integrated Security = True";
            //"Data Source=127.0.0.1; Initial Catalog=DYNAMICSSMSONE;User ID=sa;Password=triskelion;";
            //"Data Source=NEXUS;Initial Catalog = DYNAMICSSMSONE;Integrated Security = True";
            //this._configuration.GetConnectionString("Default");
        }

        public List<Smstext> GetAllSms()
        {
            var lstSms = new List<Smstext>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("select * from [dbo].[smstext] Where status=0", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        lstSms.Add(new Smstext
                        {
                            RecordId = rdr.GetInt32("RecordId"),
                            status = rdr.GetString("status"),
                            phone = rdr.GetString("phone"),
                            smstext = rdr.GetString("smstext"),
                            lupd_datetime = rdr.GetDateTime("lupd_datetime")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                Console.WriteLine("DataError", ex.Message);
            }
            return lstSms;
        }

        internal void UpdateSms(int recordId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE smstext  SET status = 1, lupd_datetime=@lupd_datetime Where RecordId=@recordId", con);
                    cmd.Parameters.AddWithValue("@recordId", recordId);
                    cmd.Parameters.AddWithValue("@lupd_datetime", DateTime.Now.ToString("yyyy-dd-MM hh:mm tt"));
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                Console.WriteLine("DataError", ex.Message);
            }

        }
    }

}
