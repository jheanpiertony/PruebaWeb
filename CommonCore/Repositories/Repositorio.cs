using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using CommonCore.Helpers;

namespace CommonCore.Repositories
{
    public class Repositorio<T> : IRepositorio<T> where T : Entidad, new()
    {
        private readonly ApplicationDbContext _context;

        public Repositorio(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Actualizar(T entidad)
        {
            _context.Entry(entidad).State = EntityState.Modified;
            _context.SaveChanges();          
        }
        public void Agregar(T entidad)
        {
            entidad.EstaBorrado = false;
            _context.Entry(entidad).State = EntityState.Added;
            _context.SaveChanges();
        }
        public int Contar(Expression<Func<T, bool>> where)
        {
            return _context.Set<T>().Where(where).Count();
        }
        public void Eliminar(int id)
        {
            var entidad = new T() { Id = id };
            _context.Entry(entidad).State = EntityState.Deleted;
            _context.SaveChanges();
        }
        public T ObtenerPorId(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<T> OdtenerLista() 
        {
            return _context.Set<T>();
        }        
        public IEnumerable<T> EncontrarPor(ParametrosDeQuery<T> parametrosDeQuery)
        {
            var orderByClass = ObtenerOrderBy(parametrosDeQuery);
            Expression<Func<T, bool>> whereTrue = x => true;
            var where = (parametrosDeQuery.Where == null) ? whereTrue : parametrosDeQuery.Where;

            if (orderByClass.IsAscending)
            {
                return _context.Set<T>().Where(where).OrderBy(orderByClass.OrderBy)
                .Skip((parametrosDeQuery.Pagina - 1) * parametrosDeQuery.Top)
                .Take(parametrosDeQuery.Top).ToList();
            }
            else
            {
                return _context.Set<T>().Where(where).OrderByDescending(orderByClass.OrderBy)
                .Skip((parametrosDeQuery.Pagina - 1) * parametrosDeQuery.Top)
                .Take(parametrosDeQuery.Top).ToList();
            }
        }
        private OrderByClass ObtenerOrderBy(ParametrosDeQuery<T> parametrosDeQuery)
        {
            if (parametrosDeQuery.OrderBy == null && parametrosDeQuery.OrderByDescending == null)
            {
                return new OrderByClass(x => x.Id, true);
            }

            return (parametrosDeQuery.OrderBy != null)
                ? new OrderByClass(parametrosDeQuery.OrderBy, true) :
                new OrderByClass(parametrosDeQuery.OrderByDescending, false);
        }


        private class OrderByClass
        {
            public OrderByClass()
            {
            }

            public OrderByClass(Func<T, object> orderBy, bool isAscending)
            {
                OrderBy = orderBy;
                IsAscending = isAscending;
            }

            public Func<T, object> OrderBy { get; set; }
            public bool IsAscending { get; set; }
        }
    }
}
