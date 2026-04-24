using Domain.Contract;
using Domain.Entities.System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implement;

public class AboutRepository : IAboutRepository
{
    readonly SqlServerContext _context;
    public AboutRepository(SqlServerContext context)
    {
        _context = context; 
    }
    public async Task<AboutEntity> GetAboutAsync()
    {
       return await _context.Set<AboutEntity>().FirstOrDefaultAsync();
    }

    public async Task UpdateAboutAsync(AboutEntity about)
    {
        _context.Update(about);
        await 
            _context.SaveChangesAsync();
    }
}
