using ECommerce.Businnes.Abstract;
using ECommerce.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Businnes.Concrete
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleService(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task SeedRolesAsync()
        {
            // normal kullanıcı ekleme
            if (!await _roleManager.RoleExistsAsync("User"))
            {
                var userRole = new ApplicationRole { Name = "User", Description = "Sistemi kullanacak kişilerin varsayılan rolü", NormalizedName = "USER" };
                await _roleManager.CreateAsync(userRole);
            }
            //admin kullanıcı ekleme
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                var adminRole = new ApplicationRole { Name = "Admin", Description = "Sistemi Yönetecek Kişilerin Rolü", NormalizedName = "ADMIN" };
                await _roleManager.CreateAsync(adminRole);
            }
        }
    }
}
