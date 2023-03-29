namespace EF_Conversion_Default
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            using var db = new AppDbContext();

            var user = new User
            {
                Name = "Test2",
                Locations = new List<Location> { Location.Cluj, Location.Sibiu }
            };

            var user3 = new User
            {
                Name = "Test3",
            };

            db.Users.Add(user);
            db.Users.Add(user3);
            db.SaveChanges();

        }
    }
}