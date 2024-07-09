using VantageCoreDomain.Customer;

namespace VantageOnlineCustomer.Classes.CustomerCore
{
    public class Contacts
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }

        public List<Email> Email { get; set; }

        public List<Phone> Phone { get; set; }

    }
}
