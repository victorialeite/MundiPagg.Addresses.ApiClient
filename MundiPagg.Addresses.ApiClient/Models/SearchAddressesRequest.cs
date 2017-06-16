using MundiPagg.Addresses.ApiClient.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundiPagg.Addresses.ApiClient.Models
{
    public class SearchAddressesRequest
    {
        public CountryEnum Country { get; set; }

        public string Street { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Page { get; set; }

        public int Size { get; set; }
    }
}
