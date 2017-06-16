using MundiPagg.Addresses.ApiClient.Enums;
using MundiPagg.Addresses.ApiClient.Models;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace MundiPagg.Addresses.ApiClient
{
    public class AddressesClient : IAddressesClient
    {
        private IRestClient RestClient { get; set; }

        public AddressesClient(string apiUrl)
        {
            this.RestClient = new RestClient(apiUrl);
        }

        public BaseResponse<ListAllStatesPerCountryResponse> ListAllStatesPerCountry(CountryEnum country)
        {
            var response = new BaseResponse<ListAllStatesPerCountryResponse>();

            var restRequest = new RestRequest("{country}/states", Method.GET);
            restRequest.AddUrlSegment("country", country.ToString());
            restRequest.RequestFormat = DataFormat.Json;

            var restResponse = this.RestClient.Execute<List<string>>(restRequest);

            if (restResponse.ErrorException != null)
            {
                throw restResponse.ErrorException;
            }

            response.StatusCode = restResponse.StatusCode;
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                response.IsSuccess = true;
                response.Data = new ListAllStatesPerCountryResponse();
                response.Data.States = restResponse.Data;
            }
            else
            {
                response.IsSuccess = false;
            }
            
            return response;
        }

        public BaseResponse<ListAllCitiesPerStateResponse> ListAllCitiesPerState(CountryEnum country, string state)
        {
            var response = new BaseResponse<ListAllCitiesPerStateResponse>();

            var restRequest = new RestRequest("{country}/{state}/cities", Method.GET);
            restRequest.AddUrlSegment("country", country.ToString());
            restRequest.AddUrlSegment("state", state);
            restRequest.RequestFormat = DataFormat.Json;

            var restResponse = this.RestClient.Execute<List<string>>(restRequest);

            if (restResponse.ErrorException != null)
            {
                throw restResponse.ErrorException;
            }

            response.StatusCode = restResponse.StatusCode;
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                response.IsSuccess = true;
                response.Data = new ListAllCitiesPerStateResponse();
                response.Data.Cities = restResponse.Data;
            }
            else
            {
                response.IsSuccess = false;
            }
            
            return response;
        }

        public BaseResponse<ListAllDistrictsPerCityResponse> ListAllDistrictsPerCity(CountryEnum country, string state, string city)
        {
            var response = new BaseResponse<ListAllDistrictsPerCityResponse>();

            var restRequest = new RestRequest("{country}/{state}/{city}/districts", Method.GET);
            restRequest.AddUrlSegment("country", country.ToString());           
            restRequest.AddUrlSegment("state", state.ToString());
            restRequest.AddUrlSegment("city", city.ToString());
            restRequest.RequestFormat = DataFormat.Json;

            var restResponse = this.RestClient.Execute<List<string>>(restRequest);

            if (restResponse.ErrorException != null)
            {
                throw restResponse.ErrorException;
            }

            response.StatusCode = restResponse.StatusCode;
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                response.IsSuccess = true;
                response.Data = new ListAllDistrictsPerCityResponse();
                response.Data.Districts = restResponse.Data;
            }
            else
            {
                response.IsSuccess = false;
            }

            return response;
        }

        public BaseResponse<GetAddressPerCountryAndZipCodeResponse> GetAddressPerCountryAndZipCode(CountryEnum country, string zipCode)
        {
            var response = new BaseResponse<GetAddressPerCountryAndZipCodeResponse>();

            var restRequest = new RestRequest("{country}/{zipCode}", Method.GET);
            restRequest.AddUrlSegment("country", country.ToString());
            restRequest.AddUrlSegment("zipCode", zipCode);
            restRequest.RequestFormat = DataFormat.Json;

            var restResponse = this.RestClient.Execute<GetAddressPerCountryAndZipCodeResponse>(restRequest);

            if (restResponse.ErrorException != null)
            {
                throw restResponse.ErrorException;
            }

            response.StatusCode = restResponse.StatusCode;
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                response.IsSuccess = true;
                response.Data = restResponse.Data;
            }
            else
            {
                response.IsSuccess = false;
            }

            return response;
        }

        public BaseResponse<SearchAddressesResponse> SearchAddresses(SearchAddressesRequest request)
        {
            var response = new BaseResponse<SearchAddressesResponse>();

            var restRequest = new RestRequest("{country}", Method.GET);
            restRequest.AddUrlSegment("country", request.Country.ToString());
            restRequest.RequestFormat = DataFormat.Json;

            restRequest.AddQueryParameter("size", request.Size.ToString());
            restRequest.AddQueryParameter("page", request.Page.ToString());
            restRequest.AddQueryParameter("state", request.State);
            restRequest.AddQueryParameter("city", request.City);
            restRequest.AddQueryParameter("street", request.Street);

            var restResponse = this.RestClient.Execute<SearchAddressesResponse>(restRequest);

            if (restResponse.ErrorException != null)
            {
                throw restResponse.ErrorException;
            }

            response.StatusCode = restResponse.StatusCode;
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                response.IsSuccess = true;
                response.Data = restResponse.Data;
            }
            else
            {
                response.IsSuccess = false;
            }

            return response;
        }
    }
}
