using CSProjeDemo1.Core.Models.BaseEntity;
using CSProjeDemo1.CSProjeDemo1.Core.Models.Entities;
using CSProjeDemo1.CSProjeDemo1.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.CSProjeDemo1.Core.Models.Abstracts
{
    public abstract class Book:BaseEntity
    {
		public string ISBN { get; set; } = null!;
		public string Title { get; set; } = null!;
		public string Author { get; set; } = null!;
		public int Year { get; set; }
		public BookStatus BookStatus { get; set; }
		public Guid? MemberId { get; set; }
		public virtual Member? Member { get; set; }
	}
}
