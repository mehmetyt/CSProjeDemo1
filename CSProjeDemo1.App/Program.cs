using CSProjeDemo1.App;
using CSProjeDemo1.CSProjeDemo1.Business.Services.Implementations;
using CSProjeDemo1.CSProjeDemo1.Business.Services.Interfaces;
using CSProjeDemo1.CSProjeDemo1.Core.Models.Abstracts;
using CSProjeDemo1.CSProjeDemo1.Core.Models.Entities;
using CSProjeDemo1.CSProjeDemo1.Core.Models.Enums;
using CSProjeDemo1.Data.Context;
using CSProjeDemo1.Data.Repositories.Implementations;

var data = new Data();
data.MemberSeedData();
data.BookSeedData();

var context = new AppDbContext();

var memberRepository = new MemberRepository(context);
var scenceBookRepository = new ScienceBookRepository(context);
var novelBookRepository = new NovelBookRepository(context);
var historyBookRepository = new HistoryBookRepository(context);

ILibraryService service = new LibraryService(memberRepository, scenceBookRepository, historyBookRepository, novelBookRepository);

var members = await service.GetAllMembersAsync();
var books = await service.GetAllBooksAsync();

var member1 = members.FirstOrDefault(m => m.MemberId == "ALYLMZ-001");
var book1 = books.FirstOrDefault(b => b.ISBN == "978-0393609394");
var member2 = members.FirstOrDefault(m => m.MemberId == "AYDMR-002");
var book2 = books.FirstOrDefault(b => b.ISBN == "978-0553380163");
var book3 = books.FirstOrDefault(b => b.ISBN == "978-0141439518");

await AllMembersAsync();    // Tüm üyeleri görüntüle

await AllBooksAsync();  // Tüm kitapları görüntüle

await ScienceBooksAsync();  // Tüm bilim kitapları 

await NovelBooksAsync();    // Tüm romanlar

await HistoryBooksAsync();  // Tüm tarih kitapları 

await BorrowAsync(member1, book1);    // Kitap all

await BorrowAsync(member2, book2);    // Kitap all

await AllBorrowedBooks();   // Alınan kitapları görüntüle

await BorrowedBooksByMemberAsync(member1); // Belirli bir üyenin aldığı kitaplar

await AllBooksAsync();  // Ödünç aldıktan sonra tüm kitapları görüntüle

await ReturnBookAsync(book2); // kitabı geri ver

await AllBorrowedBooks(); // kitabı geri verdikten sonra ödünç alınan kitapları görüntüle

await AllBooksAsync(); // kitabı geri verdikten sonra tüm kitapları görüntüle

await ChangeStatus(book3, BookStatus.NotAvailable); // Bir kitabın durumunu değiştir

await AllBooksAsync(); // Durumunu değiştirdikten sonra tüm kitapları görüntülr



Console.ReadKey();


//-------------------------------------------------------

async Task AllBooksAsync()
{
	var books = await service.GetAllBooksAsync();
	var NOfBooks = books.Count();
	Console.WriteLine($"Tüm Kitaplar ({NOfBooks}):");
	if (!books.Any())
	{
		Console.WriteLine("\n-\n");

		return;
	}
	foreach (var book in books)
	{
		//Console.WriteLine(book.Title + "-" + book.Author + "-" + book.Year + "-" + book.GetType().Name + "-" + book.BookStatus);
		Console.WriteLine("{0,-45}{1,-20}{2,-5}{3,-15}{4,-10}",book.Title , book.Author , book.Year , book.GetType().Name , book.BookStatus);
	}
	Console.WriteLine("\n-----------------------------------\n");
}

