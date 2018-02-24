using System;
using System.Data.Entity;
using System.Linq;

namespace ComercioElectronico.Models
{
    public class ComercioElectronicoContext : DbContext, IComercioElectronicoContext
    {
        public ComercioElectronicoContext() : base()
        {
            this.Database.CommandTimeout = 180;
        }

        public DbSet<ProductoModel> Productos { get; set; }
        public DbSet<CarritoModel> Carritos { get; set; }
        public DbSet<PagoCarritoModel> Pagos { get; set; }

        IQueryable<ProductoModel> IComercioElectronicoContext.Productos
        {
            get { return Productos; }
        }

        IQueryable<CarritoModel> IComercioElectronicoContext.Carritos
        {
            get { return Carritos; }
        }

        int IComercioElectronicoContext.SaveChanges()
        {
            return SaveChanges();
        }

        public T Add<T>(T entity) where T : class
        {
            return Set<T>().Add(entity);
        }

        public ProductoModel FindProductoById(int ID)
        {
            return Set<ProductoModel>().Find(ID);
        }

        public T Delete<T>(T entity) where T : class
        {
            return Set<T>().Remove(entity);
        }
    }
}