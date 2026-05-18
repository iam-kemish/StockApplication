-StockApplicationApi
     A stock discussion API where users can post comments about stocks.

-What this thing actually does-
     Users can register/login (JWT tokens)
     Create/read/update/delete stocks
     Post comments about specific stocks
     Each comment is tied to a user (no anonymous posting)
     Users can only edit/delete their OWN comments

-Technology used
     .NET 9	The framework
     Entity Framework Core which talks to SQL Server
     Redis	Caching so I don't hit DB for every request
     ASP.NET Core Identity	Handles user registration/login
     JWT	Access tokens
      Refresh tokens (DB stored)
      xUnit + Moq	Unit tests for service layer
      FluentValidation Validates incoming requests

-How it's built (layers)

     Controller →   Service    →      Repository 
        ↓              ↓                 ↓
       DTOs       Business logic      Database
     Controllers - Just receive requests, call services, return responses
     Services - All the business logics. (checking if stock exists, user owns comment, etc.)
     Repositories - Just database CRUD operations (add, update, delete, find)
     DTOs - What goes in/out of API(to user) (hides database models)


Some of Security stuffs I added
    -Refresh token rotation with breach detection
    -When you request a new access token using a refresh token:
    -Old refresh token gets marked as "used" immediately
    -You get a brand new refresh token
    -If someone tries to use the SAME refresh token again (attacker trying to replay) → system detects it and revokes ALL tokens for that user.
-Validation at 3 levels
    FluentValidation - Checks request data (e.g., "Stock symbol can't be empty")
    Service layer custom checks - Business rules (e.g., "Can't comment on non-existent stock")
    Global exception handler - Catches anything unexpected (DB connection fails, etc.)

-Redis caching
    When you GET /api/stocks or /api/comments:
    Checks Redis first
    If data exists → returns from cache (~5ms)
    If not → hits database (~50ms), stores result for 10 minutes
    When you POST/PUT/DELETE (anything that changes data):
    Updates database
    Deletes relevant cache keys by prefix so next GET refreshes from DB

-Async everywhere
    All database calls, Redis calls, and HTTP calls use async/await. No blocking threads.

-Testing approach
    unit tested service layer (where business logic lives), not repositories.

-What I test:
    "Add comment on non-existent stock" → throws exception
    "User tries to update someone else's comment" → unauthorized
    "Refresh token mismatch" → rejects
    
-API endpoints (main ones)
    Method	Endpoint	What
    POST	/api/account/register	Create account
    POST	/api/account/login	Get access token + refresh token
    POST	/api/account/refresh	Get new tokens using refresh token
    GET	/api/stock	List all stocks (cached)
    GET	/api/stock/{id}	Single stock details
    POST	/api/stock	Create stock (admin only)
    GET	/api/comment/{stockId}	Comments for a stock (cached)
    POST	/api/comment/{stockId}	Add comment (requires login)
    PUT	/api/comment/{commentId}	Edit your own comment
 
-Using SQL Server for database.

How to run this
Install SQL Server and Redis (or use Docker)

Update appsettings.json with your connection strings

Run migrations: dotnet ef database update

Run: dotnet run

Test with Swagger at /swagger or use Postman

