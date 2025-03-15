using CSProjeDemo1.CSProjeDemo1.Core.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.CSProjeDemo1.Data.Repositories.Interfaces
{
    public interface IBookRepository<T> where T:Book
    {

    }
}
