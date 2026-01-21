# Assignment 2 – Web Development

**Student Name:** Myungjeong Han  
**Student Number:** 9031031  
**Date:** October 14, 2025  
**Course:** PROG2231 – Programming Microsoft Web Technologies  

---

## Assignment Overview
This project is a simple ASP.NET Core MVC web app with SQLite (code-first EF Core), providing full CRUD for a Laptop model with basic UI customization.

## Model Properties
* LaptopId (int, primary key)  
* Model (string)  
* Brand (string)  
* Year (int)  

## How to Run
1. Open this project in VS Code.  
2. Run the project with `dotnet run`.  
3. The Home page displays the laptop list.  
4. Click “Add New Laptop” to create a new entry.  
5. Use Edit, Details, and Delete buttons to manage existing laptops.  

## Note
- Database connection and scaffolding are already set up.  
- Data is stored in SQLite and persists between runs.  

## UI Changes
* Added `MJ HUB` logo with a silhouette resembling an elephant, symbolizing a strong, central hub that gathers and connects laptop and device information.  
* Applied a modern, minimal theme: white background, black base, and yellow accents for buttons.  
* Changed typography to monospace to match the logo style.  
* Converted default text links into styled buttons for a cleaner look.  
