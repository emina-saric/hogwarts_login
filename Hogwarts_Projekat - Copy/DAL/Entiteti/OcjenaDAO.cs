using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class DAL
    {
        public class OcjenaDAO 
        {
            protected MySqlCommand c;
            public static string _host = "localhost", _db = "hogwarts", _user = "root", _pass = "";

            public List<Ocjena> PretraziPoUceniku(int Ucenik_id)
            { 
                try{
                string connectionString = "server=localhost;user=" + _user + ";pwd=" + _pass + ";database=" + _db;
                con = new MySqlConnection(connectionString);
                con.Open();
                List<Ocjena> _ocjene = new List<Ocjena>();
                c = new MySqlCommand("select * from ocjena where id_ucenik='" + Ucenik_id + "';",con);
                MySqlDataReader mr = c.ExecuteReader();
                while(mr.Read())
                   _ocjene.Add(new Ocjena(mr.GetInt32("id_ocjena"),mr.GetInt32("ocjena"),mr.GetBoolean("polagao_ispit"),mr.GetBoolean("polozio"),mr.GetInt32("minusi"),mr.GetInt32("bodovi"),mr.GetInt32("id_ucenik"),mr.GetInt32("id_predmet")));
                return _ocjene;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    con.Close();
                }  
             }
            public List<Ocjena> PretraziPoPredmetu(int Predmet_id)
            {
                try
                {
                    string connectionString = "server=localhost;user=" + _user + ";pwd=" + _pass + ";database=" + _db;
                    con = new MySqlConnection(connectionString);
                    con.Open();
                    List<Ocjena> _ocjene = new List<Ocjena>();
                    c = new MySqlCommand("select * from ocjena where id_predmet='" + Predmet_id + "';", con);
                    MySqlDataReader mr = c.ExecuteReader();
                    while (mr.Read())
                        _ocjene.Add(new Ocjena(mr.GetInt32("id_ocjena"), mr.GetInt32("ocjena"), mr.GetBoolean("polagao_ispit"), mr.GetBoolean("polozio"), mr.GetInt32("minusi"), mr.GetInt32("bodovi"), mr.GetInt32("id_ucenik"), mr.GetInt32("id_predmet")));
                    return _ocjene;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
  
            
            }
        }
    
}
