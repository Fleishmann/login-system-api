using HMZ_API.Models;

namespace HMZ_API.Intefaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioModel>> PegarTodos();
        Task<UsuarioModel> PegarUsuarioPeloId(int usuarioId);
        Task<UsuarioModel> PegarUsuarioPorEmail(string email);
        Task<UsuarioModel> SalvarUsuario(UsuarioModel usuario);
        Task AtualizarUsuario(UsuarioModel usuario);
        Task ExcluirUsuario(int usuarioId);
    }
}
