using DatabaseEntities;
using System.Collections.Generic;

namespace TCPConnectionAPIClientModule_C_sharp_
{
    public interface IDataViewAccess
    {
        List<Employee> GetAllEmployees();
        List<Product> GetAllProducts();
    }
}
