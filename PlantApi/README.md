# Final – Plant API - Web Development

**Student Name:** Myungjeong Han  
**Student Number:** 9031031  
**Seneca Email:** mhan1031@conestogac.on.ca
**Date:** December 10, 2025  
**Time Completed:** 12:10pm  
**Course:** PROG2231 – Programming Microsoft Web Technologies

---

## Project Overview
This project is an ASP.NET Core 9 Web API. This Plant API manages a simple plant catalog, allowing users to create, read, update, and delete plant records. Each plant has properties like Name, Type, WaterCycle, and Height. The API uses SQLite as the database and EF Core for data access. Swagger is set up to test all API endpoints(CRUD) easily.


## Plant Model Overview
Represents a plant in the catalog. It has 5 properties.
- PlantId (int, primary key)
- Name (required)
- PlantType (plant type, e.g., succulent, herb)
- WaterCycle (how often to water, in days)
- Height (in cm)


## How to Run
1. Open the project in VS Code.
2. Run the project using 'dotnet run'.
3. Open your browser and go to the Swagger page.
4. Test all the API endpoints (GET/POST/PUT/DELETE) directly from Swagger.