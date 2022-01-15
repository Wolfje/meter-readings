using MeterReading.Domain.Entities;

namespace MeterReading.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!context.Accounts.Any())
            {
                context.Accounts.AddRange(
                    new Account { AccountId = 2344, Firstname = "Tommy", Lastname = "Test" },
                    new Account { AccountId = 2233, Firstname = "Barry", Lastname = "Test" },
                    new Account { AccountId = 8766, Firstname = "Sally", Lastname = "Test" },
                    new Account { AccountId = 2345, Firstname = "Jerry", Lastname = "Test" },
                    new Account { AccountId = 2346, Firstname = "Ollie", Lastname = "Test" },
                    new Account { AccountId = 2347, Firstname = "Tara", Lastname = "Test" },
                    new Account { AccountId = 2348, Firstname = "Tammy", Lastname = "Test" },
                    new Account { AccountId = 2349, Firstname = "Simon", Lastname = "Test" },
                    new Account { AccountId = 2350, Firstname = "Colin", Lastname = "Test" },
                    new Account { AccountId = 2351, Firstname = "Gladys", Lastname = "Test" },
                    new Account { AccountId = 2352, Firstname = "Greg", Lastname = "Test" },
                    new Account { AccountId = 2353, Firstname = "Tony", Lastname = "Test" },
                    new Account { AccountId = 2355, Firstname = "Arthur", Lastname = "Test" },
                    new Account { AccountId = 2356, Firstname = "Craig", Lastname = "Test" },
                    new Account { AccountId = 6776, Firstname = "Laura", Lastname = "Test" },
                    new Account { AccountId = 4534, Firstname = "Josh", Lastname = "Test" },
                    new Account { AccountId = 1234, Firstname = "Freya", Lastname = "Test" },
                    new Account { AccountId = 1239, Firstname = "Noddy", Lastname = "Test" },
                    new Account { AccountId = 1240, Firstname = "Archie", Lastname = "Test" },
                    new Account { AccountId = 1241, Firstname = "Lara", Lastname = "Test" },
                    new Account { AccountId = 1242, Firstname = "Tim", Lastname = "Test" },
                    new Account { AccountId = 1243, Firstname = "Graham", Lastname = "Test" },
                    new Account { AccountId = 1244, Firstname = "Tony", Lastname = "Test" },
                    new Account { AccountId = 1245, Firstname = "Neville", Lastname = "Test" },
                    new Account { AccountId = 1246, Firstname = "Jo", Lastname = "Test" },
                    new Account { AccountId = 1247, Firstname = "Jim", Lastname = "Test" },
                    new Account { AccountId = 1248, Firstname = "Pam", Lastname = "Test" });
            }




            await context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
