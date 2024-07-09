using VantageOnlineCustomer.Classes.CustomerCore;

namespace CustomerBusinessLogic.CustomerService
{
    public interface ICustomerService
    {
        void CreateCustomer(Customer customer);
        void DeleteCustomer(int id);
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void UpdateCustomer(Customer customer);
    }
}