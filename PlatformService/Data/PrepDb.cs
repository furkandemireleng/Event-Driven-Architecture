using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder application)
        {
            using (var serviceScope = application.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }

        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platfroms.Any())
            {
                Console.WriteLine("--> Seeding data");

                context.Platfroms.AddRange(
                    new Platfrom()
                    {
                        Name="Platform1",
                        Publisher="Publisher1",
                        Cost="10"
                    },
                    new Platfrom()
                    {
                        Name="Platform2",
                        Publisher="Publisher2",
                        Cost="20"
                    },
                    new Platfrom()
                    {
                        Name="Platform3",
                        Publisher="Publisher3",
                        Cost="30"
                    }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }

        }

    }
}