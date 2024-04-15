using Data.Models.Context;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories;

public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository 
{
    public QuestionRepository(MyContext myContext): base(myContext)
    {

    }

    public async Task<IEnumerable<Question>> GetAll() => 
     await m_DbSet.Include(x => x.QuestionOptions).ToListAsync();
    
}
