namespace VantageOnlineCustomer.Classes.Customer
{
    public class Contacts
    {

        public Contacts() { }
        public string Name { get; set; }

        public Address Address { get; set; }

        public List<Email> Email { get; set; }

        public List<Phone> Phone { get; set; }


    }
}
