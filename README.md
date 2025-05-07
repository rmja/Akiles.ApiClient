# Akiles.ApiClient
Unofficial API client for [Akiles Access Control](https://akiles.app).
A prerelease package is availble on nuget [![Akiles.ApiClient](https://img.shields.io/nuget/vpre/Akiles.ApiClient.svg)](https://www.nuget.org/packages/Akiles.ApiClient)

The client is native aot compatible.

## Usage
The Akiles API can be used in two ways. Either with an obtained bearer access token ([see doc](https://apidoc.akiles.app/#tag-oauth)) or with a dedicated API key, that can be obtained through Akiles Support.
The client supports both types of keys.

One can use the client manually by using the `AkilesApiClient` directly, or by registering the client to the DI container.

If used with a dedicated API key, register using:

```C#

services.AddAkilesApiClient(options =>
    {
        options.ApiKey = "dedicated api key";
    })

```
and later obtain an `IAkilesApiClient` clients to explore the api.

If used with an obtained bearer token, then register using:

```C#
services.AddAkilesApiClient();
```
and obtain the factory `IAkilesApiClientFactory` from which a client can be created for a given token.

## Status
The implemented API surface should work, but there are missing endpoints. Feel free to create a PR if there are parts that are missing that you need.
