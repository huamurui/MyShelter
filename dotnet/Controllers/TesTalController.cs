using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dotnet.Models;

namespace dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesTalController : ControllerBase
    {

        TesTalContext TesTalContext;

        public TesTalController(TesTalContext TesTalContext)
        {
            this.TesTalContext = TesTalContext;
        }


        //查找表中所有数据
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            List<TesTal> TesTalTable = TesTalContext.TesTal.ToList();  //查出所有
            return Ok(TesTalTable);
        }


        //添加一个数据，传入一个不带ID的
        [HttpPost("postone")]
        public IActionResult PostOne(TesTal testal)
        {
            var TesTal = TesTalContext.TesTal.FirstOrDefault(a => a.Id == testal.Id);
            if (TesTal != null)
            {
                return BadRequest(new { conut = -1, msg = "添加失败，id重复" });
            }
            TesTalContext.TesTal.Add(testal);  //添加一个
            TesTalContext.SaveChanges();
            return Ok();
        }

        //修改数据,传入对象，找到对应id的数据实现更新
        [HttpPost("modifyone")]
        public IActionResult Modify(TesTal testal)
        {
            var TesTal = TesTalContext.TesTal.FirstOrDefault(a => a.Id == testal.Id);
            if (TesTal == null)
            {
                return BadRequest(new { conut = -1, msg = "修改失败，未找到数据" });
            }
            //修改数据
            // TesTalTable.Id = testal.Id;
            TesTal.Nama = testal.Nama;


            TesTalContext.TesTal.Update(TesTal);
            TesTalContext.SaveChanges();
            return Ok(testal);
        }

        //移除一个对象，根据id移除
        [HttpPost("Removeone")]
        public IActionResult Remove(TesTal testal)
        {
            var TesTal = TesTalContext.TesTal.FirstOrDefault(a => a.Id == testal.Id);
            //修改数据

            if (TesTal == null)
            {
                return NotFound();
            }
            TesTalContext.TesTal.Remove(TesTal);
            TesTalContext.SaveChanges();
            return Ok(TesTal);
        }
    }
}
