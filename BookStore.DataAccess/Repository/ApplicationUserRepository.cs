using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;

namespace BookStore.DataAccess.Repository
{
	public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicatioUserRepository
	{
		public ApplicationUserRepository(ApplicationDBContext db) : base(db)
		{
		}
	}
}
