using API.Dto;
using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController(TokoContext context) : ControllerBase
    {
        private readonly TokoContext _context = context;

        [HttpGet]
        public ActionResult GetALL() {
            return Ok(_context.Items.Include(f => f.Category).ToList());
        }

        [HttpGet("{id}")]
        public ActionResult Index(int id)
        {
            var data = _context.Items.FirstOrDefault(x => x.Id == id);
            if(data == null) { return BadRequest(); }
            return Ok(data);
        }

        [HttpPost]
        public ActionResult Create(ItemRequest req){
            if(req.CategoryId == 0)
            {
                return BadRequest();
            }
            _context.Items.Add(new Item
            {
                CategoryId = req.CategoryId,
                Name = req.Name,
                ItemCount = req.ItemCount,
                Price = req.Price,
            });

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var data = _context.Items.FirstOrDefault(f => f.Id == id);
            if(data == null) { return NotFound(new { Message = "Not Found" }); }
            _context.Items.Remove(data);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(ItemRequest req, int id)
        {
            var data = _context.Items.FirstOrDefault(f => f.Id == id);
            if(data == null) { return NotFound(); }
            data.Name = req.Name;
            data.Price = req.Price;
            data.ItemCount = req.ItemCount;
            data.CategoryId = req.CategoryId;
            _context.SaveChanges();
            return Ok();
        }

    }
}
