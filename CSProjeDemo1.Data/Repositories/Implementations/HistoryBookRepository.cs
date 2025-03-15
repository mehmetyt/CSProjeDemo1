using CSProjeDemo1.CSProjeDemo1.Core.BaseRepository.Implementations;
using CSProjeDemo1.CSProjeDemo1.Core.Models.Entities;
using CSProjeDemo1.CSProjeDemo1.Data.Repositories.Interfaces;
using CSProjeDemo1.Data.Context;
using CSProjeDemo1.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Data.Repositories.Implementations
{
    public class HistoryBookRepository : BaseRepository<HistoryBook>, IHistoryBookRepository
	{
		public HistoryBookRepository(AppDbContext context) : base(context)
		{

		}
	}
}
