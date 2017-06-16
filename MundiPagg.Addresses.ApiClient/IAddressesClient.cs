using MundiPagg.Addresses.ApiClient.Enums;
using MundiPagg.Addresses.ApiClient.Models;

namespace MundiPagg.Addresses.ApiClient
{
    public interface IAddressesClient
    {
        /// <summary>
        /// List all states per country
        /// </summary>
        /// <param name="country">Initials of country - Use country enum</param>
        /// <returns>Base response with list of states</returns>
        BaseResponse<ListAllStatesPerCountryResponse> ListAllStatesPerCountry(CountryEnum country);

        BaseResponse<ListAllCitiesPerStateResponse> ListAllCitiesPerState(CountryEnum country, string state);

        BaseResponse<ListAllDistrictsPerCityResponse> ListAllDistrictsPerCity(CountryEnum country, string state, string city);

        BaseResponse<GetAddressPerCountryAndZipCodeResponse> GetAddressPerCountryAndZipCode(CountryEnum country, string zipCode);

        BaseResponse<SearchAddressesResponse> SearchAddresses(SearchAddressesRequest request);
    }
}
