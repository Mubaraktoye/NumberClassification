# Number Classification API

## Description
The Number Classification API is a simple web service that classifies numbers based on various mathematical properties. It determines whether a number is prime, perfect, Armstrong, or odd/even, and provides a fun fact about the number using the Numbers API.

## Features
- Checks if a number is prime.
- Determines if a number is perfect.
- Identifies Armstrong numbers.
- Classifies numbers as odd or even.
- Calculates the digit sum of the number.
- Fetches a fun fact from the Numbers API.

## Technology Stack
- Programming Language: C# (.NET 6)
- Framework: ASP.NET Core Web API
- External API: Numbers API (http://numbersapi.com)
- Dependency Injection: Built-in .NET DI
- Hosting: Deployed to a publicly accessible endpoint(Render)
- CORS Handling: Configured for cross-origin requests

## Installation and Setup
### Prerequisites
- .NET 6 SDK installed
- Visual Studio or VS Code
- Internet connection (for external API requests)

### Steps to Run Locally
1. Clone the repository:
   ```sh
   git clone https://github.com/mubaraktoye/number-classification-api.git
   cd number-classification-api
   ```
2. Restore dependencies:
   ```sh
   dotnet restore
   ```
3. Run the application:
   ```sh
   dotnet run
   ```
4. The API will be available at:
   ```sh
   http://localhost:7234/api/classify-number?number=371
   ```

## API Documentation
### Endpoint
```
GET /api/classify-number?number=<integer>
```

### Request Parameters
| Parameter | Type   | Description                 |
|-----------|--------|-----------------------------|
| number  | int | The number to classify.     |

### Response (200 OK)
```json
{
    "number": 371,
    "is_prime": false,
    "is_perfect": false,
    "properties": ["armstrong", "odd"],
    "digit_sum": 11,
    "fun_fact": "371 is an Armstrong number because 3^3 + 7^3 + 1^3 = 371"
}
```

### Response (400 Bad Request)
```json
{
    "number": "invalid_value",
    "error": true
}
```

## Deployment
The API is deployed at:
```
<https://numberclassification-dkg0.onrender.com>/api/classify-number?number=371
```

## Additional Resources
- Numbers API documentation: [Numbers API](http://numbersapi.com/#42)
- Mathematical properties: [Wikipedia - Parity (Mathematics)](https://en.wikipedia.org/wiki/Parity_(mathematics))


