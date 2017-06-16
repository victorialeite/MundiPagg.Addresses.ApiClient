using MundiPagg.Addresses.ApiClient.Enums;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundiPagg.Addresses.ApiClient.Models
{
    public class GetAddressPerCountryAndZipCodeResponse
    {
        public string Street { get; set; }

        public string District { get; set; }

        [SerializeAs(Name = "zip_code")]
        public string ZipCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public CountryEnum Country { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
    }
}
