using CSProjeDemo1.CSProjeDemo1.Core.BaseRepository.Implementations;
using CSProjeDemo1.CSProjeDemo1.Core.Models.Abstracts;
using CSProjeDemo1.CSProjeDemo1.Core.Models.Entities;
using CSProjeDemo1.CSProjeDemo1.Data.Repositories.Interfaces;
using CSProjeDemo1.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Data.Repositories.Implementations
{
    public class ScienceBookRepository:BaseRepository<ScienceBook>,IScienceBookRepository
    {
		public ScienceBookRepository(AppDbContext context):base(context)
		{
			
		}
	}
}
