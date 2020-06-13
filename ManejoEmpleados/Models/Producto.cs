using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoEmpleados.Models
{
    public class Producto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        //public Categoria Categoria { get; set; }

        public string Marca { get; set; }

        public IEnumerable<Promocion> Promociones { get; set; }

        public double Precio { get; set; }

        //public List<Gastos> Gastos { get; set; }
    }

    public class Promocion
    {
        public string Nombre { get; set; }
        public bool Activa { get; set; }

        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public int Descuento { get; set; }
    }
}
