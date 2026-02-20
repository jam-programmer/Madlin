using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Extension
{


    internal static class ModelBuilderExtension
    {
        internal static void AppendDbSetOfEntity(this ModelBuilder builder)
        {
            Assembly? assemblyBi = Assembly.GetAssembly(typeof(Domain.Entities.BaseEntity));
            if (assemblyBi is not null)
            {
                List<Type> entities = assemblyBi.GetTypes()
                   .Where(w => w.IsClass
                   && w.IsPublic
                   && w.BaseType != null && w.BaseType == typeof(BaseEntity))
                   .ToList();
                entities.ForEach(entity => builder.Entity(entity));
            }

        }
    }


}
