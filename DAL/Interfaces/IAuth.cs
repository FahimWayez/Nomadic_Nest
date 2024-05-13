namespace DAL.Interfaces
{
    public interface IAuth<Ret>
    {
        Ret Authenticate(string unsername, string password);
    }
}
