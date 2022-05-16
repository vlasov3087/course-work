using System;
using DatabaseEntities;
namespace TCPConnectionAPI_C_sharp_
{
    public interface IDataModifyPermission : IDataViewPermision
    {
        int CreateEmployee(Employee obj);
        bool DeleteEmployee(Func<Employee, bool> comparer);
        bool UpdateEmployee(Employee newVersion);

        int CreateProduct(Product obj);
        bool DeleteProduct(Func<Product, bool> comparer);
        bool UpdateProduct(Product newVersion);
    }
}
