using System.Net.Http.Json;
using VantageOnlineCustomer.Classes.CustomerCore;
using VantageCoreDomain.Customer;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using CustomerAPI;

namespace MyApi.Tests
{
    [TestFixture]
    public class CustomerApiTests
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            var factory = new WebApplicationFactory<Program>();
            _client = factory.CreateClient();
        }

        [Test]
        public async Task CanAddAndRetrieveCustomer()
        {
            // Arrange
            var customer = new Customer
            {
                ID = 4000,
                Name = "Ronnie O Sullivan",
                Address = new Address
                {
                    ID = 4000,
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

            // Act
            var postResponse = await _client.PostAsJsonAsync("/api/Customer/customer/", customer);
            postResponse.EnsureSuccessStatusCode();

            var retrievedCustomer = await _client.GetFromJsonAsync<Customer>($"/api/Customer/customer/{customer.ID}");

            // Assert
            Assert.IsNotNull(retrievedCustomer);
            Assert.AreEqual(customer.Name, retrievedCustomer.Name);
            Assert.AreEqual(customer.Address.AddressLine1, retrievedCustomer.Address.AddressLine1);
            Assert.AreEqual(customer.Email.First().EmailAddress, retrievedCustomer.Email.First().EmailAddress);
            Assert.AreEqual(customer.Phone.First().Number, retrievedCustomer.Phone.First().Number);
            Assert.AreEqual(customer.Website, retrievedCustomer.Website);

            // Update customer
            customer.Name = "Usman";
            var putResponse = await _client.PutAsJsonAsync($"/api/Customer/customer/{customer.ID}", customer);
            putResponse.EnsureSuccessStatusCode();

            var updatedCustomer = await _client.GetFromJsonAsync<Customer>($"/api/Customer/customer/{customer.ID}");
            Assert.AreEqual("Usman", updatedCustomer.Name);

            // Delete customer
            var deleteResponse = await _client.DeleteAsync($"/api/Customer/customer/{customer.ID}");
            deleteResponse.EnsureSuccessStatusCode();

            var getDeletedCustomerResponse = await _client.GetAsync($"/api/Customer/customer/{customer.ID}");
            Assert.AreEqual(System.Net.HttpStatusCode.NotFound, getDeletedCustomerResponse.StatusCode);
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
        }
    }
}
