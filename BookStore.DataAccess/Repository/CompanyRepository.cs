﻿using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;

namespace BookStore.DataAccess.Repository
{
	public class CompanyRepository : Repository<Company>, ICompanyRepository
	{
		private readonly ApplicationDBContext _db;
		public CompanyRepository(ApplicationDBContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Company obj)
		{
			_db.Companies.Update(obj);
		}
	}
}
