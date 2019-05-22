using Greenfinch.WebDeveloper.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Greenfinch.WebDeveloper.Data.Interfaces
{
    public interface INewsletterRepository
    {
        void Subscribe<T>(T entity) where T : class;

        Task<bool> IsSubscribed(string email);

        void Unsubscribe<T>(T entity) where T : class;

        Task<IEnumerable<Newsletter>> GetAll();

        Task<bool> SaveAll();

        Task<Newsletter> FindByIdAsync(int? id);

    }
}
