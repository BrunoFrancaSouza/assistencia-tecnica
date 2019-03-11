using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistenciaTecnica.Repository;
using AssistenciaTecnica.WebAPI.Firebase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssistenciaTecnica.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly AssistenciaTecnicaContext Context;

        private readonly string strMensagemErro = "Erro de requisição no banco de dados: ";

        public ValuesController(AssistenciaTecnicaContext context)
        {
            this.Context = context;
        }

        // GET api/values
        [HttpGet]
        // public ActionResult<IEnumerable<Usuario>> Get()
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await Context.Usuarios.ToListAsync();
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, strMensagemErro + ex.Message.ToString());
            }
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var response = await Context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Id == id);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, strMensagemErro + ex.Message.ToString());
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
