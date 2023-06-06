using System;
using System.Globalization;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using WebAPI.Controllers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class ProdukRepository : IProdukRepository
    {

        private readonly APIDbContext _context;

        public ProdukRepository(APIDbContext context)
        {
            _context = context;
        }

        public async Task<Produk> GetProduk(int produk_id)
        {
//            var param = new SqlParameter("@id", produk_id);

            var result = await Task.Run(() => _context.Produks.FromSqlRaw(
                            $"exec produk_get @id", new SqlParameter("@id", produk_id)
                         ).ToListAsync());

            return result[0];
        }
        public async Task<IEnumerable<Produk>>? ListProduk()
        {
            //    return await _context.Produks.ToListAsync();
            var result = await Task.Run(() => _context?.Produks?.FromSqlRaw(
                        $"exec produk_search @nama_barang,@kode_barang"
                        , new SqlParameter("@nama_barang", ""), new SqlParameter("@kode_barang", "")
                    ).ToListAsync());
            return result;
        }
        public async Task<IEnumerable<Produk>>? SearchProduk(string? nama_barang = null, string? kode_barang = null)
        {
            var p1 = new SqlParameter("@nama_barang", nama_barang);
            var p2 = new SqlParameter("@kode_barang", kode_barang);
            var result = await Task.Run(() => _context?.Produks?.FromSqlRaw(
                        $"exec produk_search @nama_barang,@kode_barang"
                        , p1, p2
                    ).ToListAsync());
            return result;
        }

        /* region non-query */
        public async Task<int> AddProduk(Produk produk)
        {

            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@name", produk.nama_barang));
            parameter.Add(new SqlParameter("@kode", produk.kode_barang));
            parameter.Add(new SqlParameter("@jumlah", produk.jumlah_barang));
            parameter.Add(new SqlParameter("@tgl", produk.tanggal));

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec produk_add @name, @kode, @jumlah, @tgl", parameter.ToArray()));

            return result;

        }

        public async Task<int> DeleteProduk(int produk_id)
        {
                return await Task.Run(() => _context.Database.ExecuteSqlInterpolatedAsync($"produk_del {produk_id}"));
        }


        public async Task<int> UpdateProduk(Produk produk)
        {

            //_context.Entry(produk).State = EntityState.Modified;
            //await _context.SaveChangesAsync();

            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@id", produk.id));
            parameter.Add(new SqlParameter("@name", produk.nama_barang));
            parameter.Add(new SqlParameter("@kode", produk.kode_barang));
            parameter.Add(new SqlParameter("@jumlah", produk.jumlah_barang));
            parameter.Add(new SqlParameter("@tgl", produk.tanggal));

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec produk_edit @id, @name, @kode, @jumlah, @tgl", parameter.ToArray()));
            return result;
        }

        public Produk GetByID(int id)
        {
            var data = _context.Produks.Find(id);
            return data;
        }

    }
}
