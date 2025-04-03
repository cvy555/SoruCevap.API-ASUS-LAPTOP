using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoruCevap.API.DTOs;
using SoruCevap.API.Models;
using System.Threading.Tasks;

namespace SoruCevap.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QuestionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<QuestionDto>> AddQuestion([FromBody] QuestionDto questionDto)
        {
            if (questionDto == null)
            {
                return BadRequest();
            }

            var question = new Questions
            {
                UserName = questionDto.UserName,
                Title = questionDto.Title,
                Content = questionDto.Content,
                PhotoUrl = questionDto.PhotoUrl,
                VideoUrl = questionDto.VideoUrl,
                CreatedTime = DateTime.UtcNow,
                UpdatedTime = DateTime.UtcNow
            };

            _context.Set<Questions>().Add(question);
            await _context.SaveChangesAsync();

            questionDto.Id = question.Id;
            questionDto.CreatedTime = question.CreatedTime;
            questionDto.UpdatedTime = question.UpdatedTime;

            return CreatedAtAction(nameof(GetQuestion), new { id = questionDto.Id }, questionDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionDto>> GetQuestion(int id)
        {
            var question = await _context.Set<Questions>().FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            var questionDto = new QuestionDto
            {
                Id = question.Id,
                UserName = question.UserName,
                Title = question.Title,
                Content = question.Content,
                PhotoUrl = question.PhotoUrl,
                VideoUrl = question.VideoUrl,
                CreatedTime = question.CreatedTime,
                UpdatedTime = question.UpdatedTime
            };

            return Ok(questionDto);
        }

        // Diğer CRUD işlemleri için benzer yöntemler ekleyebilirsiniz.
    }
}
