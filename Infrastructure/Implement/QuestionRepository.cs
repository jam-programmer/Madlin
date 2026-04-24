using Domain.Contract;
using Domain.Entities.System;
using Infrastructure.Context;

namespace Infrastructure.Implement;

public class QuestionRepository : Repository<QuestionEntity>,IQuestionRepository
{
    readonly SqlServerContext _context;
    public QuestionRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }
}
