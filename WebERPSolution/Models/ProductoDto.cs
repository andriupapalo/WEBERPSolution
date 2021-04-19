using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSolution.Models.Dtos
{
    public class ProductoDto
    {
		public int Id { get; set; }
		public string Descripcion { get; set; }
		public double Saldoinicial { get; set; }
		public double SaldoActual { get; set; }
		public int UnidadMedidaId { get; set; }
		public int CostoPromedio { get; set; }
		public double PrecioVenta { get; set; }
		public int StockMinimo { get; set; }
		public int StockMaximo { get; set; }
		public DateTime FechaCreacion { get; set; }
		public DateTime FechaModificacion { get; set; }
		public int UsuarioCreacionId { get; set; }
		public int UsuarioModificacionId { get; set; }
	}
}
