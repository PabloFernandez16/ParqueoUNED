using api_parqueosHeredianos.Models;
using api_parqueosHeredianos.Repository;

namespace api_parqueosHeredianos.Services
{
    public class TiqueteService : IBaseRepository2<Tiquete>
    {
        public static List<Tiquete> listaTiquetes = new List<Tiquete>();
        ParqueoService parqueoService;
    
        public TiqueteService()
        {
            parqueoService = new ParqueoService();


        }

        public bool Agregar(Tiquete entidad)
        {
            bool agregado;
            try
            {
                listaTiquetes.Add(entidad);

                Parqueo pEditable = parqueoService.BuscarElementoEspecifico(entidad.idParqueo);
                pEditable.lstIdtikets.Add(entidad);
                pEditable.total += entidad.tarifaHora;
                agregado = true;
            }
            catch (Exception)
            {
                agregado = false;
            }

            return agregado;
        }

        public Tiquete BuscarElementoEspecifico(int id)
        {
            foreach (Tiquete item in listaTiquetes)
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
            listaTiquetes.RemoveAll(p => p.id == id);
            return true;
        }

        public bool Editar(int id, Tiquete entidadModificada)
        {

            if (entidadModificada == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = listaTiquetes.FindIndex(p => p.id == id);
            if (index == -1)
            {
                return false;
            }
            listaTiquetes.RemoveAt(index);
            listaTiquetes.Add(entidadModificada);
            return true;
        }

        public List<Tiquete> Listar()
        {
            return listaTiquetes;
        }

    }
}

