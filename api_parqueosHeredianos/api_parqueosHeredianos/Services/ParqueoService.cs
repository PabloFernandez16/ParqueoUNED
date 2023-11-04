using api_parqueosHeredianos.Models;
using api_parqueosHeredianos.Repository;

namespace api_parqueosHeredianos.Services
{
    public class ParqueoService : IBaseRepository2<Parqueo>
    {
        public static List<Parqueo> listaParqueos = new List<Parqueo>();

        public ParqueoService()
        {
        }

        //Datos datos = new Datos();
        public bool Agregar(Parqueo entidad)
        {
            bool agregado;
            try
            {
                listaParqueos.Add(entidad);
                agregado = true;
            }
            catch (Exception)
            {
                agregado = false;
            }

            return agregado;
        }

        public Parqueo BuscarElementoEspecifico(int id)
        {
            foreach (Parqueo item in listaParqueos)
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
            listaParqueos.RemoveAll(p => p.id == id);
            return true;
        }

        public bool Editar(int id, Parqueo entidadModificada)
        {
            if (entidadModificada == null)
            {
                throw new ArgumentNullException("entidadModificada");
            }

            int index = listaParqueos.FindIndex(p => p.id == id);
            if (index == -1)
            {
                return false; // No se encontró la entidad con el ID especificado.
            }
            var parqueoExistente = listaParqueos[index];

            // Actualiza solo los campos que sean diferentes.
            if (parqueoExistente.nombre != entidadModificada.nombre)
            {
                parqueoExistente.nombre = entidadModificada.nombre;
            }

            if (parqueoExistente.cantMaxVehiculos != entidadModificada.cantMaxVehiculos)
            {
                parqueoExistente.cantMaxVehiculos = entidadModificada.cantMaxVehiculos;
            }

            if (parqueoExistente.horaApertura != entidadModificada.horaApertura)
            {
                parqueoExistente.horaApertura = entidadModificada.horaApertura;
            }

            if (parqueoExistente.horaCierre != entidadModificada.horaCierre)
            {
                parqueoExistente.horaCierre = entidadModificada.horaCierre;
            }
            return true;
            /*if (entidadModificada == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = listaParqueos.FindIndex(p => p.id == id);
            if (index == -1)
            {
                return false;
            }
            listaParqueos.RemoveAt(index);
            listaParqueos.Add(entidadModificada);
            return true;*/
        }

        public List<Parqueo> Listar()
        {
            return listaParqueos;
        }
    }
}
