# StockApplicationApi 
A stock discussion API where users can post comments about stocks.

### What this thing actually does
* Users can register/login (JWT tokens).
* Create, read, update, and delete stocks.
* Post comments about specific stocks.
* Each comment is tied to a user (no anonymous posting).
* Users are allowed limited comments for a certain time (Rate Limited).
* Users can only edit or delete their **OWN** comments.
* Server-side Pagination & Sorting on stocks and comments so the API doesn't choke on big data.

### Technology used 
* **.NET 9** - Core framework
* **Entity Framework Core** - Talks to **PostgreSQL** (or SQL Server, pick your actual DB here!)
* **Docker & Docker Compose** - Runs the app, Redis, and database containers seamlessly
* **Redis Caching** - Keeps things fast so I don't hit the DB for every request
* **ASP.NET Core Identity** - Handles user registration and logins
* **JWT** - Access tokens + Refresh tokens (stored in the DB)
* **xUnit + Moq** - Unit tests specifically for the service layer
* **FluentValidation** - Validates incoming HTTP requests automatically

### How it's built (layers)
Controller →   Service    →      Repository
↓              ↓                 ↓
DTOs       Business logic      Database

* **Controllers:** Just receive requests, call services, and return responses.
* **Services:** All the core business logic lives here (checking if a stock exists, checking if a user actually owns the comment they are trying to edit, etc.).
* **Repositories:** Handles raw database operations (add, update, delete, find).
* **DTOs:** Data Transfer Objects. What goes in and out of the API to the user, completely hiding internal database models.

### Security Features
* **Refresh token rotation with breach detection**
  * When you request a new access token using a refresh token, the old refresh token gets marked as "used" immediately.
  * You receive a brand new refresh token back.
  * If an attacker tries to replay and use that **SAME** old refresh token again, the system automatically detects it and instantly revokes **ALL** active tokens for that user.
* **Validation at 3 levels**
  1. **FluentValidation:** Checks basic request data formats (e.g., "Stock symbol can't be empty").
  2. **Service layer custom checks:** Enforces business rules (e.g., "Can't comment on non-existent stock").
  3. **Global exception handler:** A middleware that catches anything unexpected (like DB connection failures) so the app doesn't leak raw stack traces.

### Redis Caching Strategy
* **When you hit `GET /api/stocks` or `/api/comments`:**
  * Checks Redis first. If the data exists, it returns straight from the cache (~5ms).
  * If it's a cache miss, it hits the database (~50ms), returns the data, and stores the result inside Redis for 10 minutes.
* **When you hit a write command (`POST`/`PUT`/`DELETE`):**
  * It updates the database first, then deletes the relevant cache keys by prefix so the very next `GET` request is forced to pull fresh data from the DB.

### Performance & Testing
* **Async everywhere:** All database calls, Redis calls, and HTTP pipeline operations use `async`/`await`. No blocking threads.
* **Testing approach:** I specifically unit tested the service layer where the actual business logic lives, rather than testing basic repository CRUD operations.
  * *Test cases cover:* "Add comment on non-existent stock throws exception" and "User tries to update someone else's comment returns unauthorized".

### Main API Endpoints

| Method | Endpoint | Description |
| :--- | :--- | :--- |
| **POST** | `/api/account/register` | Create a new user account |
| **POST** | `/api/account/login` | Get access token + refresh token |
| **POST** | `/api/account/refresh` | Get a clean token pair using a valid refresh token |
| **GET** | `/api/stock` | List all stocks (with Pagination, Sorting, and **Cached**) |
| **GET** | `/api/stock/{id}` | Get single stock details |
| **POST** | `/api/stock` | Create a stock (Admin authorization required) |
| **GET** | `/api/comment/{stockId}` | Comments for a stock (with Pagination and **Cached**) |
| **POST** | `/api/comment/{stockId}` | Add a comment (Requires authentication + **Rate-Limited**) |
| **PUT** | `/api/comment/{commentId}` | Edit your own comment |

### How to run this locally

1. Make sure you have **Docker Desktop** installed and running on your machine.
2. Clone this project repository and open your terminal in the root directory.
3. Run the following command to spin up the API, database, and Redis instances automatically:
   ```bash
   docker compose up --build -d
