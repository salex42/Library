using Library.DataBase;
using Library.Models.Library;

namespace Library.Repositories
{
    internal class RegisterRepository : BaseRepository<Register>, IRegisterRepository
    {
        public RegisterRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
