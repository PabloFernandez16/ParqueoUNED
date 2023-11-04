using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace api_parqueosHeredianos.Models
{
    public class Tiquete
    {
        public int id { get; set; }
        public string fechaUso { get; set; }
        public string horaIngreso { get; set; }

        public string horaSalida { get; set; }
        public double horasEstacionado { get; set; }

        public string placaVehiculo { get; set; }
        public double tarifaHora { get; set; }

        public int idParqueo { get; set; }
    }
}
