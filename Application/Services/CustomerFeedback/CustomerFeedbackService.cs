using Application.Common.CustomException;
using Application.Common.Resource;
using Application.Contract;
using Application.DataTransferObject;
using Domain.Entities.System;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CustomerFeedback
{
    public class CustomerFeedbackService : ICustomerFeedbackService
    {
        readonly ICustomerFeedbackRepository _customerFeedbackRepository;
        public CustomerFeedbackService(ICustomerFeedbackRepository customerFeedbackRepository)
        {
            _customerFeedbackRepository = customerFeedbackRepository;
        }
        public async Task DeleteCustomerFeedbackAsync(Guid CustomerFeedbackId)
        {
            CustomerFeedbackEntity? customerFeedback = await _customerFeedbackRepository
    .GetByIdAsync<CustomerFeedbackEntity>(g => g.Id == CustomerFeedbackId);

            if (customerFeedback == null)
            {
                throw new InternalException(Messages.NotFoundOnDb);
            }

            customerFeedback.IsDeleted = true;

            await _customerFeedbackRepository.UpdateAsync(customerFeedback);
        }

        public async Task<CustomerFeedbackDto> GetCustomerFeedbackByIdAsync(Guid CustomerFeedbackId)
        {
            CustomerFeedbackEntity? customerFeedback = await _customerFeedbackRepository
         .GetByIdAsync<CustomerFeedbackEntity>(g => g.Id == CustomerFeedbackId);
            if (customerFeedback == null)
            {
                throw new InternalException(Messages.NotFoundOnDb);
            }
            return customerFeedback.Adapt<CustomerFeedbackDto>();
        }

        public async Task InsertCustomerFeedbackAsync(CustomerFeedbackDto CustomerFeedback)
        {
            CustomerFeedbackEntity customerFeedback = CustomerFeedback.Adapt<CustomerFeedbackEntity>();

            await _customerFeedbackRepository.InsertAsync(customerFeedback);
        }

        public async Task UpdateCustomerFeedbackAsync(CustomerFeedbackDto CustomerFeedback)
        {
            CustomerFeedbackEntity? customerFeedback = await _customerFeedbackRepository
       .GetByIdAsync<CustomerFeedbackEntity>(g => g.Id == CustomerFeedback.Id);
            if (customerFeedback == null)
            {
                throw new InternalException(Messages.NotFoundOnDb);
            }
            CustomerFeedback.Adapt(customerFeedback);
            await _customerFeedbackRepository.UpdateAsync(customerFeedback);
        }
    }
}
