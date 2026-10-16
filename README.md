# RaceDay API - PROG7312

## Tech Stack
- .NET 9.0
- EF Core + SQLite
- BCrypt.Net-Next for password hashing
- Swashbuckle Swagger
- xUnit Tests

## How to Run Locally
\\\ash
cd RaceDay.API
dotnet restore
dotnet ef database update
dotnet run
\\\
Open: https://localhost:5001/swagger

## How to Run Tests
\\\ash
dotnet test
\\\
Result: 10/10 Passed

## CI/CD - GitHub Actions
Workflow: .github/workflows/ci.yml

Fixes applied:
1. Added dual TargetFrameworks net8.0 and net9.0 to support GitHub runner
2. Excluded Tests folder from build
3. Added BCrypt.Net-Next package to Tests
4. Removed bin/obj and added .gitignore
5. Fixed nested project path: RaceDay.API/RaceDay.API.csproj

Evidence: 2 Green checks in Actions tab
- Fix: add net9.0, exclude Tests, add BCrypt #5
- Add 10 passing unit tests #6

## API Endpoints
- POST /api/auth/register - Register with hashed password
- POST /api/auth/login - Login with BCrypt verify
- GET /api/events - List events
- GET /api/categories
- GET /api/entries

## Author
Kegow-cyber
