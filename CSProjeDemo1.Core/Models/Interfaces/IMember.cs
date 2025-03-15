using CSProjeDemo1.CSProjeDemo1.Core.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.CSProjeDemo1.Core.Models.Interfaces
{
    public interface IMember
    {
		string Name { get; set; }
		string Surname { get; set; }
		string MemberId { get; set; }
		//ICollection<Book> BorrowedBooks { get; set; }
	}
}
