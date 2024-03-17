using Microsoft.EntityFrameworkCore;

namespace HMZ_API.Models
{
    public class ContextModel : DbContext
    {
        public DbSet<UsuarioModel> Usuario { get; set; }


        public ContextModel(DbContextOptions<ContextModel> opcoes) : base(opcoes)
        {

        }
    }
}
