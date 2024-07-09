using VantageOnlineCustomer.Classes.Customer;

namespace VantageOnlineCustomer.Classes.CustomerCore
{
    public class Customer
    {

        public Customer() { }

        public string Name { get; set; }

        public Address Address { get; set; }

        public List<Email> Email { get; set; }

        public List<Phone> Phone { get; set; }

        public string Website { get; set; }
        

    }
}
