﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceReservasi_034
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        //method proses input data
        string pemesanan(string IdPemesanan, string NamaCustomer, string NoTelp, int JumlahPemesanan, string IdLokasi);
        [OperationContract]
        string editPemesanan(string idPemesanan, string namaCustomer);
        [OperationContract]
        string deletePemesanan(string idPemesanan);
        [OperationContract]
        //Menampilkan data yang ada di database
        List<CekLokasi> reviewLokasi();
        [OperationContract]
        //Menampilkan detail lokasi
        List<DetailLokasi> DetailLokasi();
        [OperationContract]
        List<Pemesanan> Pemesanan();

        [OperationContract]
        string Login(string username, string password);
        [OperationContract]
        string Register(string username, string password, string kategori);
        [OperationContract]
        string UpdateRegister(string username, string password, string kategori, int id);
        [OperationContract]
        string DeleteRegister(string username);
        [OperationContract]
        List<DataRegister> DataRegist();
    }

    [DataContract]
    public class DataRegister
    {
        [DataMember(Order = 1)]
        public int id { get; set; }
        [DataMember(Order = 2)]
        public string username { get; set; }
        [DataMember(Order = 3)]
        public string password { get; set; }
        [DataMember(Order = 4)]
        public string kategori { get; set; }
    }

    [DataContract]
    public class CekLokasi
    {
        [DataMember]
        public string IDLokasi { get; set; }
        [DataMember]
        public string NamaLokasi { get; set; }
        [DataMember]
        public string Deskripsi { get; set; }
    }

    [DataContract]
    public class DetailLokasi
    {
        [DataMember]
        public string IdLokasi { get; set; }
        [DataMember]
        public string NamaLokasi { get; set; }
        [DataMember]
        public string DeskripsiFull { get; set; }
        [DataMember]
        public int Kuota { get; set; }
    }

    [DataContract]
    public class Pemesanan
    {
        [DataMember]
        public string IdPemesanan { get; set; }
        [DataMember]
        public string NamaCustomer { get; set; }
        [DataMember]
        public string NoTelp { get; set; }
        [DataMember]
        public int JumlahPemesanan { get; set; }
        [DataMember]
        public string Lokasi { get; set; }
    }
}
