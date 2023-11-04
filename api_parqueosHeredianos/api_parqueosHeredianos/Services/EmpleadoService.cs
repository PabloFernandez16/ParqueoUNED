using api_parqueosHeredianos.Data;
using api_parqueosHeredianos.Models;
using api_parqueosHeredianos.Repository;

namespace api_parqueosHeredianos.Services
{
    public class EmpleadoService : IBaseRepository2<Empleado>
    {
        public static List<Empleado> listaEmpleados = new List<Empleado>();
        ParqueoService parqueoService = new ParqueoService();

        public bool Agregar(Empleado entidad)
        {
            bool agregado;
            try
            {
                listaEmpleados.Add(entidad);

                Parqueo pEditable = parqueoService.BuscarElementoEspecifico(entidad.idParqueo);
                pEditable.lstEmpleados.Add(entidad);
                agregado = true;
            }
            catch (Exception)
            {
                agregado = false;
            }

            return agregado;
        }

        public Empleado BuscarElementoEspecifico(int id)
        {
            foreach (Empleado item in listaEmpleados)
            {
                if (item.id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public bool Delete(int id)
        {
            listaEmpleados.RemoveAll(p => p.id == id);
            return true;
        }

        public bool Editar(int id, Empleado entidadModificada)
        {
            if (entidadModificada == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = listaEmpleados.FindIndex(p => p.id == id);
            if (index == -1)
            {
                return false;
            }
            listaEmpleados.RemoveAt(index);
            listaEmpleados.Add(entidadModificada);
            return true;
        }

        public List<Empleado> Listar()
        {
            return listaEmpleados;
        }
    }
}
