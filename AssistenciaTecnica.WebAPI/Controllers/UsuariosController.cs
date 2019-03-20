using System;
using System.Threading.Tasks;
using AssistenciaTecnica.Domain;
using AssistenciaTecnica.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssistenciaTecnica.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IGenericRepository<Usuario> repository;

        private readonly string strMensagemErro = "Erro de requisição no banco de dados: ";

        public UsuariosController(IGenericRepository<Usuario> repository)
        {
            this.repository = repository;
        }

        // GET api/usuarios
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                // Lista de propriedades que são Foreign Key para buscar TAMBÉM as informações das tabelas relacionadas (FK's).
                string[] tabelasInclude = {"Empresa"};

                var response = await repository.GetAllAsync(tabelasInclude);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                string strExceptionMessage = "ExceptionMessage: " + ex.Message.ToString();
                string strInnerExceptionMessage = "InnerExceptionMessage: " + ex.InnerException.Message.ToString();

                return this.StatusCode(StatusCodes.Status500InternalServerError, strMensagemErro + Environment.NewLine + strExceptionMessage + Environment.NewLine + strInnerExceptionMessage);
            }
        }

        // GET api/usuarios/5
        [HttpGet("{UsuarioId}")]
        public async Task<IActionResult> Get(int UsuarioId)
        {
            try
            {
                var response = await repository.GetByIdAsync(UsuarioId);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                string strExceptionMessage = "ExceptionMessage: " + ex.Message.ToString();
                string strInnerExceptionMessage = "InnerExceptionMessage: " + ex.InnerException.Message.ToString();

                return this.StatusCode(StatusCodes.Status500InternalServerError, strMensagemErro + Environment.NewLine + strExceptionMessage + Environment.NewLine + strInnerExceptionMessage);
            }
        }

        // GET api/usuarios/GetByNome/Nome
        [HttpGet("GetByNome/{Nome}")]
        public async Task<IActionResult> Get(string Nome)
        {
            try
            {
                var response = await repository.GetByAsync(usuario => usuario.Nome == Nome);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                string strExceptionMessage = "ExceptionMessage: " + ex.Message.ToString();
                string strInnerExceptionMessage = "InnerExceptionMessage: " + ex.InnerException.Message.ToString();

                return this.StatusCode(StatusCodes.Status500InternalServerError, strMensagemErro + Environment.NewLine + strExceptionMessage + Environment.NewLine + strInnerExceptionMessage);
            }
        }

        // POST api/usuarios
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            try
            {
                repository.Add(usuario);

                if (await repository.SaveChangesAsync() == true) // Salvar e validar alterações no banco de dados
                {
                    return Created("api/usuarios/" + usuario.Id, usuario); // Chamar o método GET com o Id do novo objeto incluído.
                }
                
            }
            catch (System.Exception ex)
            {
                string strExceptionMessage = "ExceptionMessage: " + ex.Message.ToString();
                string strInnerExceptionMessage = "InnerExceptionMessage: " + ex.InnerException.Message.ToString();

                return this.StatusCode(StatusCodes.Status500InternalServerError, strMensagemErro + Environment.NewLine + strExceptionMessage + Environment.NewLine + strInnerExceptionMessage);
            }

            return BadRequest();
        }

        // PUT api/usuarios/5
        [HttpPut]
        public async Task<IActionResult> Put(int UsuarioId, Usuario usuario)
        {
            try
            {
                var _usuario = await repository.GetByIdAsync(UsuarioId);
                
                if (_usuario == null){
                    return NotFound();
                }

                repository.Update(usuario);

                if (await repository.SaveChangesAsync() == true) // Salvar e validar alterações no banco de dados
                {
                    return Created("api/usuarios/" + usuario.Id, usuario); // Chamar o método GET com o Id do novo objeto incluído.
                }

            }
            catch (System.Exception ex)
            {
                string strExceptionMessage = "ExceptionMessage: " + ex.Message.ToString();
                string strInnerExceptionMessage = "InnerExceptionMessage: " + ex.InnerException.Message.ToString();

                return this.StatusCode(StatusCodes.Status500InternalServerError, strMensagemErro + Environment.NewLine + strExceptionMessage + Environment.NewLine + strInnerExceptionMessage);
            }

            return BadRequest();
        }

        // DELETE api/usuarios/5
        [HttpDelete("{UsuarioId}")]
        public async Task<IActionResult> Delete(int UsuarioId)
        {
            try
            {
                var _usuario = await repository.GetByIdAsync(UsuarioId);
                
                if (_usuario == null){
                    return NotFound();
                }

                repository.Delete(_usuario);

                if (await repository.SaveChangesAsync() == true) // Salvar e validar alterações no banco de dados
                {
                    return Ok();
                }

            }
            catch (System.Exception ex)
            {
                string strExceptionMessage = "ExceptionMessage: " + ex.Message.ToString();
                string strInnerExceptionMessage = "InnerExceptionMessage: " + ex.InnerException.Message.ToString();

                return this.StatusCode(StatusCodes.Status500InternalServerError, strMensagemErro + Environment.NewLine + strExceptionMessage + Environment.NewLine + strInnerExceptionMessage);
            }

            return BadRequest();
        }

    }
}