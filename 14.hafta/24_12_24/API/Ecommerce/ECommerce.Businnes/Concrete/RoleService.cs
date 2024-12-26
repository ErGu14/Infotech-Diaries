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
    public class RoleService : IRoleSevice
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleService(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task SeedRolesAsync()
        {
            if(!await _roleManager.RoleExistsAsync("NormalUser"))
            {
                var userRole = new ApplicationRole {Name = "NormalUser",Description="Sistemi Kullanıcak Genel Kullanıcılar İçin Tanımlanan Rol",NormalizedName="NORMALUSER" };
                await _roleManager.CreateAsync(userRole);

            }
            if (!await _roleManager.RoleExistsAsync("AdminUser"))
            {
                var adminRole = new ApplicationRole { Name = "AdminUser", Description = "Sistem Üzerinde Tüm Haklara Sahip  Rol", NormalizedName = "ADMINUSER" };
                await _roleManager.CreateAsync(adminRole);

            }
        }
    }
}
