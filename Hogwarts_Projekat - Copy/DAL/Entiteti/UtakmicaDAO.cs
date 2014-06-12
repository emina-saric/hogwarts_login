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
        public class UtakmicaDAO : IDaoCrud<Utakmica>
        {
            protected MySqlCommand c;
            public long create(Utakmica entity)
            {
                try
                {
                    c = new MySqlCommand("insert into utakmica values ('" + entity.Termin + "','" + entity.Id_tim1 + ","
                        + entity.Id_tim2 + "," + entity.Bodovi1 + "," + entity.Bodovi2 +"," + entity.Odigrana + "')", con);
                    c.ExecuteNonQuery();
                    return c.LastInsertedId;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public Utakmica read(Utakmica entity)
            {
                c = new MySqlCommand("select * from utakmica where id_utakmica=" + entity.Id_utakmica + "and term=" + entity.Termin + " and id_tim1=" + entity.Id_tim1 + " and id_tim2=" + entity.Id_tim2
               + " and bod1=" + entity.Bodovi1 + " and bod2=" + entity.Bodovi2 + "and odigrana=" + entity.Odigrana + ";");
                MySqlDataReader mr = c.ExecuteReader();
                if (mr.Read())
                    return new Utakmica(mr.GetInt32("id_utakmica"), mr.GetDateTime("term"), mr.GetInt32("id_tim1"), mr.GetInt32("id_tim2"), mr.GetInt32("bod1"), mr.GetInt32("bod2"), mr.GetBoolean("odigrana"));
                else
                    return null;
            }

            public Utakmica update(Utakmica entity)
            {
                c = new MySqlCommand("update utakmica set term=" + entity.Termin + ", id_tim1=" + entity.Id_tim1 + ", id_tim2=" + entity.Id_tim2
                   + ", bod1=" + entity.Bodovi1 + ", bod2" + entity.Bodovi2 + ", odigrana=" + entity.Odigrana + "where id_utakmica=" + entity.Id_utakmica + ";");
                c.ExecuteNonQuery();
                return read(entity);
            }

            public void delete(Utakmica entity)
            {
                c = new MySqlCommand("delete utakmica where id_utakmica=" + entity.Id_utakmica + "and term=" + entity.Termin + " and id_tim1=" + entity.Id_tim1 + " and id_tim2=" + entity.Id_tim2
               + " and bod1=" + entity.Bodovi1 + " and bod2=" + entity.Bodovi2 + "and odigrana=" + entity.Odigrana + ";");
                c.ExecuteNonQuery();
            }

            public Utakmica getById(int id)
            {
                c = new MySqlCommand("select * from utakmica where id_utakmica=" + Convert.ToString(id) + ";");
                MySqlDataReader mr = c.ExecuteReader();
                if (mr.Read())
                    return new Utakmica(mr.GetInt32("id_utakmica"), mr.GetDateTime("term"), mr.GetInt32("id_tim1"), mr.GetInt32("id_tim2"), mr.GetInt32("bod1"), mr.GetInt32("bod2"), mr.GetBoolean("odigrana"));
                else
                    return null;

            }

            public List<Utakmica> getAll()
            {
                try
                {
                    c = new MySqlCommand("select * from utakmica", con);
                    MySqlDataReader mr = c.ExecuteReader();
                    List<Utakmica> _utakmice = new List<Utakmica>();
                    while (mr.Read())
                        _utakmice.Add(new Utakmica(mr.GetInt32("id_utakmica"), mr.GetDateTime("term"), mr.GetInt32("id_tim1"), mr.GetInt32("id_tim2"), mr.GetInt32("bod1"), mr.GetInt32("bod2"), mr.GetBoolean("odigrana")));
                    return _utakmice;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public List<Utakmica> getByExample(string name, string value)
            {
                try
                {
                   
                    MySqlDataReader mr = c.ExecuteReader();
                    List<Utakmica> _utakmice = new List<Utakmica>();
                    while (mr.Read())
                        _utakmice.Add(new Utakmica(mr.GetInt32("id_utakmica"), mr.GetDateTime("term"), mr.GetInt32("id_tim1"), mr.GetInt32("id_tim2"), mr.GetInt32("bod1"), mr.GetInt32("bod2"), mr.GetBoolean("odigrana")));
                    return _utakmice;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
