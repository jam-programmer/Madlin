using Domain.Entities.Blog;
using Domain.Entities.Product;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Identity;

public class UserEntity : IdentityUser<Guid>,IDelete
{
	public override string Email
	{
		get => base.Email;
		set => base.Email = value;
	}
	public string? FullName { get; set; }
    public ICollection<BlogEntity>? Blogs { get; set; }
	public ICollection<WishEntity> Wishes { get; set; }
    public bool IsDeleted { get; set; } = false;
}
