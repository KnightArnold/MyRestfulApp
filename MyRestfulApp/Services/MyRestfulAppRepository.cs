using MyRestfulApp.DbContexts;
using MyRestfulApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestfulApp.Services
{
    public class MyRestfulAppRepository : IMyRestfulAppRepository, IDisposable
    {
        private readonly MyRestfulAppContext _context;

        public MyRestfulAppRepository(MyRestfulAppContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
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
