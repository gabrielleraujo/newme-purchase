﻿namespace Newmw.Purchase.Application.ViewModels
{
    public class ReadAddressViewModel
    {
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
    }
}