async Task ScienceBooksAsync()
{
	var books = await service.GetAllScienceBooksAsync();
	var NOfBooks = books.Count();
	Console.WriteLine($"Bilim Kitaplar ({NOfBooks}):");
	if (!books.Any())
	{
		Console.WriteLine("\n-\n");

		return;
	}
	foreach (var book in books)
	{
		Console.WriteLine("{0,-45}{1,-20}{2,-5}{3,-10}", book.Title, book.Author, book.Year, book.BookStatus);

	}
	Console.WriteLine("\n-----------------------------------\n");
}
async Task NovelBooksAsync()
{
	var books = await service.GetAllNovelBooksAsync();
	var NOfBooks = books.Count();
	Console.WriteLine($"Romanlar ({NOfBooks}):");
	if (!books.Any())
	{
		Console.WriteLine("\n-\n");

		return;
	}
	foreach (var book in books)
	{
		Console.WriteLine("{0,-45}{1,-20}{2,-5}{3,-10}", book.Title, book.Author, book.Year, book.BookStatus);

	}
	Console.WriteLine("\n-----------------------------------\n");
}
async Task HistoryBooksAsync()
{
	var books = await service.GetAllHistoryBooksAsync();
	var NOfBooks = books.Count();
	Console.WriteLine($"Tarih Kitaplar ({NOfBooks}):");
	if (!books.Any())
	{
		Console.WriteLine("\n-\n");

		return;
	}
	foreach (var book in books)
	{
		Console.WriteLine("{0,-45}{1,-20}{2,-5}{3,-10}", book.Title, book.Author, book.Year, book.BookStatus);

	}
	Console.WriteLine("\n-----------------------------------\n");
}

async Task AllMembersAsync()
{
	var members = await service.GetAllMembersAsync();
	var NOfMembers = members.Count();
	Console.WriteLine($"Tüm Üyeler ({NOfMembers}):");
	if (!members.Any())
	{
		Console.WriteLine("\n-\n");

		return;
	}
	foreach (var member in members)
	{
		Console.WriteLine("{0,-15}{1,-15}{2,-15}",member.Name , member.Surname , member.MemberId);
	}
	Console.WriteLine("\n-----------------------------------\n");
}

async Task AllBorrowedBooks()
{
	Console.WriteLine("Ödünç Alınan Kitaplar:");

	var borrowedBooks = await service.GetAllBorrowedBooksAsync();
	if (borrowedBooks.Any())
	{
		foreach (var book in borrowedBooks)
		{
			Console.WriteLine("{0,-45}{1,-20}{2,-5}", book.Title, book.Author, book.Year);

		}
	}
	else
	{
		Console.WriteLine("\n-\n");
	}
	Console.WriteLine("\n-----------------------------------\n");

}

async Task BorrowAsync(Member member, Book book)
{
	await service.BorrowBookAsync(member.Id, book.Id);
	Console.WriteLine(member.Name + " " + book.Title + " aldı");

	Console.WriteLine("\n-----------------------------------\n");

}
async Task ReturnBookAsync(Book book)
{
	Console.WriteLine(book.Member.Name + " " + book.Title + " verdi");

	await service.ReturnBookAsync(book.Id);
	Console.WriteLine("\n-----------------------------------\n");
}

async Task ChangeStatus(Book book, BookStatus bookStatus)
{

	await service.UpdateBookStatusAsync(book.Id, bookStatus);
	Console.WriteLine(book.Title + " " + bookStatus + " oldu");
	Console.WriteLine("\n-----------------------------------\n");

}
async Task BorrowedBooksByMemberAsync(Member member)
{
	var borrowedBooks = await service.GetAllBorrowedBooksByMemberAsync(member.Id);
	Console.WriteLine($"{member.Name} Aldığı Kitaplar:");

	if (borrowedBooks.Any())
	{
		foreach (var book in borrowedBooks)
		{
			Console.WriteLine("{0,-45}{1,-20}{2,-5}", book.Title, book.Author, book.Year);

		}
	}
	else
	{
		Console.WriteLine("\n-\n");
	}
	Console.WriteLine("\n-----------------------------------\n");
}


