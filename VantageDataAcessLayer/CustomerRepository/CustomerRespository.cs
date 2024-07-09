using VantageOnlineCustomer.Classes.CustomerCore;
using Microsoft.EntityFrameworkCore;
using VantageDataAcessLayer.CustomerRepository;

namespace VantageOnlineCustomer.DAL
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers
                .Include(c => c.Address)
                .Include(c => c.Email)
                .Include(c => c.Phone)
                .Include(c => c.Contacts)
                .ToList();
        }

        public Customer GetById(int id)
        {
            return _context.Customers
                .Include(c => c.Address)
                .Include(c => c.Email)
                .Include(c => c.Phone)
                .Include(c => c.Contacts)
                .FirstOrDefault(c => c.ID == id);
        }

        public void Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }
    }
}
