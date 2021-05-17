using System;
using System.Linq;
using Frontend.Models;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace Frontend.Repository
{
    public class CustomerRepository : IRepository
    {
        private readonly sophiedbContext dbContext;

        public CustomerRepository(sophiedbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Customer GetAccountNumber(Customer model)
        {
            var AccountNumber = dbContext.Customers.FirstOrDefault(x => x.AccountNumber == model.AccountNumber);
            if (AccountNumber == null)
            {
                throw new ArgumentNullException(message:"Your Account Number does not exist.",null);
            }
            return AccountNumber;
        }
    }
}