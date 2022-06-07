using ClassLibraryForTCPConnectionAPI_C_sharp_;
using DatabaseEntities;
using System;
using System.Collections.Generic;

namespace TCPConnectionAPI_C_sharp_
{
    public abstract class AbstractAdminAbilityProto : AbstractClientAbilityProtocol
    {
        abstract public int RegisterNewClient(Client obj);
        abstract public int RegisterNewAdmin(Admin obj);
        abstract public int RegisterNewExpert(Expert obj);
        abstract public List<Client> FindClientsWhere(Func<Client, bool> comparer);
        abstract public List<Admin> FindAdminsWhere(Func<Admin, bool> comparer);
        abstract public List<Expert> FindExpertsWhere(Func<Expert, bool> comparer);
        abstract public bool BanClientsWhere(Func<Client, bool> comparer);
        abstract public bool BanExpertsWhere(Func<Expert, bool> comparer);
        abstract public bool UnbanExpertsWhere(Func<Expert, bool> comparer);
        abstract public bool ModifyExpert(Expert newVersion);
        abstract public bool ModifyClient(Client newVersion);
        abstract public bool UnbanClientsWhere(Func<Client, bool> comparer);
        abstract public bool DeleteClientsWhere(Func<Client, bool> comparer);
        abstract public bool DeleteExpertsWhere(Func<Expert, bool> comparer);
        abstract public bool CreateEmployee(Employee obj);
        abstract public bool ModifyEmployee(Employee newVesrion);
        abstract public bool DeleteEmployeesWhere(Func<Employee, bool> sampler);
        abstract public bool CreateProduct(Product obj);
        abstract public bool ModifyProduct(Product newVesrion);
        abstract public bool DeleteProductsWhere(Func<Product, bool> sampler);
        abstract public string CreateReport();
    }
}
