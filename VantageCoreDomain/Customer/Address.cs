﻿namespace VantageCoreDomain.Customer;

public class Address
{

    public int ID { get; set; }

    public string AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? Town { get; set; }

    public string? PostCode { get; set; }

    public string Country { get; set; }

}