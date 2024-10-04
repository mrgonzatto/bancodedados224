using AulaEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace AulaEntityFramework.Repositories
{
	public class PessoaRepository : IPessoaRepository
	{
		private readonly MyDbContext _dbContext;

		public PessoaRepository(MyDbContext context)
		{
			_dbContext = context;
		}

		public Pessoa? Get(int id)
		{
			var pessoa = _dbContext
					.Pessoas
					.Include(e => e.Enderecos)
					.Where(w => w.Id == id)
					.FirstOrDefault();

			return pessoa;
		}

		public List<Pessoa> GetAll()
		{
			return _dbContext
					.Pessoas
					.Include(e => e.Enderecos)
					.ToList();
		}

		public List<Pessoa> GetByBirthDate(DateTime date)
		{
			return _dbContext
					.Pessoas
					.Include(e => e.Enderecos)
					.Where(p => p.BirthDate == date)
					.ToList();
		}

		public List<Pessoa> GetByBirthMonth(int month)
		{
			return _dbContext
					.Pessoas
					.Include(e => e.Enderecos)
					.Where(p => p.BirthDate.Month == month)
					.ToList();
		}

		public List<Pessoa> GetByBirthYear(int year)
		{
			return _dbContext
					.Pessoas
					.Include(e => e.Enderecos)
					.Where(p => p.BirthDate.Year == year)
					.ToList();
		}

		public List<Pessoa>? GetByName(string? name)
		{
			return _dbContext
					.Pessoas
					.Include(e => e.Enderecos)
					.Where(p => p.Name!.Equals(name))
					.ToList();
		}
	}
}
