# :soccer: Premier League Predictions
Every year, 3 friends and I make predictions on how the final Premier league table will look.
I've created this web application to display the current Premier league table and how our predictions are shaping up as the season goes on.

The ASP.NET Core Identity framework has been included in the web application to provide an authentication framework and allow for the flexibility of displaying content to only authorised users

## Prerequisites
- For this solution to work a local DB must be created for the authentication framework. This is done using the Entity Framework Core migration tool:
1. Create a local appsettings.json file, similar to the appsettings.Development.json file in the solution.

2. Install the EF Core migration tool:
```
dotnet tool install dotnet-ef --global
```
3. Create and run a migration to create a database schema
```
dotnet ef migrations add CreateIdentitySchema
dotnet ef database update
```
- Once the database has been created, create a new table named dbo.Predictions with the predicitons information. This is the predictions data for the current seasons:

| Team Name  | SS prediction | LM prediciton  | JL prediction | DD Prediction |
| ------------- | ------------- | ------------- | ------------- | ------------- |
| Liverpool|	2 |	5 |	4 |	3 |
| Arsenal |	3 |	2 |	3 |	2 |
| Aston Villa |	6	| 10 | 8 | 7 |
| Manchester City |	1 |	1 |	1 |	1 |
| Tottenham Hotspur |	7 |	6 |	5 |	9 |
| Manchester United |	4 |	3 |	2 |	4 |
| West Ham United | 11 | 14 |	12 | 10 |
| Newcastle United | 8 | 7 | 7 | 6 |
| Brighton & Hove Albion | 9 | 8 | 9 | 8 |
| Chelsea | 5 | 4 | 6 | 5 |
| Wolverhampton Wanderers | 16 | 15 |	17 | 18 |
| Bournemouth | 17 | 13 |	11 | 17 |
| Fulham | 14 |	12 | 16 |	14 |
| Brentford |	12 | 11 |	10 | 11 |
| Crystal Palace | 13 | 9	| 14 | 12 |
| Nottingham Forest | 18 | 18 | 18 | 16 |
| Everton | 15 | 16 | 15 | 15 |
| Luton Town | 20 | 19 | 20 | 20 |
| Burnley |	10 | 17 | 13 | 13 |
| Sheffield United | 19 | 20 | 19 |	19 |
