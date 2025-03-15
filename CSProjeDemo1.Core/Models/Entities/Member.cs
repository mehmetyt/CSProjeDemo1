using CSProjeDemo1.Core.Models.BaseEntity;
using CSProjeDemo1.CSProjeDemo1.Core.Models.Abstracts;
using CSProjeDemo1.CSProjeDemo1.Core.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.CSProjeDemo1.Core.Models.Entities
{
	public class Member :BaseEntity, IMember
	{
		public string Name { get; set; } = null!;
		public string Surname { get; set; } = null!;
		public string MemberId { get; set; } = null!;
		//public virtual ICollection<Book> BorrowedBooks { get ; set ; }
		//public Member()
		//{
		//	BorrowedBooks = [];
		//}

	}
}
