﻿using System;
using System.Collections.Generic;

namespace OrderService.Application.Features.Queries.ViewModels
{
    public class OrderDetailViewModel
    {
        public string Ordernumber { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }

        public List<Orderitem> OrderItems { get; set; }
        public decimal Total { get; set; }
    }

    public class Orderitem
    {
        public string Productname { get; set; }
        public int Units { get; set; }
        public double Unitprice { get; set; }
        public string Pictureurl { get; set; }
    }
}
