# Using ASP .NET Core 6.0 & SQL Server
## Install
### Database
- Microsoft.EntityFramworkCore
- Microsoft.EntityFramworkCore.Tools
- Microsoft.EntityFramworkCore.Design
- Microsoft.EntityFramworkCore.SqlServer
- Microsoft.AspNetCore.Identity
- Microsoft.AspNetCore.Identity.Stores
- Microsoft.AspNetCore.Identity.EntityFrameworkCore

### Business - Logic
- AutoMapper
- AutoMapper.Extensions.Microsoft.DependencyInjection
- MediatR
- MediatR.Extensions.Microsoft.DependencyInjection

### Common - Utils
- Microsoft.Extensions.DependencyInjection.Abstractions
- Microsoft.EntityFramworkCore
- Microsoft.EntityFramworkCore.SqlServer
- Microsoft.AspNetCore.Authentication.Cookies
- Microsoft.AspNetCore.Authentication.Facebook
- Microsoft.AspNetCore.Authentication.Google
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
            - MappingProfile
		- Logic.Shared
            - Interface
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