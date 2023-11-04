using api_parqueosHeredianos.Models;
using api_parqueosHeredianos.Repository;

public class ReporteService : IBaseRepository2<Reporte>
{
    public static List<Reporte> listaReportes = new List<Reporte>();

    public bool Agregar(Reporte entidad)
    {
        bool agregado;
        try
        {
            listaReportes.Add(entidad);
            agregado = true;
        }
        catch (Exception)
        {
            agregado = false;
        }

        return agregado;
    }

    public Reporte BuscarElementoEspecifico(int id)
    {
        foreach (Reporte item in listaReportes)
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
        listaReportes.RemoveAll(p => p.id == id);
        return true;
    }

    public bool Editar(int id, Reporte entidadModificada)
    {
        //Reporte r = BuscarElementoEspecifico(id);

        if (entidadModificada == null)
        {
            throw new ArgumentNullException("item");
        }
        int index = listaReportes.FindIndex(p => p.id == id);
        if (index == -1)
        {
            return false;
        }
        listaReportes.RemoveAt(index);
        listaReportes.Add(entidadModificada);
        return true;
    }

    public List<Reporte> Listar()
    {
        return listaReportes;
    }

}
