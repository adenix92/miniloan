using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace minpipWebApp.Models
{
    public class elo_function_class
    {
        public string OrderID()
        {
            var rand = new Random();
            var orderId = rand.Next() * 1;
          string y = DateTime.Parse(DateTime.Now.ToString()).Year.ToString();
            return "ORD/" + y + "/" + orderId.ToString().Substring(0, 5);
        }
    }
}