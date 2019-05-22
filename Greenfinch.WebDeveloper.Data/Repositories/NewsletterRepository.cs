using Greenfinch.WebDeveloper.Data.Context;
using Greenfinch.WebDeveloper.Data.Interfaces;

using Greenfinch.WebDeveloper.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Greenfinch.WebDeveloper.Data.Repositories
{
    public class NewsletterRepository : INewsletterRepository
    {
        private GreenfinchContext _context;


        public NewsletterRepository(GreenfinchContext context)
        {
            _context = context;

        }

        public void Subscribe<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public async Task<bool> IsSubscribed(string email)
        {
            var IsSubscribed = await _context.Newsletter.FirstOrDefaultAsync(e => e.Email == email);
            if (IsSubscribed != null)
                return true;
            return false;
        }

        public void Unsubscribe<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<Newsletter>> GetAll()
        {
            return await _context.Newsletter.ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Newsletter> FindByIdAsync(int? id)
        {
            return await _context.Newsletter
               .FirstOrDefaultAsync(m => m.Id == id);
        }

       
    }
}
