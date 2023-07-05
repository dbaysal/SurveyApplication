using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Seeds
{
    internal class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Password = "admin123",
                    
                },
                new User
                {
                    Id = 2,
                    Username = "default user",
                    Password = "123",
                   
                }               
                );

        }
    }
}
