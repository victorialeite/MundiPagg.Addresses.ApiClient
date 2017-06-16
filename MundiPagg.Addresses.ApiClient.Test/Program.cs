using MundiPagg.Addresses.ApiClient.Enums;
using MundiPagg.Addresses.ApiClient.Models;
using System;
using System.Net;

namespace MundiPagg.Addresses.ApiClient.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;

            TestListAllStatesPerCountry();
            TestListAllCitiesPerState();
            TestListAllDistrictsPerCity();
            TestGetAddressPerCountryAndZipCode();
            TestSearchAddresses();

            Console.ReadKey();
        }

        public static void TestListAllStatesPerCountry()
        {
            Console.WriteLine("## TestListAllStatesPerCountry");
            IAddressesClient client = new AddressesClient("https://api.mundipagg.com/maps/v1.0");

            try
            {
                var result = client.ListAllStatesPerCountry(CountryEnum.BR);

                if (result.Data != null)
                {
                    result.Data.States.ForEach(state => Console.WriteLine(state));
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Não foi possível obter resultados!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("-- Exception!");
                Console.WriteLine(ex.Message);
            }
        }

        public static void TestListAllCitiesPerState()
        {
            Console.WriteLine("## TestListAllCitiesPerState");
            IAddressesClient client = new AddressesClient("https://api.mundipagg.com/maps/v1.0");

            try
            {
                var result = client.ListAllCitiesPerState(CountryEnum.BR, "RJ");

                if (result.Data != null)
                {
                    result.Data.Cities.ForEach(citie => Console.WriteLine(citie));
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Não foi possível obter resultados!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("-- Exception!");
                Console.WriteLine(ex.Message);
            }
        }

        public static void TestListAllDistrictsPerCity()
        {
            Console.WriteLine("## TestListAllDistrictsPerCity");
            IAddressesClient client = new AddressesClient("https://api.mundipagg.com/maps/v1.0");

            try
            {
                var result = client.ListAllDistrictsPerCity(CountryEnum.BR, "RJ", "Rio de Janeiro");

                if (result.Data != null)
                {
                    result.Data.Districts.ForEach(districts => Console.WriteLine(districts));
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Não foi possível obter resultados!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("-- Exception!");
                Console.WriteLine(ex.Message);
            }
        }

        public static void TestGetAddressPerCountryAndZipCode()
        {
            Console.WriteLine("## TestGetAddressPerCountryAndZipCode");
            IAddressesClient client = new AddressesClient("https://api.mundipagg.com/maps/v1.0");

            try
            {
                var result = client.GetAddressPerCountryAndZipCode(CountryEnum.BR, "20740321");

                if (result.Data != null)
                {
                    Console.WriteLine("Street: {0}", result.Data.Street);
                    Console.WriteLine("District: {0}", result.Data.District);
                    Console.WriteLine("City: {0}", result.Data.City);
                    Console.WriteLine("Country: {0}", result.Data.Country);
                    Console.WriteLine("State: {0}", result.Data.State);
                    Console.WriteLine("ZipCode: {0}", result.Data.ZipCode);

                    foreach (var item in result.Data.Metadata)
                    {
                        Console.WriteLine("{0}: {1}", item.Key, item.Value);
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Não foi possível obter resultados!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("-- Exception!");
                Console.WriteLine(ex.Message);
            }
        }

        public static void TestSearchAddresses()
        {
            Console.WriteLine("## TestSearchAddresses");
            IAddressesClient client = new AddressesClient("https://api.mundipagg.com/maps/v1.0");

            try
            {
                var request = new SearchAddressesRequest()
                {
                    Page = 1,
                    Size = 10,
                    Country = CountryEnum.BR,
                    State = "RJ",
                    City = "Rio de Janeiro",
                    Street = "Rua Clarimundo de Melo"
                };

                var result = client.SearchAddresses(request);

                if (result.Data != null)
                {
                    result.Data.Data.ForEach(address =>
                    {
                        Console.WriteLine("Street: {0}", address.Street);
                        Console.WriteLine("District: {0}", address.District);
                        Console.WriteLine("City: {0}", address.City);
                        Console.WriteLine("Country: {0}", address.Country);
                        Console.WriteLine("State: {0}", address.State);
                        Console.WriteLine("ZipCode: {0}", address.ZipCode);

                        foreach (var item in address.Metadata)
                        {
                            Console.WriteLine("{0}: {1}", item.Key, item.Value);
                        }
                        Console.WriteLine();
                    });

                    Console.WriteLine("Pages: {0}", result.Data.Paging.Pages);
                    Console.WriteLine("FirstItem: {0}", result.Data.Paging.FirstItem);
                    Console.WriteLine("LastItem: {0}", result.Data.Paging.LastItem);
                    Console.WriteLine("TotalItems: {0}", result.Data.Paging.TotalItems);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Não foi possível obter resultados!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("-- Exception!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
