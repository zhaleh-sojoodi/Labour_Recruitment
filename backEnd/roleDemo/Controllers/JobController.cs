﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using labourRecruitment.Models.LabourRecruitment;
using labourRecruitment.Repositories;
using labourRecruitment.Services;
using labourRecruitment.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace labourRecruitment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JobController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Job/GetAllActiveJobs
        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<Job>>> GetAllJobs()
        {
            return await _context.Job.ToListAsync();
        }

        // GET: api/Job/GetAllActiveJobs
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<Job>>> GetAllActiveJobs()
        {
            return await _context.Job.Where(job => job.InProgress == true).ToListAsync();
        }

        // GET: api/Job/GetJob/{id}
        [HttpGet("{id}", Name = "GetJob")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetJob(int id)
        {

            var job = await _context.Job.FindAsync(id);
            job.JobSkill = await _context.JobSkill.Where(js => js.JobId == id).Select(ojs => new JobSkill()
            {
                JobSkillId = ojs.JobSkillId,
                JobId = ojs.JobId,
                SkillId = ojs.SkillId,
                NumberNeeded = ojs.NumberNeeded,
                Skill = ojs.Skill
            }).ToListAsync();
            job.Client = _context.Client.Where(c => c.ClientId == job.ClientId).Select(c => new Client()
            {
                ClientName = c.ClientName
            }).FirstOrDefault();
            job.JobLabourer = await _context.JobLabourer.Where(jl => jl.JobId == id).Select(ojl => new JobLabourer()
            {
                JobLabourerId = ojl.JobLabourerId,
                JobId = ojl.JobId,
                LabourerId = ojl.LabourerId,
                ClientQualityRating = ojl.ClientQualityRating,
                LabourerSafetyRating = ojl.LabourerSafetyRating,
                SafetyMeetingCompleted =ojl.SafetyMeetingCompleted,
                Labourer = ojl.Labourer,
                Skill = ojl.Skill
            }).ToListAsync();

            if (job == null)
            {
                return NotFound();
            }
            return new ObjectResult(job);
        }

        // GET: api/Job/GetJobByClientId
        [HttpGet("{clientId}", Name = "GetJobByClientId")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<Job>>> GetJobByClientId(int clientId)
        {
            return await _context.Job.Where(j => j.ClientId == clientId).Select(j => new Job
            {
                JobId = j.JobId,
                Title = j.Title,
                StartDate = j.StartDate,
                EndDate = j.EndDate,
                InProgress = j.InProgress,
                IsComplete = j.IsComplete,
                JobLabourer = j.JobLabourer
            }).ToListAsync();
        }

        // GET: api/Job/GetClientIDByJobID
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetClientIDByJobID(int id)
        {
            var client = _context.Job.Where(j => j.JobId == id).Select(c => c.ClientId).Distinct();
            if (client == null)
            {
                return NotFound();
            }
            return new ObjectResult(client);
        }

        // GET: api/Job/GetJobByLabourerId
        [HttpGet("{labourerId}", Name = "GetJobByLabourerId")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<Job>>> GetJobByLabourerId(int labourerId)
        {
            return await _context.JobLabourer.Where(jl => jl.LabourerId == labourerId).Select(jl => new Job
            {
                JobId = jl.Job.JobId,
                Title = jl.Job.Title,
                StartDate = jl.Job.StartDate,
                EndDate = jl.Job.EndDate,
                InProgress = jl.Job.InProgress,
                IsComplete = jl.Job.IsComplete,
                JobLabourer = jl.Job.JobLabourer
            }).ToListAsync();
        }

        // POST: api/Job
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult PostJob(JobSkillVM jobSkill)
        {
            jobSkill.Job.ScheduleDone = false; 
            _context.Job.Add(jobSkill.Job);
           
            foreach (JobSkill js in jobSkill.JobSkills) {
                js.JobId = jobSkill.Job.JobId;
                _context.JobSkill.Add(js);
            }

            _context.SaveChangesAsync();

            ScheduleHelper scheduleRepo = new ScheduleHelper(_context);
            scheduleRepo.AddLabourersToFirstSchedule(jobSkill.Job.JobId);

            return new ObjectResult(jobSkill.Job.JobId); 
   
        }

        // PUT: api/Job/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob(int id, [FromBody]Job job)
        {
           
            var jobSelected = _context.Job.Where(j => j.JobId == id).FirstOrDefault();

            try
            {
                jobSelected.Title = job.Title;
                jobSelected.JobDescription = job.JobDescription;
                jobSelected.Street = job.Street;
                jobSelected.State = job.State;
                jobSelected.City = job.City;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new ObjectResult(id);
        }

        private bool JobExists(int id)
        {
            return _context.Job.Any(e => e.JobId == id);
        }

    }
}