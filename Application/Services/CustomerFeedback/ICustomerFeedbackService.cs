using Application.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
