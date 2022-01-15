using ManagerApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerApi.Context
{
    public class ManagerDbContext : DbContext
    {
        public ManagerDbContext(DbContextOptions<ManagerDbContext> options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }
    }

    public class DataTransfer
    {
        public static void GetMyDb(IServiceProvider serviceProvider)
        {
            using (var context = new ManagerDbContext(serviceProvider.GetRequiredService<DbContextOptions<ManagerDbContext>>()))
            {
                if (context.Players.Any() && context.Teams.Any())
                    return;
                else
                {
                    context.AddRange(
                        new Team
                        {
                            Name = "GALATASARAY"
                        });
                    context.AddRange(
                      new Player
                      {
                          Name = "İsmail Köybaşı",
                          Position = PositionEnum.D,
                          Age = 27,
                          TeamId = 1
                      }
                     );
                    context.SaveChanges();
                }

            }
        }

    }
}
