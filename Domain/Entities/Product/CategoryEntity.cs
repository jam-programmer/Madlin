using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product
{
   public class CategoryEntity:BaseEntity,IDelete
    {
        public string TitleEn { get; set; }
        public string TitleFa { get; set; }

        public string DescriptionEn { get; set; }
        public string DescriptionFa { get; set; }



        public string? MainImagePath { get; set; }

        public string? IconImagePath { get; set; }

        public bool IsFeatured { get; set; }

        #region Relation 
        public CategoryEntity? ParentCategory { get; set; }
        public Guid? ParentProductCategoryId { get; set; }
        public ICollection<ProductEntity>? Products { get; set; }
        public ICollection<CategoryEntity>? SubCategories { get; set; }
        #endregion
        public bool IsDeleted { get; set; }
    }
}
