using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace project3
{
    class baglan
    {

        public static string sqlconnection = ConfigurationManager.ConnectionStrings["project3.Properties.Settings.SinemaBiletiConnectionString"].ConnectionString;
    }
}
