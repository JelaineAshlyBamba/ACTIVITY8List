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

        public List<Person> People { get; set; } = new();
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 5;

        [BindProperty]
        public SearchParameters? SearchParams { get; set; }

        public void OnGet(string? keyword = "", string? searchBy = "", string? sortBy = null, string? sortAsc = "true", int page = 1)
        {
            // Set the current page
            CurrentPage = page;

            // Initialize search parameters
            if (SearchParams == null)
            {
                SearchParams = new SearchParameters
                {
                    SearchBy = searchBy,
                    Keyword = keyword,
                    SortBy = sortBy,
                    SortAsc = sortAsc?.ToLower() == "true"
                };
            }

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

            // Filtering based on search
            if (!string.IsNullOrEmpty(SearchParams.SearchBy) && !string.IsNullOrEmpty(SearchParams.Keyword))
            {
                People = SearchParams.SearchBy.ToLower() switch
                {
                    "name" => People.Where(p => p.Name.Contains(SearchParams.Keyword, StringComparison.OrdinalIgnoreCase)).ToList(),
                    "age" => People.Where(p => p.Age.ToString().Contains(SearchParams.Keyword)).ToList(),
                    "gender" => People.Where(p => p.Gender.Contains(SearchParams.Keyword, StringComparison.OrdinalIgnoreCase)).ToList(),
                    "emailaddress" => People.Where(p => p.EmailAddress.Contains(SearchParams.Keyword, StringComparison.OrdinalIgnoreCase)).ToList(),
                    _ => People
                };
            }

            // Sorting based on the selected column
            if (!string.IsNullOrEmpty(SearchParams.SortBy))
            {
                bool ascending = SearchParams.SortAsc.GetValueOrDefault();
                People = SearchParams.SortBy.ToLower() switch
                {
                    "name" => ascending ? People.OrderBy(p => p.Name).ToList() : People.OrderByDescending(p => p.Name).ToList(),
                    "age" => ascending ? People.OrderBy(p => p.Age).ToList() : People.OrderByDescending(p => p.Age).ToList(),
                    "gender" => ascending ? People.OrderBy(p => p.Gender).ToList() : People.OrderByDescending(p => p.Gender).ToList(),
                    "emailaddress" => ascending ? People.OrderBy(p => p.EmailAddress).ToList() : People.OrderByDescending(p => p.EmailAddress).ToList(),
                    _ => People
                };
            }

            // Paging: Get the page of people to show
            TotalPages = (int)Math.Ceiling(People.Count / (double)PageSize);
            People = People.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
        }

        public class Person
        {
            public string Name { get; set; } = string.Empty;
            public int Age { get; set; }
            public string Gender { get; set; } = string.Empty;
            public string EmailAddress { get; set; } = string.Empty;
        }

        public class SearchParameters
        {
            public string? SearchBy { get; set; }
            public string? Keyword { get; set; }
            public string? SortBy { get; set; }
            public bool? SortAsc { get; set; }
        }
    }

}
