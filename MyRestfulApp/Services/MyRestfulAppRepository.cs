using MyRestfulApp.DbContexts;
using MyRestfulApp.Entities;
using MyRestfulApp.ExternalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyRestfulApp.Services
{
    public class MyRestfulAppRepository : IMyRestfulAppRepository, IDisposable
    {
        private readonly MyRestfulAppContext _context;

        private readonly IHttpClientFactory _httpClientFactory;

        public MyRestfulAppRepository(MyRestfulAppContext context,
            IHttpClientFactory httpClientFactory)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            // the repository fills the id (instead of using identity columns)
            user.Id = Guid.NewGuid();

            _context.Users.Add(user);
        }

        public bool UserExists(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return _context.Users.Any(a => a.Id == userId);
        }

        public void DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Remove(user);
        }

        public User GetUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return _context.Users.FirstOrDefault(a => a.Id == userId);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList<User>();
        }

        public IEnumerable<User> GetUsers(IEnumerable<Guid> userIds)
        {
            if (userIds == null)
            {
                throw new ArgumentNullException(nameof(userIds));
            }

            return _context.Users.Where(a => userIds.Contains(a.Id))
                .OrderBy(a => a.Nombre)
                .OrderBy(a => a.Apellido)
                .ToList();
        }

        public void UpdateUser(User user)
        {
            // no code in this implementation
        }

        public async Task<Country> GetCountryAsync(string countryId)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync($"https://api.mercadolibre.com/classified_locations/countries/{countryId}");
            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<Country>(
                    await response.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions
                    { 
                        PropertyNameCaseInsensitive = true
                    });
            }

            return null;
        }

        public async Task<IEnumerable<Countries>> GetCountriesAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync($"https://api.mercadolibre.com/classified_locations/countries");
            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<IEnumerable<Countries>>(
                    await response.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }

            return null;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
