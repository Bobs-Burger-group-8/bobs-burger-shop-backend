# bobs-burger-shop-backend
Boolean case - a simple burger shop -  backend( .NET, C#)

## Install Nugets

- Install the following packages into the WebApi project:

- Install-Package Microsoft.EntityFrameworkCore
- Install-Package Microsoft.EntityFrameworkCore.Tools
- Install-Package Microsoft.EntityFrameworkCore.Design
- Install-Package NpgSql.EntityFrameworkCore.PostgreSql
- Install-Package Microsoft.AspNetCore.Authentication.JwtBearer
- Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore

## Configure Json

Create a new appsettings.json / appsettings.Development.json (see appsettings.Example.json) add the following json and update credentials
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnectionString": "Host=HOST; Database=DATABASE; Username=USERNAME; Password=PASSWORD; "
  },
  "SiteSettings": {
    "AdminEmail": "example@test.com",
    "AdminPassword": "administrator"
  },
  "JwtTokenSettings": {
    "ValidIssuer": "ExampleIssuer",
    "ValidAudience": "ExampleAudience",
    "SymmetricSecurityKey": "v89h3bh89vh9ve8hc89nv98nn899cnccn998ev80vi809jberh89b",
    "JwtRegisteredClaimNamesSub": "rbveer3h535nn3n35nyny5umbbt"
  }
}
```

## Entity Relation Diagram

The ERD can be found in the Bobs-Burgers-ERD.png file or here: <https://whimsical.com/bobs-burgers-EdCdhPHw1uZuvRn8Vyi3TF>
