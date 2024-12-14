using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ACTIVITY8List.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        // List of Person objects
        public List<Person>? People { get; set; } = new List<Person>();

        public void OnGet()
        {
            // Initialize list of people
            People = new List<Person>()
            {
                new Person() {
                    Name = "Alice Smith",
                    Age = 25,
                    Gender = "Female",
                    EmailAddress = "alice@example.com"
                },
                new Person() {
                    Name = "Bob Johnson",
                    Age = 30,
                    Gender = "Male",
                    EmailAddress = "bob@example.com"
                },
                new Person() {
                    Name = "Charlie Brown",
                    Age = 22,
                    Gender = "Male",
                    EmailAddress = "charlie@example.com"
                },
                new Person() {
                    Name = "Diana Prince",
                    Age = 28,
                    Gender = "Female",
                    EmailAddress = "diana@example.com"
                },
                new Person() {
                    Name = "Ethan Hunt",
                    Age = 35,
                    Gender = "Male",
                    EmailAddress = "ethan@example.com"
                },
                new Person() {
                    Name = "Fiona Gallagher",
                    Age = 27,
                    Gender = "Female",
                    EmailAddress = "fiona@example.com"
                },
                new Person() {
                    Name = "George Taylor",
                    Age = 31,
                    Gender = "Male",
                    EmailAddress = "george@example.com"
                },
                new Person() {
                    Name = "Hannah Lee",
                    Age = 24,
                    Gender = "Female",
                    EmailAddress = "hannah@example.com"
                },
                new Person() {
                    Name = "Ian Wright",
                    Age = 29,
                    Gender = "Male",
                    EmailAddress = "ian@example.com"
                },
                new Person() {
                    Name = "Jenna Coleman",
                    Age = 26,
                    Gender = "Female",
                    EmailAddress = "jenna@example.com"
                }
            };
        }

        public class Person
        {
            public string Name { get; set; } = string.Empty;
            public int Age { get; set; }
            public string Gender { get; set; } = string.Empty;
            public string EmailAddress { get; set; } = string.Empty;
        }
    }
}
