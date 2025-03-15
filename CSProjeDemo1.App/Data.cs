using CSProjeDemo1.CSProjeDemo1.Core.Models.Entities;
using CSProjeDemo1.CSProjeDemo1.Core.Models.Enums;
using CSProjeDemo1.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.App
{
	public class Data
	{
		private readonly AppDbContext context;
		public Data()
		{
			context = new AppDbContext();
		}

		public void MemberSeedData()
		{
			var members = new List<Member>
			{
				new Member { Name = "Ali", Surname = "Yılmaz", MemberId = "ALYLMZ-001" },
				new Member { Name = "Ayşe", Surname = "Demir", MemberId = "AYDMR-002" },
				new Member { Name = "Mehmet", Surname = "Kaya", MemberId = "MHKAYA-003" },
				new Member { Name = "Zeynep", Surname = "Çelik", MemberId = "ZYCLK-004" },
				new Member { Name = "Mustafa", Surname = "Şahin", MemberId = "MSTSHN-005" }
			};

			context.Members.AddRange(members);
			context.SaveChanges();

		}
		public void BookSeedData()
		{
			var scienceBooks = new List<ScienceBook>
			{
				new ScienceBook { ISBN = "978-0393609394", Title = "Astrophysics for People in a Hurry", Author = "Neil deGrasse Tyson", Year = 2017, BookStatus = BookStatus.Available },
				new ScienceBook { ISBN = "978-0553380163", Title = "A Brief History of Time", Author = "Stephen Hawking", Year = 1988, BookStatus = BookStatus.Available },
				new ScienceBook { ISBN = "978-0198788607", Title = "The Selfish Gene", Author = "Richard Dawkins", Year = 1976, BookStatus = BookStatus.Available },
				new ScienceBook { ISBN = "978-0345539434", Title = "Cosmos", Author = "Carl Sagan", Year = 1980, BookStatus = BookStatus.Available },
				new ScienceBook { ISBN = "978-0393338102", Title = "The Elegant Universe", Author = "Brian Greene", Year = 1999, BookStatus = BookStatus.Available }
			};

			var novelBooks = new List<NovelBook>
			{
				new NovelBook { ISBN = "978-0141439518", Title = "Pride and Prejudice", Author = "Jane Austen", Year = 1813, BookStatus = BookStatus.Available },
				new NovelBook { ISBN = "978-0451524935", Title = "1984", Author = "George Orwell", Year = 1949, BookStatus = BookStatus.Available },
				new NovelBook { ISBN = "978-0061120084", Title = "To Kill a Mockingbird", Author = "Harper Lee", Year = 1960, BookStatus = BookStatus.Available },
				new NovelBook { ISBN = "978-0743273565", Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Year = 1925, BookStatus = BookStatus.Available }
			};

			var historyBooks = new List<HistoryBook>
			{
				new HistoryBook { ISBN = "978-0062316097", Title = "Sapiens: A Brief History of Humankind", Author = "Yuval Noah Harari", Year = 2011, BookStatus = BookStatus.Available },
				new HistoryBook { ISBN = "978-0345476098", Title = "The Guns of August", Author = "Barbara W. Tuchman", Year = 1962, BookStatus = BookStatus.Available },
				new HistoryBook { ISBN = "978-1101912379", Title = "The Silk Roads: A New History of the World", Author = "Peter Frankopan", Year = 2015, BookStatus = BookStatus.Available }
			};

			context.ScienceBooks.AddRange(scienceBooks);
			context.NovelBooks.AddRange(novelBooks);
			context.HistoryBooks.AddRange(historyBooks);
			context.SaveChanges();
		}

	}
}
