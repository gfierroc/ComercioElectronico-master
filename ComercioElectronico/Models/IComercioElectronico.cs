using System.Linq;

namespace ComercioElectronico.Models
{
    interface IComercioElectronicoContext
    {
        IQueryable<ProductoModel> Productos { get; }
        IQueryable<CarritoModel> Carritos { get; }
        int SaveChanges();
        T Add<T>(T entity) where T : class;
        ProductoModel FindProductoById(int ID);
        //CarritoModel FindCommentById(int ID);
        T Delete<T>(T entity) where T : class;
    }
}
