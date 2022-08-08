using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Models
{
    public class Smstext
    {
        public int SmsId { get; set; }
        [StringLength(15)]
        public char acctnbr { get; set; }
        public DateTime crtd_datetime { get; set; }
        [StringLength(8)] public char crtd_prog { get; set; }
        [StringLength(10)] public char crtd_user { get; set; }
        public DateTime lupd_datetime { get; set; }
        [StringLength(8)] public char lupd_prog { get; set; }
        [StringLength(8)] public char lupd_user { get; set; }
        [StringLength(30)] public string phone { get; set; }
        public int RecordId { get; set; }
        [StringLength(20)] public char Refnbr { get; set; }
        [StringLength(1)] public char smsaction { get; set; }
        [StringLength(160)] public string smstext { get; set; }
        [StringLength(1)] public string status { get; set; }
        public DateTime trandate { get; set; }
        [StringLength(30)] public char User1 { get; set; }
        [StringLength(30)] public char User2 { get; set; }
        public float User3 { get; set; }
        public float User4 { get; set; }
        [StringLength(10)] public char User5 { get; set; }
        [StringLength(10)] public char User6 { get; set; }
        public DateTime User7 { get; set; }
        public DateTime User8 { get; set; }
        [StringLength(45)] public char User9 { get; set; }
        [StringLength(30)] public char User10 { get; set; }

        [Timestamp]
        public byte[] tstamp { get; set; }

        public Smstext()
        {

        }
    }
}
