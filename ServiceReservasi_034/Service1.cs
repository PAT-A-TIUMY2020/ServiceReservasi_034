using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceReservasi_034
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        string connectionString = "Data Source = DESKTOP-F1IM27G;Initial Catalog = WCFReservasi; Persist Security Info=True;User ID = sa; Password=alfinuraziz311;";

        SqlConnection connection;
        SqlCommand com;//untuk menghubungkan database

        public string deletePemesanan(string IdPemesanan)
        {
            string a = "gagal";
            try
            {
                string sql = "delete from dbo.Pemesanan where ID_reservasi = '" + IdPemesanan + "'";
                connection = new SqlConnection(connectionString);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "Sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }

            return a;
        }

        public List<DetailLokasi> DetailLokasi()
        {
            //deklarasi nama List
            List<DetailLokasi> LokasiFull = new List<DetailLokasi>();
            try
            {
                string sql = "select ID_Lokasi, Nama_Lokasi, Deskripsi_Full, Kuota from dbo.Lokasi";
                connection = new SqlConnection(connectionString);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    DetailLokasi data = new DetailLokasi();
                    //array
                    data.IdLokasi = reader.GetString(0);
                    data.NamaLokasi = reader.GetString(1);
                    data.DeskripsiFull = reader.GetString(2);
                    data.Kuota = reader.GetInt32(3);
                    LokasiFull.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return LokasiFull;
        }

        public string editPemesanan(string IdPemesanan, string NamaCustomer, string NoTelp)
        {
            string a = "gagal";
            try
            {
                string sql = "update dbo.Pemesanan set Nama_customer = '" + NamaCustomer + "',No_telpon = '" + NoTelp + "'" + "where ID_reservasi ='" + IdPemesanan + "'";
                connection = new SqlConnection(connectionString);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                a = "Sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }

            return a;
        }

        public string editPemesanan(string idPemesanan, string namaCustomer)
        {
            throw new NotImplementedException();
        }

        public string pemesanan(string IdPemesanan, string NamaCustomer, string NoTelp, int JumlahPemesanan, string IdLokasi)
        {
            string a = "gagal";
            try
            {
                string sql = "insert into dbo.Pemesanan values ('" + IdPemesanan + "','" + NamaCustomer + "','" + NoTelp + "'," + JumlahPemesanan + ",'" + IdLokasi + "')";

                connection = new SqlConnection(connectionString);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                string sql2 = "update dbo.Lokasi set Kuota = Kuota -" + JumlahPemesanan + "where ID_lokasi = '" + IdLokasi + "'";
                connection = new SqlConnection(connectionString);
                com = new SqlCommand(sql2, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                a = "Sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }

            return a;
        }

        public List<Pemesanan> Pemesanan()
        {
            List<Pemesanan> pemesanans = new List<Pemesanan>();
            try
            {
                string sql = "select ID_reservasi, Nama_customer, No_telpon, " + "Jumlah_pemesanan, Nama_Lokasi from dbo.Pemesanan p join dbo.Lokasi 1 on p.ID_Lokasi = 1.ID_lokasi";
                connection = new SqlConnection(connectionString);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Pemesanan data = new Pemesanan();
                    data.IdPemesanan = reader.GetString(0);
                    data.NamaCustomer = reader.GetString(1);
                    data.NoTelp = reader.GetString(2);
                    data.JumlahPemesanan = reader.GetInt32(3);
                    data.Lokasi = reader.GetString(4);
                    pemesanans.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return pemesanans;
        }

        public List<CekLokasi> reviewLokasi()
        {
            throw new NotImplementedException();
        }
    }


}
