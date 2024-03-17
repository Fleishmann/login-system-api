using HMZ_API.Intefaces;
using HMZ_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HMZ_API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ContextModel _contexto;

        public UsuarioService(ContextModel contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<UsuarioModel>> PegarTodos()
        {
            return await _contexto.Usuario.ToListAsync();
        }

        public async Task<UsuarioModel> PegarUsuarioPeloId(int usuarioId)
        {
            return await _contexto.Usuario.FindAsync(usuarioId);
        }

        public async Task<UsuarioModel> PegarUsuarioPorEmail(string email)
        {
            return await _contexto.Usuario.FirstOrDefaultAsync(u => u.email == email);
        }

        public async Task<UsuarioModel> SalvarUsuario(UsuarioModel usuario)
        {
            await _contexto.Usuario.AddAsync(usuario);
            await _contexto.SaveChangesAsync();

            return usuario;
        }

        public async Task AtualizarUsuario(UsuarioModel usuario)
        {
            _contexto.Usuario.Update(usuario);
            await _contexto.SaveChangesAsync();
        }

        public async Task ExcluirUsuario(int usuarioId)
        {
            var pessoa = await _contexto.Usuario.FindAsync(usuarioId);
            if (pessoa != null)
            {
                _contexto.Usuario.Remove(pessoa);
                await _contexto.SaveChangesAsync();
            }
        }
    }
}
