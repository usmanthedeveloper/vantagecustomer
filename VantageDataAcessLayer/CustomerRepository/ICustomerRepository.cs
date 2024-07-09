using VantageOnlineCustomer.Classes.CustomerCore;

namespace VantageDataAcessLayer.CustomerRepository
{
    public interface ICustomerRepository
    {

        void Create(Customer customer);
        void Delete(int id);
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        void Update(Customer customer);

    }
}