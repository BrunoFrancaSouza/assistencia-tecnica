using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssistenciaTecnica.Domain;
using AssistenciaTecnica.Repository;
using AssistenciaTecnica.WebAPI.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssistenciaTecnica.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // private readonly IGenericRepository<Usuario> repository;
        private readonly IUsuarioRepository repository;

        private readonly string strMensagemErro = "Erro de requisição no banco de dados: ";
        private readonly IMapper mapper;

        // public UsuariosController(IGenericRepository<Usuario> repository, IMapper mapper)
        // {
        //     this.mapper = mapper;
        //     this.repository = repository;
        // }

        public UsuariosController(IUsuarioRepository repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        // GET api/usuarios
        [HttpGet("GetAtivosAgrupadosPorEmpresaSetor")]
        // public async Task<IActionResult> Get([FromQuery] bool? ativo)
        public async Task<IActionResult> GetAtivosAgrupadosPorEmpresaSetor()
        {
            try
            {
                // Usuario[] usuarios;
                IEnumerable<UsuarioAgrupado> usuarios;

                // Lista de propriedades que são Foreign Key para buscar TAMBÉM as informações das tabelas relacionadas (FK's).
                string[] tabelasInclude = { "Empresa" };

                // usuarios = await repository.GetAtivosAgrupadosPorEmpresaSetor();
                usuarios = repository.GetAtivosAgrupadosPorEmpresaSetor();

                var response = mapper.Map<IEnumerable<UsuarioAgrupadoDTO>>(usuarios);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                string strExceptionMessage = "ExceptionMessage: " + ex.Message.ToString();
                // string strInnerExceptionMessage = "InnerExceptionMessage: " + ex.InnerException.Message.ToString();

                return this.StatusCode(StatusCodes.Status500InternalServerError, strMensagemErro + Environment.NewLine + strExceptionMessage);
            }
        }

        // GET api/usuarios
        [HttpGet]
        // public async Task<IActionResult> Get([FromQuery] bool? ativo)
        public async Task<IActionResult> Get()
        {
            try
            {
                Usuario[] usuarios;

                // Lista de propriedades que são Foreign Key para buscar TAMBÉM as informações das tabelas relacionadas (FK's).
                string[] tabelasInclude = { "Empresa" };

                // if (ativo.HasValue) 
                //     usuarios = await repository.GetByAsync(usuario => usuario.Ativo == ativo);
                // else 
                    // usuarios = await repository.GetAllAsync(tabelasInclude);
                    usuarios = await repository.GetAllAsync();

                var response = mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                string strExceptionMessage = "ExceptionMessage: " + ex.Message.ToString();
                // string strInnerExceptionMessage = "InnerExceptionMessage: " + ex.InnerException.Message.ToString();

                return this.StatusCode(StatusCodes.Status500InternalServerError, strMensagemErro + Environment.NewLine + strExceptionMessage);
            }
        }

        // GET api/usuarios/5
        [HttpGet("{UsuarioId}")]
        public async Task<IActionResult> Get(int UsuarioId)
        {
            try
            {
                var usuario = await repository.GetByIdAsync(UsuarioId);

                var response = mapper.Map<UsuarioDTO>(usuario);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                string strExceptionMessage = "ExceptionMessage: " + ex.Message.ToString();
                // string strInnerExceptionMessage = "InnerExceptionMessage: " + ex.InnerException.Message.ToString();

                return this.StatusCode(StatusCodes.Status500InternalServerError, strMensagemErro + Environment.NewLine + strExceptionMessage);
            }
        }

        // // GET api/usuarios/GetByNome/Nome
        // [HttpGet("GetByNome/{Nome}")]
        // public async Task<IActionResult> Get(string Nome)
        // {
        //     try
        //     {
        //         var response = await repository.GetByAsync(usuario => usuario.Nome == Nome);
        //         return Ok(response);
        //     }
        //     catch (System.Exception ex)
        //     {
        //         string strExceptionMessage = "ExceptionMessage: " + ex.Message.ToString();
        //         string strInnerExceptionMessage = "InnerExceptionMessage: " + ex.InnerException.Message.ToString();

        //         return this.StatusCode(StatusCodes.Status500InternalServerError, strMensagemErro + Environment.NewLine + strExceptionMessage + Environment.NewLine + strInnerExceptionMessage);
        //     }
        // }

        // GET api/usuarios/GetByUserName/UserName
        [HttpGet("GetByUserName/{UserName}")]
        public async Task<IActionResult> Get(string UserName)
        {
            try
            {
                var response = await repository.GetByAsync(usuario => usuario.UserName == UserName);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                string strExceptionMessage = "ExceptionMessage: " + ex.Message.ToString();
                // string strInnerExceptionMessage = "InnerExceptionMessage: " + ex.InnerException.Message.ToString();

                return this.StatusCode(StatusCodes.Status500InternalServerError, strMensagemErro + Environment.NewLine + strExceptionMessage);
            }
        }

        // POST api/usuarios
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                var usuario = mapper.Map<Usuario>(usuarioDTO);

                repository.Add(usuario);

                if (await repository.SaveChangesAsync() == true) // Salvar e validar alterações no banco de dados
                {
                    return Created("api/usuarios/" + usuario.Id, usuario); // Chamar o método GET com o Id do novo objeto incluído.
                }

            }
            catch (System.Exception ex)
            {
                string strExceptionMessage = "ExceptionMessage: " + ex.Message.ToString();
                // string strInnerExceptionMessage = "InnerExceptionMessage: " + ex.InnerException.Message.ToString();

                return this.StatusCode(StatusCodes.Status500InternalServerError, strMensagemErro + Environment.NewLine + strExceptionMessage);
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

                if (_usuario == null)
                {
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
                // string strInnerExceptionMessage = "InnerExceptionMessage: " + ex.InnerException.Message.ToString();

                return this.StatusCode(StatusCodes.Status500InternalServerError, strMensagemErro + Environment.NewLine + strExceptionMessage);
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

                if (_usuario == null)
                {
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
                // string strInnerExceptionMessage = "InnerExceptionMessage: " + ex.InnerException.Message.ToString();

                return this.StatusCode(StatusCodes.Status500InternalServerError, strMensagemErro + Environment.NewLine + strExceptionMessage);
            }

            return BadRequest();
        }

    }
}