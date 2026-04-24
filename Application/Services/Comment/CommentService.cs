using Application.Common.Extension;
using Domain.Entities.Product;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Comment;

public class CommentService : ICommentService
{
    readonly ICommentRepository _commentRepository;
    readonly IResponseRepository _responseRepository;
    public CommentService(ICommentRepository commentRepository,
        IResponseRepository responseRepository)
    {
        _commentRepository = commentRepository;
        _responseRepository = responseRepository;
    }

  
    public async Task DeleteCommentAsync(Guid Id)
    {
        CommentEntity commentEntity = await _commentRepository.GetByIdAsync(g => g.Id == Id);
        if (commentEntity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        commentEntity.IsDeleted = true;
        await _commentRepository.UpdateAsync(commentEntity);
    }

 

    public async Task<PaginatedList<CommentDto>> GetCommentsAsync(Pagination pagination)
    {
        IQueryable<CommentEntity> query = _commentRepository.GetByQuery();
       
        TypeAdapterConfig config = new();
        config.NewConfig<CommentEntity, CommentDto>()
            .Map(d => d.Id, s => s.Id)
            .Map(d => d.CreatedDate, s => s.CreatedDate!.Value.PersianDateWithTime())
            .Map(d => d.UserPublicName, s => s.UserPublicName)
            .Map(d => d.UserPhoneNumber, s => s.UserPhoneNumber)
            .Map(d => d.ProductTitleFa, s => s.Product!.TitleFa)
            .Map(d => d.Title, s => s.Title)
            .Map(d => d.IsActive, s => s.IsActive)
            .Compile();
        PaginatedList<CommentDto> model = new();
        query = query.Include(i => i.Product);
        if (!string.IsNullOrEmpty(pagination!.keyword))
        {
            query = query.Where(w =>
                 w.Title!.Contains(pagination!.keyword));
        }
        int count = query.Count().PageCount(pagination!.pageSize);
        int total = query.Count();
        query = query.OrderByDescending(o => o.CreatedDate);
        model = await query.MappingedAsync<CommentEntity, CommentDto>
                (pagination!.currentPage,
                pagination!.pageSize, count, total,config);
        return model;
    }

    public async Task<CommentDto> GetCommentByIdAsync(Guid Id)
    {
        IQueryable<CommentEntity> query = _commentRepository.GetByQuery();
        query = query.Include(i => i.Product);
        query = query.Include(i => i.Response);
        CommentEntity? commentEntity = await query.FirstOrDefaultAsync(f => f.Id == Id);
        if (commentEntity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }

        CommentDto comment=new();
        comment.Id = Id;
        comment.ProductTitleFa = commentEntity.Product.TitleFa;
        comment.Title = commentEntity.Title;    
        comment.Text = commentEntity.Text;
        comment.UserPhoneNumber = commentEntity.UserPhoneNumber;
        comment.UserPublicName = commentEntity.UserPublicName;
        comment.CreatedDate=commentEntity.CreatedDate!.Value.PersianDateWithOutTime();
        comment.Reply=commentEntity.Response.Text;
        comment.IsActive = commentEntity.IsActive;
        return comment;
    }

    public async Task InsertCommentAsync(CommentDto comment)
    {
        CommentEntity? commentEntity = comment.Adapt<CommentEntity>();
        await _commentRepository.InsertAsync(commentEntity);
    }

    public async Task UpdateCommentAsync(CommentDto comment)
    {
        ResponseEntity responseEntity = await _responseRepository.GetByIdAsync(e => e.CommentId == comment.Id);
        if (responseEntity == null)
        {
            responseEntity = new ResponseEntity();
            responseEntity.Text = comment.Reply;
            responseEntity.CommentId=comment.Id;
            await _responseRepository.InsertAsync(responseEntity);
        }
        else
        {
            responseEntity.Text = comment.Reply;
            await _responseRepository.UpdateAsync(responseEntity);
        }

        CommentEntity commentEntity = await _commentRepository.GetByIdAsync(g => g.Id == comment.Id);
        if (commentEntity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        commentEntity.IsActive= comment.IsActive;
         await _commentRepository.UpdateAsync(commentEntity);
    }

    public async Task<IReadOnlyList<ProductCommentDto>> GetCommentsByProductIdAsync(Guid ProductId)
    {
        IList<CommentEntity> comments=await _commentRepository.GetCommentsByProductIdAsync(ProductId);
        return comments.Adapt<IReadOnlyList<ProductCommentDto>>();
    }
}
