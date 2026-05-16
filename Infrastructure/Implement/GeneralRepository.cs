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

public class GeneralRepository
    :Repository<GeneralEntity>, IGeneralRepository
{
    readonly SqlServerContext _context;
    public GeneralRepository(SqlServerContext context):base(context)
    {
        _context = context; 
    }

    public async Task<GeneralEntity> GetGeneralAsync(CancellationToken cancellationToken = default)
    {
       return await _context.Set<GeneralEntity>().
            FirstOrDefaultAsync(cancellationToken); 
    }

    public async Task<SeoEntity> GetSeoAsync
        (CancellationToken cancellationToken = default)
    {
        return await _context.Set<SeoEntity>().
           FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<(string toke, string number)> GetSmsInfoAsync()
    {
       GeneralEntity? general=
            await _context.Set<GeneralEntity>() .FirstOrDefaultAsync();
        return (general!.SmsToken!, general.ExclusiveNumber!);
    }

    public async Task UpdateSeoAsync(SeoEntity seo)
    {
         _context.Update(seo);
        await _context.SaveChangesAsync();  
    }
}
