using DWT_apiProj.Data;
using DWT_apiProj.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DWT_apiProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly TableDbContext dbContext;
        public TableController(TableDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult getALL()
        {
            return Ok(dbContext.Tables.ToList());
        }

        [HttpPost]
        public IActionResult Add(TableEM addEM)
        {
            var emploee = new Table()
            {
                MyDate = addEM.MyDate,
                CheckIn = addEM.CheckIn,
                CheckOut = addEM.CheckOut,
                BreakIn = addEM.BreakIn,
                BreakOut = addEM.BreakOut,
                Hours = addEM.Hours,
                Type = addEM.Type
            };

            dbContext.Tables.Add(emploee);
            dbContext.SaveChanges();
            return Ok(emploee);
        }


        [HttpDelete("{id:guid}")]
        public IActionResult DeleteItem(int id)
        {
            var item = dbContext.Tables.Find(id);
            if (item is null)
            {
                return NotFound(); // Return a 404 if the item isn't found
            }

            dbContext.Tables.Remove(item); // Remove the item from the list
            dbContext.SaveChanges();
            return Ok(); // Return a 204 No Content response
        }

      
    }
}

