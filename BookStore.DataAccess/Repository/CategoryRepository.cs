using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;

namespace BookStore.DataAccess.Repository
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		private readonly ApplicationDBContext _db;
		public CategoryRepository(ApplicationDBContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Category obj)
		{
			_db.Categories.Update(obj);
		}
	}
}
