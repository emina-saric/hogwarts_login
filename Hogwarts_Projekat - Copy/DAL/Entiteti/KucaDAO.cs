using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class DAL {
        public class KucaDAO : IDaoCrud<Kuca>
        {
            protected MySqlCommand c;

            public static string _host = "localhost", _db = "hogwarts", _user = "root", _pass = "";
            static string df = "yyyy-MM-dd HH:mm:ss";

            public long create(Kuca entity)
            {
                try
                {
                    c = new MySqlCommand("insert into kuca values ('" + entity.Ime_kuce + "','" + entity.Bodovi + ","
                        + entity.Id_profesor + "," + entity.Broj_ucenika + "')", con);
                    c.ExecuteNonQuery();
                    return c.LastInsertedId;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public Kuca read(Kuca entity)
            {
                c = new MySqlCommand("select * from kuca where id_kuca=" + entity.Id_kuca +" and ime=" + entity.Ime_kuce + " and bodovi=" + entity.Bodovi + " and id_prof=" + entity.Id_profesor
                    + " and broj_uc=" + entity.Broj_ucenika + ";");
                MySqlDataReader mr = c.ExecuteReader();
                if (mr.Read())
                    return new Kuca(mr.GetInt32("id_kuca"),mr.GetString("ime"), mr.GetInt32("bodovi"),mr.GetInt32("id_prof"), mr.GetInt32("broj_uc"));
                else
                    return null;
            }

            public Kuca update(Kuca entity)
            {
                c = new MySqlCommand("update kuca set bodovi=" + entity.Bodovi + ", id_prof=" + entity.Id_profesor
                 + ", broj_uc=" + entity.Broj_ucenika + "where ime=" + entity.Ime_kuce + ";");
                c.ExecuteNonQuery();
                return read(entity);
            }

            public void delete(Kuca entity)
            {
                c = new MySqlCommand("delete kuca where id_kuca=" + entity.Id_kuca + " and ime=" + entity.Ime_kuce + " and bodovi=" + entity.Bodovi + " and id_prof=" + entity.Id_profesor
                    + " and broj_uc=" + entity.Broj_ucenika + ";");
                c.ExecuteNonQuery();
            }

            public Kuca getById(int id)
            {
                try
                {
                    string connectionString = "server=localhost;user=" + _user + ";pwd=" + _pass + ";database=" + _db;
                    con = new MySqlConnection(connectionString);
                    con.Open();
                    c = new MySqlCommand("select * from kuca where id_kuca='" + id + "';",con);
                    MySqlDataReader mr = c.ExecuteReader();
                    if (mr.Read())
                        return new Kuca(mr.GetInt32("id_kuca"), mr.GetString("ime"), mr.GetInt32("bodovi"), mr.GetInt32("id_prof"), mr.GetInt32("broj_uc"));
                    else
                        return null;
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

            public List<Kuca> getAll()
            {
                try
                {
                    c = new MySqlCommand("select * from kuca", con);
                    MySqlDataReader mr = c.ExecuteReader();
                    List<Kuca> _kuce = new List<Kuca>();
                    while (mr.Read())
                        _kuce.Add(new Kuca(mr.GetInt32("id_kuca"), mr.GetString("ime"), mr.GetInt32("bodovi"), mr.GetInt32("id_prof"), mr.GetInt32("broj_uc")));
                    return _kuce;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public List<Kuca> getByExample(string name, string value)
            {
                try
                {
                    c = new MySqlCommand("select * from kuca where ime=" + name , con);
                    MySqlDataReader mr = c.ExecuteReader();
                    List<Kuca> _kuce = new List<Kuca>();
                    while (mr.Read())
                        _kuce.Add(new Kuca(mr.GetInt32("id_kuca"), mr.GetString("ime"), mr.GetInt32("bodovi"), mr.GetInt32("id_prof"), mr.GetInt32("broj_uc")));
                    return _kuce;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            public Kuca getByName(string name) {
                try
                {
               
                    c = new MySqlCommand("select * from kuca where ime= '" + name + "'", con);
                    MySqlDataReader mr = c.ExecuteReader();
                    List<Kuca> _kuce = new List<Kuca>();
                    if (mr.Read()) return new Kuca(mr.GetInt32("id_kuca"), mr.GetString("ime"), mr.GetInt32("bodovi"), mr.GetInt32("id_prof"), mr.GetInt32("broj_uc"));
                    return null;
                }
                catch (Exception e)
                { throw e; }
                /*finally
                {
                    con.Close();
                }*/
            }
        }
        }
}
