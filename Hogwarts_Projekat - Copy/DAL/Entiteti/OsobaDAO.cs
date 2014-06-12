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
        public class OsobaDAO : IDaoCrud<Osoba>
        {
            protected MySqlCommand c;

            public long create(Osoba entity)
            {
                try
                {
                    c = new MySqlCommand("insert into osobe values ('" + entity.Ime + "','" + entity.Prezime + ","
                        +entity.Datum_rodjenja+","+entity.Username+","+entity.Password+"')", con);
                    c.ExecuteNonQuery();
                    return c.LastInsertedId;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public Osoba read(Osoba entity)
            {
                c = new MySqlCommand("select * from osobe where ime=" + entity.Ime + " and prezime=" + entity.Prezime + " and datum_rodjenja=" + entity.Datum_rodjenja
                    + " and username=" + entity.Username + " and password=" + entity.Password + ";");
                MySqlDataReader mr = c.ExecuteReader();
                if (mr.Read())
                    return new Osoba(mr.GetString("ime"), mr.GetString("prezime"), mr.GetDateTime("datum_rodjenja"), mr.GetString("username"), mr.GetString("password"));
                else
                    return null;
            }

            public Osoba update(Osoba entity)
            {
                c = new MySqlCommand("update osobe set ime="+entity.Ime+", prezime="+entity.Prezime +", datum_rodjenja="+ entity.Datum_rodjenja
                    + ", password=" + entity.Password + "where username="+entity.Username+";");
                c.ExecuteNonQuery();
                return read(entity);
            }

            public void delete(Osoba entity)
            {
                c = new MySqlCommand("delete osobe where ime=" + entity.Ime + " and prezime=" + entity.Prezime + " and datum_rodjenja=" + entity.Datum_rodjenja
                    + " and username=" + entity.Username + " and password=" + entity.Password + ";");
                c.ExecuteNonQuery();
            }

            public Osoba getById(int id)
            {
                c = new MySqlCommand("select * from osobe where id="+Convert.ToString(id)+";");
                MySqlDataReader mr = c.ExecuteReader();
                if (mr.Read())
                    return new Osoba(mr.GetString("ime"), mr.GetString("prezime"), mr.GetDateTime("datum_rodjenja"), mr.GetString("username"), mr.GetString("password"));
                else
                    return null;
                 
            }

            public List<Osoba> getAll()
            {
                try
                {
                    c = new MySqlCommand("select * from osobe", con);
                    MySqlDataReader mr = c.ExecuteReader();
                    List<Osoba> osobe = new List<Osoba>();
                    while (mr.Read())
                        osobe.Add(new Osoba(mr.GetString("ime"), mr.GetString("prezime"), mr.GetDateTime("datum_rodjenja"), mr.GetString("username"), mr.GetString("password")));
                    return osobe;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public List<Osoba> getByExample(string ime, string prezime)
            {
                try
                {
                    c = new MySqlCommand("select * from osobe where ime="+ime+" and prezime="+prezime, con);
                    MySqlDataReader mr = c.ExecuteReader();
                    List<Osoba> osobe = new List<Osoba>();
                    while (mr.Read())
                        osobe.Add(new Osoba(mr.GetString("ime"), mr.GetString("prezime"), mr.GetDateTime("datum_rodjenja"), mr.GetString("username"), mr.GetString("password")));
                    return osobe;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }   
    }
}
