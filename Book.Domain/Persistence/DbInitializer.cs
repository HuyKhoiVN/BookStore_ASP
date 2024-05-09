using Books.Domain.Entities;
using Books.Domain.Utitlities;
using Books.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data.Persistence
{
#pragma warning disable
    public class DbInitializer : IDbInitializer
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDBContext _dbContext;
        private readonly ILogger<ApplicationDBContext> _logger;

        private IConfiguration _configuration { get; }

        public DbInitializer(RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            ApplicationDBContext dbContext,
            ILogger<ApplicationDBContext> logger,
            IConfiguration configuration)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _dbContext = dbContext;
            _logger = logger;
            _configuration = configuration;
        }

        public void Initialize()
        {
            try
            {
                if (_dbContext.Database.GetPendingMigrations().Any())
                {
                    _dbContext.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
            }

            //create roles
            if (!_roleManager.RoleExistsAsync(Roles.RoleType.SuperAdmin.ToString()).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(Roles.RoleType.SuperAdmin.ToString())).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Roles.RoleType.Admin.ToString())).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Roles.RoleType.Employee.ToString())).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Roles.RoleType.Individual.ToString())).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Roles.RoleType.Company.ToString())).GetAwaiter().GetResult();

                //Create super admin user
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = _configuration["UserSettings:SuperAdmin:UserName"],
                    Email = _configuration["UserSettings:SuperAdmin:UserName"],
                    FirstName = "Huy",
                    LastName = "Khoi",
                    PhoneNumber = "+84353022377",
                    StreetAddress = "HaNoi",
                    State = "HaNoi2",
                    PostalCode = "30000",
                    City = "HaNoi3"
                }, _configuration["UserSettings:SuperAdmin:Password"]).GetAwaiter().GetResult();
            }

            ApplicationUser superAdmin = _dbContext.ApplicationUsers.FirstOrDefaultAsync(t => t.Email == _configuration["UserSettings:SuperAdmin:UserName"]).GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(superAdmin, Roles.RoleType.SuperAdmin.ToString()).GetAwaiter().GetResult();

            //create admin user
            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = _configuration["UserSettings:Admin:UserName"],
                Email = _configuration["UserSettings:Admin:UserName"],
                FirstName = "Huy",
                LastName = "Admin Khoi",
                PhoneNumber = "+353022177",
                StreetAddress = "Tu Liem Street",
                State = "Hai Ba Trung",
                PostalCode = "30000",
                City = "Ha Noi"
            }, _configuration["UserSettings:Admin:Password"]).GetAwaiter().GetResult();

            ApplicationUser admin = _dbContext.ApplicationUsers.FirstOrDefaultAsync(t => t.Email == _configuration["UserSettings:Admin:UserName"]).GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(admin, Roles.RoleType.Admin.ToString()).GetAwaiter().GetResult();

            //add cover
            if (!_dbContext.Covers.Any())
            {
                _dbContext.Covers.AddRange(new List<Cover>()
                {
                    new Cover(){Name = "Paper Cover"},
                    new Cover(){Name = "Hard Cover"},
                    new Cover(){Name = "Plastic Cover"}
                });
                _dbContext.SaveChanges();
            }

            //add categories
            if (!_dbContext.Categories.Any())
            {
                _dbContext.Categories.AddRange(new List<Category>()
                {
                    new Category(){Name = "Paper Cover", DisplayOrder = 8, CreatedDate = DateTime.Parse("2024-04-18")},
                    new Category() {Name = "Double Cover", DisplayOrder = 1, CreatedDate = DateTime.Parse("2023-12-03")},
                    new Category(){Name = "Detective", DisplayOrder = 2, CreatedDate = DateTime.Parse("2024-01-29")}
                });
                _dbContext.SaveChanges();
            }

            //create authors
            if (!_dbContext.Authors.Any())
            {
                _dbContext.Authors.AddRange(new List<Author>()
                {
                    new Author(){FullName = "Le Van Chi"},
                    new Author(){FullName = "David Caption"},
                    new Author(){FullName = "Alex Victor"}
                });
                _dbContext.SaveChanges();
            }

            //create products
            if (!_dbContext.Products.Any())
            {
                _dbContext.Products.AddRange(new List<Product>()
                {
                    new Product()
                    {
                        Title = "Dai Viet Su Ky Toan Thu",
                        ISBN = "ISBN 0-306-40615-2",
                        Description = "<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</p>",
                        AuthorId = 2,
                        Price = 10,
                        ImageUrl = "\\images\\products\\e4dc4b00-c609-4e00-ae38-153e3ef835c3.jpg",
                        CategoriyId = 3,
                        CoverId = 4,
                        InStock = 5,
                    },

                    new Product()
                    {
                        Title = "Tip for coding",
                        ISBN = "ISBN 0-306-65345-1",
                        Description = "<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</p>",
                        AuthorId = 1,
                        Price = 50,
                        ImageUrl = "\\images\\products\\4dca90aa-7e9c-4756-bf6b-c020a1728d9b.jpg",
                        CategoriyId = 1,
                        CoverId = 1,
                        InStock = 2,
                    },

                    new Product()
                    {
                        Title = "Lorem Ipsum is",
                        ISBN = "ISBN 0-647-92487-1",
                        Description = "<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</p>",
                        AuthorId = 2,
                        Price = 30,
                        ImageUrl = "\\images\\products\\6e16025d-951a-492d-86c3-5936c2d910fc.jpg",
                        CategoriyId = 2,
                        CoverId = 2,
                        InStock = 7,
                    }
                }); ;
                _dbContext.SaveChanges();
            }
            return;
        }
    }
}
