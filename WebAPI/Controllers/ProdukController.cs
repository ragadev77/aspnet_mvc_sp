using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

using WebAPI.Models;
using WebAPI.Repositories;

using System.Linq;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdukController : ControllerBase
    {
        private readonly IProdukRepository _repository;
        private APIResult ar = new APIResult();
       
        public ProdukController(IProdukRepository repository)
        {
            _repository = repository;

        }

        [HttpGet("list")]
        public async Task<IActionResult> ListProduk()
        {
            var data = await _repository.ListProduk();
            if (data.Any())
                return Ok(data);
            return Ok(ar.HTTPResponseNoDataFound());

        }


        [HttpGet("get")]
        public async Task<IActionResult> GetProduk(int produk_id)
        {
            var retObject = new List<dynamic>();

            var data = await _repository.GetProduk(produk_id);
            if (data != null)
                return Ok(data);
            return Ok(ar.HTTPResponseNoDataFound());

        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchProduk([FromBody] JsonObject json)
        {
            var retObject = new List<dynamic>();
            //var data = new JObject();

            string p1 = (string)json["nama_barang"];
            string? p2 = (string)json["kode_barang"];

            var data = await _repository.SearchProduk(p1, p2);
            if (data.Any())
                return Ok(data);
            return Ok(ar.HTTPResponseNoDataFound());

        }

        [HttpPost("add")]
        public async Task<ActionResult> AddProduk([FromBody] Produk produk)
        {
            if (produk == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await _repository.AddProduk(produk);

                return Ok(ar.HTTPResponseSaveSuccess());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("edit")]
        public async Task<ActionResult> EditProduk([FromBody] Produk produk)
        {
            if (produk == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await _repository.UpdateProduk(produk);
                return Ok(ar.HTTPResponseUpdateSuccess());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteProduk(int id)
        {
            try
            {
                var response = await _repository.DeleteProduk(id);
                return Ok(ar.HTTPResponseDeleteSuccess());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



    }


}
