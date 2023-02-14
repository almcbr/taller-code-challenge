using Car.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Car.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public string Message { get; set; }
        public CarsController(AppDbContext context)
        {
            _context = context;

        }

        // GET: api/<CarsController>
        [HttpGet]
        public async Task<ActionResult<List<Data.Car>>> Get()
        {
            return await _context.Cars.ToListAsync();
        }

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }
            var car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        // POST api/<CarsController>
        [HttpPost]
        public async Task<IActionResult> Post([Bind("Make,Model,Year,Doors,Color,Price")] Data.Car car)
        {
            if (ModelState.IsValid)
            {
                car.Id = Guid.NewGuid();
                _context.Add(car);
                await _context.SaveChangesAsync();
                return Ok(car);
            }
            return BadRequest();
        }

        // PUT api/<CarsController>/5
        [HttpPut("{id}")]

        public async Task<IActionResult> Put(Guid id, [Bind("Make,Model,Year,Doors,Color,Price")] Data.Car car)
        {
            if (!CarExists(id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    car.Id = id;
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(car);
            }
            return BadRequest();
        }
        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (_context.Cars == null)
            {
                return Problem("Entity set 'AppDbContext.Cars'  is null.");
            }
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool CarExists(Guid id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
