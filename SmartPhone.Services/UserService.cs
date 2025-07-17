using SmartPhone.Model;
using SmartPhone.Services.Database;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace SmartPhone.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UserRespond> GetAll()
        {
            return _context.Users.Select(u => new UserRespond
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Address = u.Address
            }).ToList();
        }

        public UserRespond? GetById(int id)
        {
            var u = _context.Users.Find(id);
            if (u == null) return null;
            return new UserRespond
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Address = u.Address
            };
        }

        public UserRespond Create(UserRequest request)
        {
            // Check for duplicate email
            if (_context.Users.Any(u => u.Email == request.Email))
            {
                throw new System.Exception("A user with this email already exists.");
            }
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                CreatedAt = System.DateTime.UtcNow
            };
            // Hash the password using PBKDF2
            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
            return new UserRespond
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address
            };
        }

        public bool Update(int id, UserRequest request)
        {
            var user = _context.Users.Find(id);
            if (user == null) return false;
            // Check for duplicate email (excluding current user)
            if (_context.Users.Any(u => u.Email == request.Email && u.Id != id))
            {
                return false;
            }
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            // Hash the password using PBKDF2
            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);
            user.PhoneNumber = request.PhoneNumber;
            user.Address = request.Address;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return false;
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        // Optional: Add a method to verify passwords
        public bool VerifyPassword(User user, string password)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            return result == PasswordVerificationResult.Success;
        }
    }
} 