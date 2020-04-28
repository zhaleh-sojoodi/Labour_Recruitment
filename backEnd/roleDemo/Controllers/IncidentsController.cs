﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using labourRecruitment.Models.LabourRecruitment;
using labourRecruitment.ViewModels;

namespace labourRecruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IncidentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Incidents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncidentReport>>> GetIncident()
        {
            var reports = await _context.IncidentReport.ToListAsync();
            foreach (IncidentReport report in reports)
            {
                report.LabourerIncidentReport = _context.LabourerIncidentReport.Where(lr => lr.IncidentReportId == report.IncidentReportId).
                    Select(r => new LabourerIncidentReport
                    {
                        Labourer = r.Labourer
                    }).ToList();

                report.IncidentType = _context.IncidentType.Where(i => i.IncidentTypeId == report.IncidentTypeId).Select(i=> new IncidentType
                {
                    IncidentTypeName = i.IncidentTypeName
                }).FirstOrDefault();
                report.Job = _context.Job.Where(j => j.JobId == report.JobId).Select(j => new Job
                {
                    Title = j.Title
                }).FirstOrDefault();
            }
            return reports;
        }

        //// GET: api/Incidents/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Incident>> GetIncident(int id)
        //{
        //    var incident = await _context.Incident.FindAsync(id);

        //    if (incident == null)
        //    {
        //        return NotFound();
        //    }

        //    return incident;
        //}

        //// PUT: api/Incidents/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutIncident(int id, Incident incident)
        //{
        //    if (id != incident.IncidentId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(incident).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!IncidentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Incidents
        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult PostIncident(IncidentReportVM report)
        {
            _context.IncidentReport.Add(report.IncidentReport);

            foreach (LabourerIncidentReport labourerReport in report.LabourerReports)
            {
                labourerReport.IncidentReportId = report.IncidentReport.IncidentReportId;
                _context.LabourerIncidentReport.Add(labourerReport);

            }
            _context.SaveChanges();
            return new ObjectResult(report);
        }


        //// DELETE: api/Incidents/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Incident>> DeleteIncident(int id)
        //{
        //    var incident = await _context.Incident.FindAsync(id);
        //    if (incident == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Incident.Remove(incident);
        //    await _context.SaveChangesAsync();

        //    return incident;
        //}

        //private bool IncidentExists(int id)
        //{
        //    return _context.Incident.Any(e => e.IncidentId == id);
        //}
    }
}