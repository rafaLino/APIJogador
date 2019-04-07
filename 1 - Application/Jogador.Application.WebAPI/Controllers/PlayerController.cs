using Jogador.Application.Service.InputOutput.Player;
using Jogador.Application.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Jogador.Application.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerApplicationService _application;

        public PlayerController(IPlayerApplicationService application)
        {
            _application = application;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PlayerInput input)
        {
            var result = await _application.AddAsync(input);

            if (result != null)
                return Created(Request.Path, result);

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _application.GetAsync());
        }

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _application.GetAsync(id));
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _application.DeleteAsync(id);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e);
                
            }
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Put(string id, [FromBody] PlayerInput input)
        {
            try
            {
                await _application.UpdateAsync(id, input);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }

        [HttpPost("Image"),DisableRequestSizeLimit]
        public  IActionResult UpLoad()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }
    }
}