using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using elvira.web.Models;

namespace elvira.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicShopModelController:Controller
    {
        public MusicModelContext? _musicDB;
        public MusicShopModelController(MusicModelContext _context)
        {
            _musicDB = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicModel>>> Get()
        {
            return await _musicDB._musicModelContext.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<MusicModel>> Get(int id)
        {
            var model =
                await _musicDB._musicModelContext.FirstOrDefaultAsync(x => x.Id == id);
            if (model == null)
                return NotFound();
            return model;
        }


        [HttpPost]
        public async Task<ActionResult<MusicModel>> Post(MusicModel elModel)
        {
            if (elModel == null)
                return BadRequest();
            _musicDB._musicModelContext.Add(elModel);
            await _musicDB.SaveChangesAsync();
            return Ok(elModel);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<MusicModel>> Put(MusicModel eLModel)
        {
            if (eLModel == null)
                return BadRequest();
            if (!_musicDB._musicModelContext.Any(x => x.Id == eLModel.Id))
            {
                return NotFound();
            }
            _musicDB._musicModelContext.Update(eLModel);
            await _musicDB.SaveChangesAsync();
            return Ok(eLModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MusicModel>> Delete(int id)
        {
            var elModel =
                await _musicDB._musicModelContext.FirstOrDefaultAsync(x => x.Id == id);
            if (elModel == null)
                return NotFound();
            _musicDB._musicModelContext.Remove(elModel);
            await _musicDB.SaveChangesAsync();
            return Ok(elModel);
        }
    }
}