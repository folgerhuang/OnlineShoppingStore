﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage="Plesa enter a name")]
        public string Name { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        [Required(ErrorMessage="Please enter a city name")]
        public string City { get; set; }
        [Required(ErrorMessage="Please enter the state name")]
        public string State { get; set; }        
        [Required(ErrorMessage="Please enter your zip code")]
        public string Zip { get; set; }
        [Required(ErrorMessage = "Please enter a contry name")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}
