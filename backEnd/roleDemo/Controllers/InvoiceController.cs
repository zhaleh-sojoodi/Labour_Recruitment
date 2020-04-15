using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using roleDemo.Data;
using roleDemo.Repositories;

namespace roleDemo.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class InvoiceController : Controller
    {
        ApplicationDbContext _context;

        public InvoiceController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Invoice
        public ActionResult Index()
        {
            InvoiceRepo invoiceRepo = new InvoiceRepo(_context);
            return View(invoiceRepo.GetAllInvoices());
        }

        // GET: Invoice/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                InvoiceRepo invoiceRepo = new InvoiceRepo(_context);
                var success = invoiceRepo.CreateInvoice(invoice.UserName,invoice.Total);
                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.Error = "An error occurred while creating this invoice. Please try again.";
            return View();
        }

    }
}