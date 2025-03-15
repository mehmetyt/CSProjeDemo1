using CSProjeDemo1.CSProjeDemo1.Business.Services.Interfaces;
using CSProjeDemo1.CSProjeDemo1.Core.Models.Abstracts;
using CSProjeDemo1.CSProjeDemo1.Core.Models.Entities;
using CSProjeDemo1.CSProjeDemo1.Core.Models.Enums;
using CSProjeDemo1.CSProjeDemo1.Data.Repositories.Interfaces;
using CSProjeDemo1.Data.Context;
using CSProjeDemo1.Data.Repositories.Implementations;
using CSProjeDemo1.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.CSProjeDemo1.Business.Services.Implementations
{
	public class LibraryService : ILibraryService
	{
		private readonly IScienceBookRepository _scienceBookRepository;
		private readonly IHistoryBookRepository _historyBookRepository;
		private readonly INovelBookRepository _novelBookRepository;
		private readonly IMemberRepository _memberRepository;
		public LibraryService(IMemberRepository memberRepository, IScienceBookRepository bookRepository, IHistoryBookRepository historyBookRepository, INovelBookRepository novelBookRepository)
		{
			_memberRepository = memberRepository;
			_scienceBookRepository = bookRepository;
			_historyBookRepository = historyBookRepository;
			_novelBookRepository = novelBookRepository;
		}
		public async Task BorrowBookAsync(Guid memberId, Guid bookId)
		{
			try
			{
				var member = await _memberRepository.GetByIdAsync(memberId);
				if (member == null)
				{
					throw new ArgumentNullException(nameof(member));
				}
				Book book = await _scienceBookRepository.GetByIdAsync(bookId);
				if (book == null)
				{
					book = await _historyBookRepository.GetByIdAsync(bookId);
				}
				if (book == null)
				{
					book = await _novelBookRepository.GetByIdAsync(bookId);
				}
				if (book.BookStatus != BookStatus.Available)
				{
					throw new Exception("BOOK_NOT_AVAILABLE");
				}
				book.BookStatus = BookStatus.Borrowed;
				book.MemberId = memberId;
				if (book is ScienceBook)
				{
					await _scienceBookRepository.UpdateAsync((ScienceBook)book);
				}
				else if (book is NovelBook)
				{

					await _novelBookRepository.UpdateAsync((NovelBook)book);
				}
				else if (book is HistoryBook)
				{

					await _historyBookRepository.UpdateAsync((HistoryBook)book);
				}
				await _memberRepository.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<IEnumerable<ScienceBook>> GetAllScienceBooksAsync()
		{
			try
			{
				var books = await _scienceBookRepository.GetAllAsync();
				if (books == null)
				{
					throw new ArgumentNullException(nameof(books));
				}
				return books;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}	
		public async Task<IEnumerable<NovelBook>> GetAllNovelBooksAsync()
		{
			try
			{
				var books = await _novelBookRepository.GetAllAsync();
				if (books == null)
				{
					throw new ArgumentNullException(nameof(books));
				}
				return books;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}	
		public async Task<IEnumerable<HistoryBook>> GetAllHistoryBooksAsync()
		{
			try
			{
				var books = await _historyBookRepository.GetAllAsync();
				if (books == null)
				{
					throw new ArgumentNullException(nameof(books));
				}
				return books;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<IEnumerable<Book>> GetAllBorrowedBooksAsync()
		{
			try
			{
				var scienceBooks = await _scienceBookRepository.GetAllAsync(b => b.BookStatus == BookStatus.Borrowed);
				if (scienceBooks == null)
				{
					throw new ArgumentNullException(nameof(scienceBooks));
				}			
				var novelBooks = await _novelBookRepository.GetAllAsync(b => b.BookStatus == BookStatus.Borrowed);
				if (novelBooks == null)
				{
					throw new ArgumentNullException(nameof(novelBooks));
				}		
				var historyBooks = await _historyBookRepository.GetAllAsync(b => b.BookStatus == BookStatus.Borrowed);
				if (historyBooks == null)
				{
					throw new ArgumentNullException(nameof(historyBooks));
				}
				IEnumerable<Book> books = scienceBooks.ToList<Book>().Concat(novelBooks.ToList<Book>()).Concat(historyBooks.ToList<Book>());
				return books;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<IEnumerable<Member>> GetAllMembersAsync()
		{
			try
			{
				var members = await _memberRepository.GetAllAsync();
				if (members == null)
				{
					throw new ArgumentNullException(nameof(members));
				}
				return members;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<IEnumerable<Book>> GetAllBorrowedBooksByMemberAsync(Guid memberId)
		{
			try
			{
				var scienceBooks = await _scienceBookRepository.GetAllAsync(b => b.BookStatus == BookStatus.Borrowed && b.MemberId==memberId);
				if (scienceBooks == null)
				{
					throw new ArgumentNullException(nameof(scienceBooks));
				}
				var novelBooks = await _novelBookRepository.GetAllAsync(b => b.BookStatus == BookStatus.Borrowed);
				if (novelBooks == null)
				{
					throw new ArgumentNullException(nameof(novelBooks));
				}
				var historyBooks = await _historyBookRepository.GetAllAsync(b => b.BookStatus == BookStatus.Borrowed);
				if (historyBooks == null)
				{
					throw new ArgumentNullException(nameof(historyBooks));
				}
				IEnumerable<Book> books = scienceBooks.ToList<Book>().Concat(novelBooks.ToList<Book>()).Concat(historyBooks.ToList<Book>());
				return books;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task ReturnBookAsync( Guid bookId)
		{
			try
			{
				Book book = await _scienceBookRepository.GetByIdAsync(bookId);
				if (book == null)
				{
					book = await _historyBookRepository.GetByIdAsync(bookId);
				}
				if (book == null)
				{
					book = await _novelBookRepository.GetByIdAsync(bookId);
				}
				if (book.BookStatus != BookStatus.Borrowed)
				{
					throw new Exception("BOOK_NOT_BORROWED");
				}
				book.BookStatus = BookStatus.Available;
				book.MemberId =null;
				if (book is ScienceBook)
				{
					await _scienceBookRepository.UpdateAsync((ScienceBook)book);
				}
				else if (book is NovelBook)
				{

					await _novelBookRepository.UpdateAsync((NovelBook)book);
				}
				else if (book is HistoryBook)
				{

					await _historyBookRepository.UpdateAsync((HistoryBook)book);
				}
				await _memberRepository.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task UpdateBookStatusAsync(Guid bookId, BookStatus status)
		{
			try
			{
				Book book = await _scienceBookRepository.GetByIdAsync(bookId);
				if (book == null)
				{
					book = await _historyBookRepository.GetByIdAsync(bookId);
				}
				if (book == null)
				{
					book = await _novelBookRepository.GetByIdAsync(bookId);
				}
				book.BookStatus = status;
				if (book is ScienceBook)
				{
					await _scienceBookRepository.UpdateAsync((ScienceBook)book);
				}
				else if (book is NovelBook)
				{

					await _novelBookRepository.UpdateAsync((NovelBook)book);
				}
				else if (book is HistoryBook)
				{

					await _historyBookRepository.UpdateAsync((HistoryBook)book);
				}
				await _memberRepository.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<IEnumerable<Book>> GetAllBooksAsync()
		{
			try
			{
				var scienceBooks = await _scienceBookRepository.GetAllAsync();
				if (scienceBooks == null)
				{
					throw new ArgumentNullException(nameof(scienceBooks));
				}
				var novelBooks = await _novelBookRepository.GetAllAsync();
				if (novelBooks == null)
				{
					throw new ArgumentNullException(nameof(novelBooks));
				}
				var historyBooks = await _historyBookRepository.GetAllAsync();
				if (historyBooks == null)
				{
					throw new ArgumentNullException(nameof(historyBooks));
				}
				IEnumerable<Book> books = scienceBooks.ToList<Book>().Concat(novelBooks.ToList<Book>()).Concat(historyBooks.ToList<Book>());
				return books;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
