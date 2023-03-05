using MedNow.Infra.Contracts.Repositories;
using MedNow.Domain.Entities;
using MedNow.Infra.Auditing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MedNow.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IEntryAuditor _entryAuditor;

        public UserRepository(DataContext context, IEntryAuditor entryAuditor)
        {
            _context = context;
            _entryAuditor = entryAuditor;
        }
        public async Task CreateUser(User user)
        {
            _entryAuditor.AuditCreate(_context.Entry(user));
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email.Equals(email));
        }

        public async Task<User> GetById(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
