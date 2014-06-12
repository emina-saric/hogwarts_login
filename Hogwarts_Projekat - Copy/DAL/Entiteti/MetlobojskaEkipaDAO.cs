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
        public class MetlobojskaEkipaDAO : IDaoCrud<MetlobojskaEkipa>
        {
            protected MySqlCommand c;

            public long create(MetlobojskaEkipa entity)
            {
                try
                {
                    c = new MySqlCommand("insert into tim values ('" + entity.Id_kuca + "','" + entity.Id_kapiten + ","
                        + entity.Bodovi + "')", con);
                    c.ExecuteNonQuery();
                    return c.LastInsertedId;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public MetlobojskaEkipa read(MetlobojskaEkipa entity)
            {
                c = new MySqlCommand("select * from tim where id_tim=" + entity.Id_tim + " and id_kuca=" + entity.Id_kuca + " and id_kapiten=" + entity.Id_kapiten + "and bodovi=" + entity.Bodovi +";");
                MySqlDataReader mr = c.ExecuteReader();
                if (mr.Read())
                    return new MetlobojskaEkipa(mr.GetInt32("id_tim"), mr.GetInt32("id_kuca"), mr.GetInt32("id_kapiten"), mr.GetInt32("bodovi"));
                else
                    return null;
            }

            public MetlobojskaEkipa update(MetlobojskaEkipa entity)
            {
                c = new MySqlCommand("update tim set id_kuca=" + entity.Id_kuca + ", id_kapiten=" + entity.Id_kapiten + ", bodovi=" + entity.Bodovi
                   + "where id_tim=" + entity.Id_tim + ";");
                c.ExecuteNonQuery();
                return read(entity);
            }

            public void delete(MetlobojskaEkipa entity)
            {
                c = new MySqlCommand("delete tim where id_tim=" + entity.Id_tim + " and id_kuca=" + entity.Id_kuca + " and id_kapiten=" + entity.Id_kapiten
                    + " and bodovi=" + entity.Bodovi+";");
                c.ExecuteNonQuery();
            }

            public MetlobojskaEkipa getById(int id)
            {
                c = new MySqlCommand("select * from tim where id_tim=" + Convert.ToString(id) + ";");
                MySqlDataReader mr = c.ExecuteReader();
                if (mr.Read())
                    return new MetlobojskaEkipa(mr.GetInt32("id_tim"), mr.GetInt32("id_kuca"), mr.GetInt32("id_kapiten"), mr.GetInt32("bodovi"));
                else
                    return null;
            }

            public List<MetlobojskaEkipa> getAll()
            {
                try
                {
                    c = new MySqlCommand("select * from tim", con);
                    MySqlDataReader mr = c.ExecuteReader();
                    List<MetlobojskaEkipa> _timovi = new List<MetlobojskaEkipa>();
                    while (mr.Read())
                        _timovi.Add(new MetlobojskaEkipa(mr.GetInt32("id_tim"), mr.GetInt32("id_kuca"), mr.GetInt32("id_kapiten"), mr.GetInt32("bodovi")));
                    return _timovi;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public List<MetlobojskaEkipa> getByExample(string name, string value)
            {
                try
                {
                    MySqlDataReader mr = c.ExecuteReader();
                    List<MetlobojskaEkipa> _timovi = new List<MetlobojskaEkipa>();
                    while (mr.Read())
                        _timovi.Add(new MetlobojskaEkipa(mr.GetInt32("id_tim"), mr.GetInt32("id_kuca"), mr.GetInt32("id_kapiten"), mr.GetInt32("bodovi")));
                    return _timovi;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
