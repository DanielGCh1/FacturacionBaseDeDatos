using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion_Base_De_Datos.UNA.Facturacion_Base_De_Datos.Modelos
{
    public  class Cliente
    {
        public long Cedula { get; set; }
        public string  Nombre {get; set;}
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
    }
}
