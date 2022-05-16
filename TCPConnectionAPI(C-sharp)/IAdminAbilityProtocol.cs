using ClassLibraryForTCPConnectionAPI_C_sharp_;
using DatabaseEntities;
using System;
using System.Collections.Generic;

namespace TCPConnectionAPI_C_sharp_
{
    public interface IAdminAbilityProtocol : IClientAbilityProtocol
    {
        int RegisterNewClient(Client obj);
        int RegisterNewAdmin(Admin obj);
        int RegisterNewExpert(Expert obj);
        List<Client> FindClientsWhere(Func<Client, bool> comparer);
        List<Admin> FindAdminsWhere(Func<Admin, bool> comparer);
        List<Expert> FindExpertsWhere(Func<Expert, bool> comparer);
        bool BanClientsWhere(Func<Client, bool> comparer);
        bool BanExpertsWhere(Func<Expert, bool> comparer);
        bool UnbanExpertsWhere(Func<Expert, bool> comparer);
        bool ModifyExpert(Expert newVersion);
        bool ModifyClient(Client newVersion);
        bool UnbanClientsWhere(Func<Client, bool> comparer);
        bool DeleteClientsWhere(Func<Client, bool> comparer);
        bool DeleteExpertsWhere(Func<Expert, bool> comparer);
        bool CreateEmployee(Employee obj);
        bool ModifyEmployee(Employee newVesrion);
        bool DeleteEmployeesWhere(Func<Employee, bool> sampler);
        bool CreateProduct(Product obj);
        bool ModifyProduct(Product newVesrion);
        bool DeleteProductsWhere(Func<Product, bool> sampler);
        string CreateReport();
    }
}
