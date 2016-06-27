# IDCardApplication
This RESTful program helps to apply Identification cards

Used technologies:
* Entity Framework, code first
* ASP.NET Web API
* WPF (Microsoft.AspNet.WebApi REST communication library)
* Unfortunately I was not able to integrate Entity framework with embedded database.

## Database model diagram(ERD):
![alt tag](http://phonewe.freeiz.com/IDApplication.png)



To run the program:
* You must first run Server/Server.sln with Visual Studio.
* Run without debug mode ctrl + F5.
* After server is sucessfully started you can chek if service endpoints work in your browser(check endpoints below):
* Run project Client/Client.sln with Visual Studio
* Run without debug mode ctrl + F5.


## Server-side app
Services return JSON data.

Service endpoints:
* GET all ID applications : http://localhost:21855/api/idapplications
* GET an ID application by ID number : http://localhost:21855/api/idapplication/{id_number}
* GET an ID application by search query : http://localhost:21855/api/idapplications/{searchquery}
* GET all logs : http://localhost:21855/api/logs
* POST ID application : http://localhost:21855/api/idapplication
* POST log : http://localhost:21855/api/log

An example of returned JSON using GET method on URL http://localhost:21855/api/idapplications:

```json
[
  {
    "$id": "2",
    "idApplicationId": 2,
    "firstName": "Andreas",
    "lastName": "Plado",
    "nationality": "Eesti",
    "gender": "M",
    "birthDate": "23.04.1992 0:00.00",
    "idNumber": "39207250239",
    "imagePath": "10400760_1091180020925589_8023189696647230026_n.jpg",
    "address": "Hooldekodu tee 2",
    "county": "Eesti",
    "country": "Harju",
    "zipCode": "10139",
    "issuerFirstName": "Steffi",
    "issuerLastName": "Saava",
    "idReceiptAddress": "Norde Centrum",
    "added": "2016-06-23T01:30:35.817",
    "deleted": null,
    "updated": null
  }
]
```

## Client-side application(WPF):
![alt tag](http://phonewe.freeiz.com/IDApplicationApplying.png)
![alt tag](http://phonewe.freeiz.com/IDApplicationViewing.png)
