using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ERPSolution.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebERPSolution.Controllers
{
    public class ProductoController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        ProductoDto _productoDto = new ProductoDto();
        List<ProductoDto> _productosDto = new List<ProductoDto>();
        List<UnidadMedidaDto> _unidamedidaDto = new List<UnidadMedidaDto>();
        // GET: /<controller>/
        //public IActionResult Producto()
        public ProductoController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        }

        [HttpGet("Productos")]
        public IActionResult Productos()
        {
            listas();
            return View();
        }

        [HttpGet("Producto")]
        public async Task<List<ProductoDto>> Producto()
        
        {
            _productosDto = new List<ProductoDto>();
            
            using (var httpClient= new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44352/api/Producto/GetProducto"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _productosDto = JsonConvert.DeserializeObject<List<ProductoDto>>(apiResponse);
                }
            }
            return _productosDto;
        }


        [HttpGet("ProductoProductoById/{id}")]
        public async Task<ProductoDto> ProductoById(int id)

        {
            _productoDto = new ProductoDto();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44352/api/Producto/GetProductoById/"+id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _productoDto = JsonConvert.DeserializeObject<ProductoDto>(apiResponse);
                }
            }
            return _productoDto;
        }


        [HttpDelete("Delete")]
        public async Task<string> Delete(int Id)

        {
            string message = "";

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44352/api/Producto/DeleteProducto/" + Id))
                {
                    message = await response.Content.ReadAsStringAsync();
                }
            }
            return message;
        }


        [HttpPost("Productos")]
        public async Task<ProductoDto> Productos(ProductoDto productoDto)

        {
            _productoDto = new ProductoDto();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(productoDto),Encoding.UTF8,"application/Json");
                using (var response = await httpClient.PostAsync("https://localhost:44352/api/Producto/Producto", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _productoDto = JsonConvert.DeserializeObject<ProductoDto>(apiResponse);
                }
            }
            return _productoDto;
        }


        [HttpGet("UnidadMedida")]
        public async Task<List<UnidadMedidaDto>> UnidadMedida()

        {
            _unidamedidaDto = new List<UnidadMedidaDto>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44352/api/UnidadMedida/UnidadMedida"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _unidamedidaDto = JsonConvert.DeserializeObject<List<UnidadMedidaDto>>(apiResponse);
                }
            }
            return _unidamedidaDto;
        }
        public void listas()
        {
            ViewBag.Productos = Producto();
            //ViewBag.UnidadMedidaId = UnidadMedida();
        }
    }
}
