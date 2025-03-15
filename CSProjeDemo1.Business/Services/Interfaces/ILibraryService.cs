using CSProjeDemo1.CSProjeDemo1.Core.Models.Abstracts;
using CSProjeDemo1.CSProjeDemo1.Core.Models.Entities;
using CSProjeDemo1.CSProjeDemo1.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.CSProjeDemo1.Business.Services.Interfaces
{
    public interface ILibraryService

	{   
		// Üye, kitap ödünç alabilir.
		Task BorrowBookAsync(Guid memberId, Guid bookId);

		// Üye, ödünç aldığı kitabı iade edebilir.
		Task ReturnBookAsync(Guid bookId);

		// Kitap durumunu güncelleyebilir (ödünç alınabilir, ödünç verildi, mevcut değil).
		Task UpdateBookStatusAsync(Guid bookId, BookStatus status);

		// Bir üyenin ödünç aldığı kitapları görüntüleyebilir.
		Task<IEnumerable<Book>> GetAllBorrowedBooksByMemberAsync(Guid memberId);

		// Kütüphane durumunu görüntüleyebilmeli.

		// Üyeler
		Task<IEnumerable<Member>> GetAllMembersAsync();

		// Mevcut Kitaplar
		Task<IEnumerable<Book>> GetAllBooksAsync();
		// Bilim
		Task<IEnumerable<ScienceBook>> GetAllScienceBooksAsync();

		// Roman
		Task<IEnumerable<NovelBook>> GetAllNovelBooksAsync();

		// Tarih
		Task<IEnumerable<HistoryBook>> GetAllHistoryBooksAsync();

		// Ödünç Alınan Kitaplar
		Task<IEnumerable<Book>> GetAllBorrowedBooksAsync();
	}
}
