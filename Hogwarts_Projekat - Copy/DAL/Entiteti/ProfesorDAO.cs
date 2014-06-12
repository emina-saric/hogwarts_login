using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL
{
    public partial class DAL
    {
        public class ProfesorDAO : IDaoCrud<Profesor>
        {
            protected MySqlCommand c;
            public static string _host = "localhost", _db = "hogwarts", _user = "root", _pass = "";
            static string df = "yyyy-MM-dd HH:mm:ss";

            public long create(Profesor entity)
            {

                try
                {
                    string connectionString = "server=localhost;user=" + _user + ";pwd=" + _pass + ";database=" + _db; con = new MySqlConnection(connectionString);
                    con.Open();
                    c = new MySqlCommand("insert into profesor(ime,prezime,dat_rodj,username,pass,pred_k) values ('" + entity.Ime + "','" + entity.Prezime + "','"
                        + entity.Datum_rodjenja.ToString(df) + "','" + entity.Username + "','" + entity.Password +"','" + entity.Predstavnik_kuce +"')", con);
                    c.ExecuteNonQuery();
                    return c.LastInsertedId;
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

            public Profesor read(Profesor entity)
            {
                c = new MySqlCommand("select * from profesor where id_profesor ="+ entity.Id_profesor + "and ime=" + entity.Ime + " and prezime=" + entity.Prezime + " and dat_rodj=" + entity.Datum_rodjenja
                    + " and username=" + entity.Username + " and pass=" + entity.Password +  "and pred_k =" + entity.Predstavnik_kuce +";");
                MySqlDataReader mr = c.ExecuteReader();
                if (mr.Read())
                    return new Profesor(mr.GetInt32("id_profesor"),mr.GetString("ime"), mr.GetString("prezime"), mr.GetDateTime("dat_rodj"), mr.GetString("username"), mr.GetString("pass"),mr.GetBoolean("pred_k"));
                else
                    return null;
            }

            
            public Profesor update(Profesor entity)
            {
                c = new MySqlCommand("update profesor set id_profesor=" + entity.Id_profesor + ", ime=" + entity.Ime + ", prezime=" + entity.Prezime + ", datum_rodjenja=" + entity.Datum_rodjenja
                    + ", password=" + entity.Password +  ", pred_k=" + entity.Predstavnik_kuce + "where username=" + entity.Username + ";");
                c.ExecuteNonQuery();
                return read(entity);
            }

            public void delete(Profesor entity)
            {
                c = new MySqlCommand("delete profesor where id_profesor=" + entity.Id_profesor + ", ime=" + entity.Ime + " and prezime=" + entity.Prezime + " and datum_rodjenja=" + entity.Datum_rodjenja
                    + " and username=" + entity.Username + " and password=" + entity.Password  + "and pred_k=" + entity.Predstavnik_kuce +";");
                c.ExecuteNonQuery();
            }

            public Profesor getById(int id)
            {
                c = new MySqlCommand("select * from profesor where id_profesor=" + Convert.ToString(id) + ";");
                MySqlDataReader mr = c.ExecuteReader();
                if (mr.Read())
                    return new Profesor(mr.GetInt32("id_profesor"), mr.GetString("ime"), mr.GetString("prezime"), mr.GetDateTime("dat_rodj"), mr.GetString("username"), mr.GetString("pass"),  mr.GetBoolean("pred_k"));
                else
                    return null;

            }

            public List<Profesor> getAll()
            {
                try
                {

                    string connectionString = "server=localhost;user=" + _user + ";pwd=" + _pass + ";database=" + _db; 
                    con = new MySqlConnection(connectionString);
                    con.Open();
                    c = new MySqlCommand("select * from profesor", con);
                    MySqlDataReader mr = c.ExecuteReader();
                    List<Profesor> _profesori = new List<Profesor>();
                    while (mr.Read())
                        _profesori.Add(new Profesor(mr.GetInt32("id_profesor"), mr.GetString("ime"), mr.GetString("prezime"), mr.GetDateTime("dat_rodj"), mr.GetString("username"), mr.GetString("pass"),  mr.GetBoolean("pred_k")));
                    return _profesori;
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

            public List<Profesor> getByExample(string ime, string prezime)
            {
                try
                {
                    c = new MySqlCommand("select * from osobe where ime=" + ime + " and prezime=" + prezime, con);
                    MySqlDataReader mr = c.ExecuteReader();
                    List<Profesor> _profesori = new List<Profesor>();
                    while (mr.Read())
                        _profesori.Add(new Profesor(mr.GetInt32("id_profesor"), mr.GetString("ime"), mr.GetString("prezime"), mr.GetDateTime("dat_rodj"), mr.GetString("username"), mr.GetString("pass"),  mr.GetBoolean("pred_k")));
                    return _profesori;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            public void ObrisiSve()
            {
                try
                {
                    con.Open();
                    c = new MySqlCommand("delete from profesor", con);
                    c.ExecuteNonQuery();

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

            public Profesor Prijava(string Username, string Password)
            {
                try
                {
                    string connectionString = "server=localhost;user=" + _user + ";pwd=" + _pass + ";database=" + _db;
                    con = new MySqlConnection(connectionString);
                    con.Open();
                    c = new MySqlCommand("select * from profesor where username='" + Username + "' and pass= '" + Password + "';", con);
                    MySqlDataReader mr = c.ExecuteReader();
                    if (mr.Read())
                        return new Profesor(mr.GetInt32("id_profesor"), mr.GetString("ime"), mr.GetString("prezime"), mr.GetDateTime("dat_rodj"), mr.GetString("username"), mr.GetString("pass"), mr.GetBoolean("pred_k"));
                    else
                        return null;

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
