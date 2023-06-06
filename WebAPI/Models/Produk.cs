using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Models
{
    [Table("produk", Schema = "dbo")]
    public class Produk
    {
        [Key]
        public int id { get; set; }

        //[Column("nama_barang", TypeName = "varchar(200)")]
        [DisplayName("Nama Barang")]
        public string nama_barang { get; set; }
        
        //[Column("kode_barang", TypeName = "varchar(50)")]
        [DisplayName("Kode Barang")]
        public string kode_barang { get; set; }

        //[Column("jumlah_barang")]
        [DisplayName("Jumlah")]
        public int jumlah_barang { get; set; }

        //[Column("tanggal")]
        [DisplayName("Tanggal")]
        [BindProperty, DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime tanggal { get; set; }

    }
}
