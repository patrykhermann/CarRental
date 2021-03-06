# CarRental.API

**Overview**
----
  CarRental.API is an REST API with CRUD operations

**Common Statuses and Errors**
---
**Statuses**
* 200 - OK
* 201 - Created
* 204 - NoContent

**Errors**
* 400 - Bad Request
* 402 - Request Failed
* 404 - Not Found
* 415 - Unsupported Media Type

**Clients resources**
----
 **Model**
```csharp
[Key]
public Guid Id { get; set; }

[Required]
[MaxLength(50)]
public string FirstName { get; set; }

[Required]
[MaxLength(50)]
public string LastName { get; set; }

[Required]
public DateTimeOffset DateOfBirth { get; set; }

[Required]
[RegularExpression("^\\d{9}$")]
public string PhoneNumber { get; set; }

[Required]
[EmailAddress]
public string Email { get; set; }

public ICollection<Rental> Rentals { get; set; }
    = new List<Rental>();
```
* **Methods and endpoints**

| Method  | Endpoint | Description  |
| ------------- | ------------- | ------------- |
| GET  | `/api/clients/`  | Get list of clients |
| GET  | `/api/clients/{clientId}`  | Get specific client |
| HEAD | `/api/clients/` | Get headers |
| POST | `/api/clients/` | Create a client |
| PUT | `/api/clients/{clientId}` | Update a specific client |
| PATCH | `/api/clients/{clientId}` | Update a specific client |
| DELETE | `/api/clients/{clientId}` | Delete a specific client |

* **Searching**  
  Allowed: Yes  
  Example: `/api/clients?searchQuery=nowak`  
 * **Filtering**  
 Allowed: *No*  
 By: -  
 Example: -  

* **Example Request Body for POST and PUT**
```json
{
  "firstName": "Marek",
  "lastName": "Andrzejczak",
  "dateOfBirth": "1968-03-04T00:00:00",
  "phoneNumber": "829392832",
  "email": "marek@andrzejczak.com"
}
```

* **Example Request Body for PATCH**
```json
[
  {
    "op": "replace",
    "path": "/email",
    "value": "my-new-email@gmail.com"
  }
]
```

**Cars resources**
----
* **Model**
```csharp
[Required]
public Guid Id { get; set; }

[Required]
[MaxLength(50)]
public string Brand { get; set; }

[Required]
[MaxLength(50)]
public string Model { get; set; }

[Required]
public decimal PricePerDay { get; set; }
```
* **Methods and endpoints**

| Method  | Endpoint | Description  |
| ------------- | ------------- | ------------- |
| GET  | `/api/cars/`  | Get list of cars|
| GET  | `/api/cars/{carId}`  | Get specific car|
| HEAD | `/api/cars/` | Get headers |
| POST | `/api/cars/` | Create a car|
| PUT | `/api/cars/{carId}` | Update a specific car|
| PATCH | `/api/cars/{carId}` | Update a specific car|
| DELETE | `/api/cars/{carId}` | Delete a specific car|

* **Searching**  
  Allowed: Yes  
  Example: `/api/cars?searchQuery=opel`  
 * **Filtering**  
 Allowed: Yes  
 By: Brand, PricePerDay  
 Example: `/api/cars?pricePerDay=109&brand=seat`  

* **Example Request Body for POST and PUT**
```json
{
  "brand": "Ford",
  "model": "Fiesta",
  "pricePerDay": 89
}
```

* **Example Request Body for PATCH**
```json
[
  {
    "op": "replace",
    "path": "/pricePerDay",
    "value": "150"
  }
]
```

**Rentals resources**
----
* **Model**
```csharp
[Required]
public Guid Id { get; set; }

[Required]
public DateTimeOffset PickUpDate { get; set; }

[Required]
public DateTimeOffset DropOffDate { get; set; }

[Required]
[MaxLength(50)]
public string PickUpLocation { get; set; }

[Required]
[MaxLength(50)]
public string DropOffLocation { get; set; }

[Required]
public decimal FullPrice { get; set; }

[Range(0, 100)]
public int Discount { get; set; } = 0;

[ForeignKey("CarId")]
public Car Car { get; set; }
public Guid CarId { get; set; }

[ForeignKey("ClientId")]
public Client Client { get; set; }
public Guid ClientId { get; set; }
```
* **Methods and endpoints**

| Method  | Endpoint | Description  |
| ------------- | ------------- | ------------- |
| GET  | `/api/rentals/`  | Get list of rentals|
| GET  | `/api/rentals/{rentalId}`  | Get specific rental|
| HEAD | `/api/rentals/` | Get headers |
| POST | `/api/rentals/` | Create a car|
| PUT | `/api/rentals/{rentalId}` | Update a specific rental|
| PATCH | `/api/rentals/{rentalId}` | Update a specific rental|
| DELETE | `/api/rentals/{rentalId}` | Delete a specific rental|

* **Searching**  
  Allowed: No <br />
  Example: -  
 * **Filtering**  
 Allowed: No <br />
 By: - <br />
 Example: -  <br />

* **Example Request Body for POST and PUT**
```json
{
  "pickUpDate": "2020-02-01T10:20:00",
  "dropOffDate": "2020-02-11T10:20:00",
  "pickUpLocation": "Poznań, Dworzec Główny",
  "dropOffLocation": "Poznań, Dworzec Główny",
  "discount": 15,
  "car": {
    "brand": "Audi",
    "model": "A6",
    "pricePerDay": 229
  },
  "client": {
    "firstName": "Roman",
    "lastName": "Czosnek",
    "dateOfBirth": "1981-05-10T00:00:00",
    "phoneNumber": "654789321",
    "email": "czosnkowy@gmail.com"
  }
}
```

* **Example Request Body for PATCH**
```json
[
  {
    "op": "replace",
    "path": "/dropOffLocation",
    "value": "Gdańsk, Lotnisko im. Lecha Wałęsy"
  }	
]
```

**Additional information**
---
In main repository folder you can find file `CarRental.API.postman_collection.json` which contains every allowed request to an API. You can import that file to the Postman and test an API from there.
