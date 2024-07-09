using VantageOnlineCustomer.DAL;
using VantageOnlineCustomer.Classes.CustomerCore;
using VantageDataAcessLayer.CustomerRepository;
using VantageCoreDomain.Customer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CustomerBusinessLogic.CustomerService;

namespace VantageOnlineCustomer.Tests
{
    [TestFixture]
    public class CustomerServiceTests
    {
        private ServiceProvider _serviceProvider;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("CustomerTestDb"));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        [Test]
        public void CanAddAndRetrieveCustomer()
        {

            //This one and all encompassing test will do a full CRUD

            int generalID = 4000;
            var service = _serviceProvider.GetRequiredService<ICustomerService>();
            var customer = new Customer
            {
                ID = generalID,
                Name = "Ronnie O Sullivan",
                Address = new Address
                {
                    ID = generalID,
                    AddressLine1 = "19 Fletcher Avenue",
                    Country = "UK",
                    Town = "London",
                    PostCode = "E10 6HB"
                },
                Email = new List<Email> { new Email { EmailAddress = "ron.sul@example.com" } },
                Phone = new List<Phone> { new Phone { Number = 1234567890 } },
                Contacts = new List<Contacts> { new Contacts { Name = "Tony" } },
                Website = "http://snooker.com"
            };

            var customer2ND = new Customer
            {
                ID = 6000,
                Name = "Dot Cotton",
                Address = new Address
                {
                    ID = 6000,
                    AddressLine1 = "19 Fletcher Avenue",
                    Country = "UK",
                    Town = "London",
                    PostCode = "B1 6HB"
                },
                Email = new List<Email> { new Email { EmailAddress = "dot@gmail.com" } },
                Phone = new List<Phone> { new Phone { Number = 1234567890 } },
                Contacts = new List<Contacts> { new Contacts { Name = "Roy" } },
                Website = "http://anything.com"
            };

            service.CreateCustomer(customer);
            service.CreateCustomer(customer2ND);
            var retrievedCustomer = service.GetCustomerById(customer.ID);

            // Assert
            Assert.IsNotNull(retrievedCustomer);
            Assert.AreEqual(customer.Name, retrievedCustomer.Name);
            Assert.AreEqual(customer.Address.AddressLine1, retrievedCustomer.Address.AddressLine1);
            Assert.AreEqual(customer.Email.First().EmailAddress, retrievedCustomer.Email.First().EmailAddress);
            Assert.AreEqual(customer.Phone.First().Number, retrievedCustomer.Phone.First().Number);
            Assert.AreEqual(customer.Website, retrievedCustomer.Website);

            Customer CustomerToUpdate = service.GetCustomerById(generalID);
            CustomerToUpdate.Name = "Usman";
            service.UpdateCustomer(CustomerToUpdate);
            service.DeleteCustomer(generalID);
            var customerReturn = service.GetCustomerById(5);
            Assert.IsNull(customerReturn);


        }

        [TearDown]
        public void TearDown()
        {
            _serviceProvider.Dispose();
        }
    }
}
