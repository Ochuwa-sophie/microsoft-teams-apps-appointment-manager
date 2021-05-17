using Frontend.Models;

namespace Frontend.Repository
{
    public interface IRepository
    {
         Customer GetAccountNumber(Customer model);

    }
}