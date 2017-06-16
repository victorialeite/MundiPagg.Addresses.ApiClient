using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundiPagg.Addresses.ApiClient.Models
{
    public class PagingResponse
    {
        public int Pages { get; set; }

        [SerializeAs(Name = "first_item")]
        public string FirstItem { get; set; }

        [SerializeAs(Name = "last_item")]
        public string LastItem { get; set; }

        [SerializeAs(Name = "total_items")]
        public string TotalItems { get; set; }
    }
}
