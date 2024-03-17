using HMZ_API.Intefaces;
using HMZ_API.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace HMZ_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UsuarioModel model)
        {
            var usuario = await _usuarioService.PegarUsuarioPorEmail(model.email);
            if (usuario == null || usuario.senha != model.senha)
            {
                return Unauthorized();
            }

            return Ok(new { usuario });
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioModel>>> PegarTodosAsync()
        {
            return Ok(await _usuarioService.PegarTodos());
        }

        [HttpGet("{usuarioId}")]
        public async Task<ActionResult<UsuarioModel>> PegarUsuarioPeloId(int usuarioId)
        {
            var pessoa = await _usuarioService.PegarUsuarioPeloId(usuarioId);
            if (pessoa == null)
                return NotFound();
            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> SalvarUsuario(UsuarioModel usuario)
        {
            var novoUsuario = await _usuarioService.SalvarUsuario(usuario);
            return Ok(novoUsuario);
        }

        [HttpPut("{usuarioId}")]
        public async Task<ActionResult> AtualizarUsuario(int usuarioId, UsuarioModel usuario)
        {
            if (usuarioId == null)
                return BadRequest();

            await _usuarioService.AtualizarUsuario(usuario);
            return NoContent();
        }

        [HttpDelete("{usuarioId}")]
        public async Task<ActionResult> ExcluirUsuario(int usuarioId)
        {
            await _usuarioService.ExcluirUsuario(usuarioId);
            return NoContent();
        }
    }
}
