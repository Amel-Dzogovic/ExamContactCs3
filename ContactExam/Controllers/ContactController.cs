using ContactExam.Data;
using ContactExam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContactExam.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactRepository rep;
        public ContactController(ContactDataContext context)
        {
            this.rep = new ContactRepository(context);
        }

        public IActionResult Index()
        {
            return View("Index", rep.GetAll());
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async  Task<IActionResult> Create(Contact newcontact)
        {
            if (newcontact == null) return null;
            await rep.AddAsync(newcontact);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null) return View("Error");
            return View("Edit", await rep.GetByIdAsync(id.Value));
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditContact(Contact newcontact)
        {
            await rep.UpdateAsync(newcontact.Id,newcontact);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int Id)
        {
            return View("Delete",await rep.GetByIdAsync(Id));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteContact(Contact newcontact)
        {
            await rep.DeleteAsync(newcontact.Id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            return View("Details", await rep.GetByIdAsync(id));
        }
    }
}
