using roleDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roleDemo.Repositories
{
    public class InvoiceRepo
    {
        ApplicationDbContext _context;

        public InvoiceRepo(ApplicationDbContext context)
        {
            this._context = context;
        }
        public List<Invoice> GetAllInvoices()
        {
            var invoices = _context.Invoices;
            List<Invoice> invoiceList = new List<Invoice>();

            foreach (var item in invoices)
            {
                invoiceList.Add(new Invoice() { InvoiceID = item.InvoiceID, UserName = item.UserName, Created = item.Created, Total = item.Total });
            }
            return invoiceList;
        }

        public Invoice GetInvoice(string UserName)
        {
            var invoice = _context.Invoices.Where(r => r.UserName == UserName).FirstOrDefault();
            if (invoice != null)
            {
                return new Invoice() { InvoiceID = invoice.InvoiceID, UserName = invoice.UserName, Created = invoice.Created, Total = invoice.Total};
            }
            return null;
        }

        public bool CreateInvoice(string userName, decimal Total)
        {
            var invoice = GetInvoice(userName);
            if (invoice != null)
            {
                return false;
            }
            _context.Invoices.Add(new Invoice
            {

                UserName = userName,
                Total = Total,
                Created = DateTime.Now
            });
            _context.SaveChanges();
            return true;
        }

    }
}
