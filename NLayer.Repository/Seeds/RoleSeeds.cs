using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    public class RoleSeeds : IEntityTypeConfiguration<Role>
    {
        
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role
            {
                Id = 1,
                Name = "default",
            },
                
            new Role
            {
                Id = 2,
                Name = "admin",
            }
            );
        }
    }
}
