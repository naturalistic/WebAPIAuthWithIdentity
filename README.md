# WebAPIAuthWithIdentity
Project to demonstrate Web API Only Authentication with Identity and Database First

Guide for setting up ASP.NET Core WebAPI with local user Accounts & Identity

Problem:

No template for this, all assumes you want to use MVC. 

Many users will want to use API only for authentication including registrations ect.

But identity provides many benefits so don't want to roll my own either.

Additionally by default it uses migrations to publish the table definitions but we want database first for any decent sizes project. 

Step 1:

Either use template from my project or create an MVC project with Identity auth and publish db to get latest models.

Step 2:

Use schema compare on the db select the db as target to create tables into your new project

Step 3: 

Now I would usually generate EF models from the project... but here I'm going to first try and get working directly...

The trick here is that you do not want any of the default identity tables generated in your dbcontext. 

Add a db context which inherits from IdentityDbContext for the various identity tables to get mapped correctly. 

No idea how this will generate for further db first generation


Packpage manager console works well for this.

I always just let these generate into my API and move them and update the namespace...

Step 4:

Update startup to setup identity 


https://medium.com/@ozgurgul/asp-net-core-2-0-webapi-jwt-authentication-with-identity-mysql-3698eeba6ff8

 public void ConfigureServices(IServiceCollection services)
        {
            // ===== Add our DbContext ========
            services.AddDbContext<ApplicationDbContext>();
            
            // ===== Add Identity ========
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // ===== Add MVC ========
            services.AddMvc();
        }
		

Step 5:

https://medium.com/@ozgurgul/asp-net-core-2-0-webapi-jwt-authentication-with-identity-mysql-3698eeba6ff8

Configure JWT Authentication in configure services


{
  "JwtKey": "SOME_RANDOM_KEY_DO_NOT_SHARE",
  "JwtIssuer": "http://yourdomain.com",
  "JwtExpireDays": 30
}

