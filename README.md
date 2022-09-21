# ASP .NET Core 6.0
## Install
### Database
- Microsoft.EntityFramworkCore
- Microsoft.EntityFramworkCore.Tools
- Microsoft.EntityFramworkCore.Design
- Microsoft.EntityFramworkCore.SqlServer
- Microsoft.AspNetCore.Identity
- Microsoft.AspNetCore.Identity.Stores
- Microsoft.AspNetCore.Identity.EntityFrameworkCore

### Business
- AutoMapper
- AutoMapper.Extensions.Microsoft.DependencyInjection
- MediatR
- MediatR.Extensions.Microsoft.DependencyInjection

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
            - MappingProfile
		- Logic.Shared
            - Models
	- common
		- Common.Shared
			- Model
		- Common.Utils
            - Global
	- database
		- Data
			- Configurations
			- Entities
            - Migratios
            - Seeder
            - AppDatabase.cs
		- Data.Shared