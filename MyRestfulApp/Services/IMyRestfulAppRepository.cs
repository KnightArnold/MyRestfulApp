using MyRestfulApp.Entities;
using MyRestfulApp.ExternalModels;
using MyRestfulApp.ExternalModels.SearchesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestfulApp.Services
{
    public interface IMyRestfulAppRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(Guid userId);
        IEnumerable<User> GetUsers(IEnumerable<Guid> userIds);
        void AddUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
        bool UserExists(Guid userId);
        Task<IEnumerable<Countries>> GetCountriesAsync();
        Task<Country> GetCountryAsync(string countryId);
        Task<Search> SearchTermQueryAsync(string termQuery);
        bool Save();
    }
}
