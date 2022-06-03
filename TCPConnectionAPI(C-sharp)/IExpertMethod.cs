using DatabaseEntities;

namespace TCPConnectionAPI_C_sharp_
{
    public interface IExpertMethod
    {
        void Rate(ref Employee obj, Expert expert, float rate);
    }
}
