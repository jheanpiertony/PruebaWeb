using CommonCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CommonCore.Repositories
{
    public interface IRepositorio<T>
    {
        void Agregar(T entidad);
        void Eliminar(int id);
        void Actualizar(T entidad);
        int Contar(Expression<Func<T, bool>> where);
        IEnumerable<T> OdtenerLista();
        IEnumerable<T> EncontrarPor(ParametrosDeQuery<T> parametrosDeQuery);
        T ObtenerPorId(int id);
        //IEnumerable<T> EncontrarPor(ParametrosDeQuery<T> parametrosDeQuery);
    }
}
