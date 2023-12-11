using System;
using WebAppDotNetCoreCrudNew.Models;

namespace WebAppDotNetCoreCrudNew
{
    internal class Customer
    {
        public object[] CustomerId { get;  set; }
        public int Firstname { get;  set; }
        public object Lastname { get;  set; }
        public object Country_code { get;  set; }
        public object Gender { get;  set; }
        public object Balance { get; set; }
        public object Phone_Number { get; set; }
        public object Email { get; set; }
        public object ID { get; internal set; }

    }
}