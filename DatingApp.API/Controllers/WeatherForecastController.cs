using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly DataContext _context;

        public WeatherForecastController(DataContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        // public ActionResult<IEnumerable<string>> Get()
        // {
        //     return new string[]{"Val1","Val2"};
        // }
        public async Task<IActionResult> GetValues()
        {
            var values=await _context.Values.ToListAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        // public ActionResult<string> Get(int i)
        // {
        //     return "Val1";
        // }
         public async Task<IActionResult> GetValues(int id)
        {
            var values=await _context.Values.FirstOrDefaultAsync(x=>x.Id==id);
            return Ok(values);
        }
    }
}
