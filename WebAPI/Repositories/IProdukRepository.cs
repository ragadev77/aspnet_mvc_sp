using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IProdukRepository
    {

        Task<Produk> GetProduk(int produk_id);
        Task<IEnumerable<Produk>>? ListProduk();
        Task<IEnumerable<Produk>>? SearchProduk(string nama_barang=null, string kode_barang=null);
        Task<int> AddProduk(Produk produk);
        Task<int> DeleteProduk(int id);
        Task<int> UpdateProduk(Produk produk);

    }
}
