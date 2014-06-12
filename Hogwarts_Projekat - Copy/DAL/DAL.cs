

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DAL
{
    public partial class DAL
    {
        private string host, db = "hogwarts", user = "root", pass = "";
        private string _host = "localhost", _db = "hna", _user = "root", _pass = "";
        private static MySqlConnection con = null;

        private static DAL instanca = null;
        public static DAL Instanca
        {
            get { return (instanca == null) ? instanca = new DAL() : instanca; }
        }
        private DAL() { kreirajKonekciju(); }
        ~DAL() { terminirajKonekciju(); }

        public DAOFactory getDAO // mozemo napraviti i getDAO(tipBaze) koja vraca npr DAOMySqlFactory i sl. zavisi od potrebe
        {
            get { return DAOFactory.Instanca; }
        }

        public void kreirajKonekciju(string host, string db, string user, string pass)
        {

            if (con != null) return;
            string connectionString = "server=localhost;user=" + user + ";pwd=" + pass + ";database=" + db;
            con = new MySqlConnection(connectionString);

            try
            {
                con.Open();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void kreirajKonekciju()
        {
            if (con != null) return;

            string connectionString = "server=localhost;user=" + user + ";pwd=" + pass + ";database=" + db;
            con = new MySqlConnection(connectionString);

            try
            {
                con.Open();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void terminirajKonekciju()
        {
            try
            {
                if (con != null) con.Close();
            }
            catch (Exception e) { throw e; }
        }
    }
}

