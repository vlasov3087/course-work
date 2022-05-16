using DatabaseEntities;
using System.Collections.Generic;

namespace TCPConnectionAPIClientModule_C_sharp_
{
    public interface IUserViewAccess
    {
        List<Client> GetAllClients();
        List<Expert> GetAllExperts();
        List<Admin> GetAllAdmins();
        Client FindClientByLogin(string login);
        Expert FindExpertByLogin(string login);
        Admin FindAdminByLogin(string login);
    }
}
