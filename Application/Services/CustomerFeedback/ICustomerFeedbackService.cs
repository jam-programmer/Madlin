using Application.DataTransferObject;

namespace Application.Services.CustomerFeedback
{
    public interface ICustomerFeedbackService
    {
        Task InsertCustomerFeedbackAsync(CustomerFeedbackDto CustomerFeedback);
        Task UpdateCustomerFeedbackAsync(CustomerFeedbackDto CustomerFeedback);
        Task<CustomerFeedbackDto> GetCustomerFeedbackByIdAsync(Guid CustomerFeedbackId);
        Task DeleteCustomerFeedbackAsync(Guid CustomerFeedbackId);
    }
}
