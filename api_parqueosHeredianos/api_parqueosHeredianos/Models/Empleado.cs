

namespace api_parqueosHeredianos.Models
{
    public class Empleado
    {
        public int id { get; set; }

        public string fechaIngreso { get; set; }

        public string nombre { get; set; }

        public string primerApellido { get; set; }

        public string segundoApellido { get; set; }

        public string fechaNacimiento { get; set; }

        public string cedula { get; set; }

        public string direccion { get; set; }

        public string email { get; set; }


        public string telefono { get; set; }

        
        public string nombrePersonaContacto { get; set; }

        public string telefonoPersonaContacto { get; set; }

        public int idParqueo { get; set; }

    }
}
