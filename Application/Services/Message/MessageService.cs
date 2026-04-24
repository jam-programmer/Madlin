using Application.Common.Extension;
using Domain.Entities.System;
using Mapster;

namespace Application.Services.Message;

public class MessageService : IMessageService
{
    readonly IMessageRepository _messageRepository;
    public MessageService(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }
    public async Task DeleteMessageAsync(Guid Id)
    {
        MessageEntity Message = await _messageRepository.GetByIdAsync(g => g.Id == Id);
        if (Message == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        Message.IsDeleted = true;
        await _messageRepository.UpdateAsync(Message);
    }

    public async Task<MessageDto> GetMessageByIdAsync(Guid Id)
    {
        TypeAdapterConfig config = new();
        config.NewConfig<MessageEntity, MessageDto>()

             .Map(d => d.Id, s => s.Id)
             .Map(d => d.Message, s => s.Message)
             .Map(d => d.Name, s => s.Name)
             .Map(d => d.Email, s => s.Email)
             .Map(d => d.CreatedAt, s => s.CreatedAt.PersianDateWithTime())
                     .Compile();
        MessageEntity Message = await _messageRepository.GetByIdAsync(g => g.Id == Id);
        if (Message == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        return Message.Adapt<MessageDto>(config);
    }

    public async Task<PaginatedList<MessageDto>> GetMessagesAsync(Pagination pagination)
    {
        TypeAdapterConfig config = new();
        config.NewConfig<MessageEntity, MessageDto>()

             .Map(d => d.Id, s => s.Id)
             .Map(d => d.Name, s => s.Name)
             .Map(d => d.Email, s => s.Email)
             .Map(d => d.CreatedAt, s => s.CreatedAt.PersianDateWithTime())
                     .Compile();
        IQueryable<MessageEntity> query = _messageRepository.GetByQuery();
        query = query.OrderByDescending(d => d.CreatedAt);
        if (string.IsNullOrEmpty(pagination.keyword) is false)
        {
            query = query.Where(w => w.Name!.Contains(pagination.keyword)
            || w.Email!.Contains(pagination.keyword));
        }
        int count = query.Count().PageCount(pagination.pageSize);
        int total = query.Count();
        PaginatedList<MessageDto>
        model = await query.MappingedAsync<MessageEntity, MessageDto>(pagination.currentPage,
            pagination.pageSize, count, total, config);
        return model;
    }

    public async Task InsertMessageAsync(MessageDto message)
    {
        MessageEntity messageEntity = new();
        messageEntity.Message = message.Message;
        messageEntity.Name = message.Name;
        messageEntity.Email = message.Email;
        await _messageRepository.InsertAsync(messageEntity);
    }
}
