namespace api_parqueosHeredianos.Models
{
    public class Reporte
    {
        public int id { get; set; }

        public List<Parqueo>? listaParqueos { get; set; } = new List<Parqueo>();
    }
}
