using ContactExam.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactExam.Data
{
    public class ContactRepository
    {
        //EntityFramework
        private readonly ContactDataContext _context;

        public ContactRepository(ContactDataContext context)
        {
            this._context = context;
        }

        public async Task<Contact> AddAsync(Contact contactModel)
        {
            var contact = new Contact();
            contact.Name = contactModel.Name;
            contact.Strasse = contactModel.Strasse;

            _context.Add(contact);
            await _context.SaveChangesAsync();

            return contactModel;
        }

        public IEnumerable<Contact> GetAll()
        {
            
            return _context.Contacts.Select(e => 
            new Contact
            {
                Name = e.Name,
                Strasse = e.Strasse,
                Id = e.Id,
            }).ToList();
        }

        public async Task<Contact> GetByIdAsync(int id) => 
            await _context.Contacts
            .Where(e => e.Id == id)
            .Select(o=> new Contact
            {
                Name = o.Name,
                Strasse=o.Strasse,
                Id = o.Id
            }).FirstOrDefaultAsync();

        public async Task<bool> UpdateAsync(int id, Contact contactModel)
        {
            var entity = _context.Contacts.Where(e => e.Id == id).FirstOrDefault();
            
            if(entity == null)
                return false;

            entity.Name = contactModel.Name;
            entity.Strasse = contactModel.Strasse;

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Contacts.FirstOrDefaultAsync(e => e.Id == id);

            if(entity == null) return false;

            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
