# ASP .NET Core 6.0
## Install
- Microsoft.EntityFramworkCore
- Microsoft.EntityFramworkCore.Tools
- Microsoft.EntityFramworkCore.Design
- Microsoft.EntityFramworkCore.SqlServer
- Microsoft.AspNetCore.Identity
- Microsoft.AspNetCore.Identity.Stores
- Microsoft.AspNetCore.Identity.EntityFrameworkCore

## Structure
- src
	- application
		- Website MVC
	- business
		- Logic
            - Commands
                - Handler
                - Request
            - Events
                - Data
                - Handler
            - Queries
                - Implement
                - Interface
		- Logic.Shared
	- common
		- Common.Shared
			- Model
		- Common.Utils
	- database
		- Data
			- Configurations
			- Entities
            - Migratios
            - Seeder
            - AppDatabase.cs
		- Data.Shared