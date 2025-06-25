using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectB.Data;
using ProjectB.Models;

namespace ProjectB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailTemplateController : ControllerBase
    {
        private readonly ProjectBDbContext _context;

        public MailTemplateController(ProjectBDbContext context)
        {
            _context = context;
        }

        // GET: api/MailTemplate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MailTemplate>>> GetMailTemplates()
        {
            return await _context.MailTemplates.ToListAsync();
        }

        // GET: api/MailTemplate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MailTemplate>> GetMailTemplate(int id)
        {
            var mailTemplate = await _context.MailTemplates.FindAsync(id);

            if (mailTemplate == null)
            {
                return NotFound();
            }

            return mailTemplate;
        }

        // POST: api/MailTemplate
        [HttpPost]
        public async Task<ActionResult<MailTemplate>> PostMailTemplate(MailTemplate mailTemplate)
        {
            _context.MailTemplates.Add(mailTemplate);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMailTemplate), new { id = mailTemplate.Id }, mailTemplate);
        }
    }
}
