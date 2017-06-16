using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundiPagg.Addresses.ApiClient.Models
{
    public class SearchAddressesResponse
    {
        public List<GetAddressPerCountryAndZipCodeResponse> Data { get; set; }

        public PagingResponse Paging { get; set; }
    }
}
