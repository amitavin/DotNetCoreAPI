# 🍽️ Restaurant API – .NET 8 + MongoDB + Clean Architecture

Welcome to the **Restaurant API**! 🚀  
This is a clean, scalable, and production-ready Web API built with **.NET 8**, using **MongoDB** for data storage and following **Clean Architecture principles**.

Use this API to manage your restaurant's menu items including name, price, description, availability, and category.

---

## 📦 Tech Stack

- 🟦 **.NET 8 Web API**
- 🍃 **MongoDB (NoSQL)**
- 🧱 **Clean Architecture (API, Application, Infrastructure, Domain, Tests)**
- 📑 **Swagger** for API docs
- 🔎 **Health Checks**
- 🧪 **xUnit** for unit testing
- 🧰 Dependency Injection, Logging, Validation, Auth (in upcoming steps)

---

## 🧾 Folder Structure

```
RestaurantApi/
├── RestaurantApi.API/                 # API layer (Controllers, Program.cs)
│   ├── Controllers/
│   ├── Program.cs
│   └── appsettings.json
├── RestaurantApi.Application/         # Business logic layer (Services)
│   ├── Services/
│   └── Interfaces/
├── RestaurantApi.Domain/              # Core entities & contracts
│   ├── Entities/
│   └── Interfaces/
├── RestaurantApi.Infrastructure/      # DB context, Repositories
│   ├── Data/
│   └── Repositories/
├── RestaurantApi.Tests/               # Unit Tests using xUnit
│   ├── Controllers/
│   ├── Services/
│   └── Repositories/
└── RestaurantApi.sln                  # .NET solution file
```

---

## 📌 Entity: `MenuItem`

```json
{
  "id": "abc123",
  "name": "Cheeseburger",
  "description": "Juicy grilled cheeseburger",
  "price": 9.99,
  "category": "Main",
  "isAvailable": true
}
```

---

## 🔧 API Endpoints

| Method | Endpoint               | Description             |
|--------|------------------------|-------------------------|
| GET    | `/api/menuitems`       | Get all menu items      |
| GET    | `/api/menuitems/{id}`  | Get a menu item by ID   |
| POST   | `/api/menuitems`       | Create a new menu item  |
| PUT    | `/api/menuitems/{id}`  | Update an existing item |
| DELETE | `/api/menuitems/{id}`  | Delete a menu item      |
| GET    | `/health`              | Check service health    |

---

## ⚙️ MongoDB Configuration

In `appsettings.json`:

```json
{
  "MongoDb": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "RestaurantDb"
  }
}
```

Override these with environment variables for production use.

---

## 🧠 Clean Architecture Principles

This project is structured based on **Clean Architecture**:

- 🧩 **Domain** – core business entity (`MenuItem`)
- 🧠 **Application** – business logic (`MenuItemService`)
- 💾 **Infrastructure** – data access (`MongoContext`, `MenuItemRepository`)
- 🌐 **API** – controllers and API logic (`MenuItemsController`)
- 🧪 **Tests** – unit tests using xUnit

**Benefits:**
- Separation of concerns ✅  
- Testability ✅  
- Scalable and maintainable ✅

---

## ▶️ Getting Started

1. **Clone the repo**:
   ```bash
   git clone https://github.com/amitavin/restaurant-api.git
   cd restaurant-api
   ```

2. **Run the API**:
   ```bash
   dotnet run --project RestaurantApi.API
   ```

3. **View in browser**:
   ```
   https://localhost:5001/swagger/index.html
   ```

4. **Test MongoDB connection** (ensure MongoDB is running locally):
   ```
   GET /api/menuitems
   ```

---

## 🗃️ Next Steps (To Be Implemented)

- ✅ Input validation  
- ✅ Serilog for structured logging  
- ✅ JWT authentication & role-based authorization  
- ✅ Global exception handling  
- ✅ Unit test coverage with xUnit + Moq  

---

## 🙌 Contribution & Learning

This project is part of my learning and exploration of modern .NET backend development using MongoDB and clean architectural practices.

Feel free to fork, clone, or contribute!

---

## 🛡️ Global Exception Handling

We've implemented comprehensive global exception handling middleware to ensure robust error management across the API.

### Features
- **Centralized Error Handling**: Catches all unhandled exceptions across the API
- **Structured Logging**: Integrates with configured loggers (Serilog support ready for future implementation)
- **Consistent Error Response**: Returns standardized JSON error responses
- **Environment-Aware**: Protects production environments from exposing sensitive information

### Error Response Format
```json
{
  "statusCode": 500,
  "message": "Something went wrong!",
  "stackTrace": "..." // Only included in Development environment
}
```

### Implementation
The middleware is registered in the application pipeline:
```csharp
app.UseMiddleware<ExceptionHandlingMiddleware>();
```

### Testing
To test the exception handling functionality, use the dedicated test endpoint:
```
GET /api/menuitems/test-error
```

This endpoint intentionally throws an exception to demonstrate the middleware's error handling capabilities.

---


## 🧑‍💻 Author

**Amit Kumar Sharma**  
🌐 [LinkedIn](https://www.linkedin.com/in/amitavin)  
📍 Sitecore Certified Developer | .NET Fullstack Engineer | Clean Code Enthusiast
