using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using RestSharp;
using Sms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.SendSms
{
    public class SendSms
    {
        private static IConfiguration _iconfiguration;
        public string Send(string smsMessage, string phoneNumber, int RecordId)
        {

            //updateSmsStatus(RecordId);
            String Baseurl = "http://apidocs.speedamobile.com/";
            string api_id = "yourapiid";
            string api_password = "yourapipassword";
            string sms_type = "P";
            string encoding = "T";
            string sender_id = "speedamobile";
            string phone_number = phoneNumber;// "256700459182";
            string message = smsMessage;


            var query = new Dictionary<string, string>()
            {
                ["api_id"] = api_id,
                ["api_password"] = api_password,
                ["sms_type"] = sms_type,
                ["encoding"] = encoding,
                ["sender_id"] = sender_id,
                ["phonenumber"] = phone_number,
                ["textmessage"] = message,
            };

            var url = QueryHelpers.AddQueryString(Baseurl + "api/SendSMS?", query);
            var client = new RestClient(url);
            var response = client.Execute(new RestRequest());
            if (response.IsSuccessful)
            {
                updateSmsStatus(RecordId);
                //Console.WriteLine(JsonConvert.DeserializeObject(response.Content));
            }
            return response.Content;
        }
        private static void updateSmsStatus(int RecordId)
        {
            var smsDAL = new SmsDal(_iconfiguration);
            smsDAL.UpdateSms(RecordId);
        }
    }
}
