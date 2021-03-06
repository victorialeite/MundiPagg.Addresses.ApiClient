# MundiPagg.Addresses.ApiClient
An API client to use maps resource powered by MundiPagg

# API Reference

http://docs.addressesmundipagg.apiary.io

# Getting started

Installs NuGet package:

```
Install-Package MundiPagg.Addresses.ApiClient
```

Implements your code:

```c#
IAddressesClient client = new AddressesClient("https://api.mundipagg.com/maps/v1.0"); 

BaseResponse<GetAddressPerCountryAndZipCodeResponse> result = client.GetAddressPerCountryAndZipCode(CountryEnum.BR, "20740321");
if (result.IsSuccess == true) 
{
    // Access address data in result.Data
}
else
{
    // Can't be possible get result
}
```

Maps API only use TLS 1.1 or TLS 1.2, to fix this, implement this code:

```c#
ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
```

# Dependencies

- RestSharp 105.2.3

# Author

[Victoria Leite](mailto:victorialeitemarques8@gmail.com)
