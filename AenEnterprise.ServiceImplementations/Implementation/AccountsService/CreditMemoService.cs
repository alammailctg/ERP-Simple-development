using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DataAccess.RepositoryInterface.AccountRepositoriesInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.ServiceImplementations.Messaging.AccountsReceivable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Implementation.AccountsService
{
    public class CreditMemoService:ICreditMemoService
    {
        private readonly ICreditMemoRepository _creditMemoRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        public CreditMemoService(ICreditMemoRepository creditMemoRepository, 
            ICustomerRepository customerRepository, 
            IInvoiceRepository invoiceRepository)
        {
            _creditMemoRepository = creditMemoRepository;
            _customerRepository = customerRepository;
            _invoiceRepository = invoiceRepository;
        }

        public async Task<CreateCreditMemoResponse> AddCreditMemoAsync(CreateCreditMemoRequest request)
        {
            Customer customer = await _customerRepository.GetByIdAsync(request.CustomerId);


            CreditMemo creditMemo = new CreditMemo()
            {
                CustomerId = customer.Id,
                CreditAmount = request.CreditAmount,
                IssueDate = request.IssueDate,
                InvoiceId = request.InvoiceId

            };

            throw new NotImplementedException();
        }

        public Task<CreditMemo> GetCreditMemoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveCreditMemoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCreditMemoAsync(CreditMemo creditMemo)
        {
            throw new NotImplementedException();
        }
    }
}
