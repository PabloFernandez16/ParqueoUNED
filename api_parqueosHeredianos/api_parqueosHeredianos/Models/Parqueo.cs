using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace api_parqueosHeredianos.Models
{
    public class Parqueo
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public int cantMaxVehiculos { get; set; }

        public string horaApertura { get; set; }

        public string horaCierre { get; set; }

        public double total { get; set; }

        public List<Tiquete>? lstIdtikets { get; set; } = new List<Tiquete>();
        public List<Empleado>? lstEmpleados { get; set; } = new List<Empleado>();

    }
}
