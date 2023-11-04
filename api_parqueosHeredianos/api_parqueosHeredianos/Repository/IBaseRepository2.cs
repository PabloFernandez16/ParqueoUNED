namespace api_parqueosHeredianos.Repository
{
    public interface IBaseRepository2<T>
    {
        public List<T> Listar();
        //ObtenerEmpleadosPorIdParqueo
       // public List<T> ObtenerEmpleadosPorIdParqueo(int id);
        public T BuscarElementoEspecifico(int id);

        public bool Agregar(T entidad);

        public bool Delete(int id);

        public bool Editar(int id, T entidadModificada);
    }
}