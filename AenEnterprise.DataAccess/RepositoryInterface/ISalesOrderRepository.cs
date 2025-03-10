﻿using AenEnterprise.DataAccess.Criterias;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;

namespace AenEnterprise.DataAccess.RepositoryInterface
{
    public interface ISalesOrderRepository : IGenericRepository<SalesOrder>
    {
        Task<SalesOrder> GetSalesOrderByIncludeId(int salesOrderId);
        Task<IQueryable<SalesOrder>> GetSalesOrderQuery(SalesOrderCriteria request, int statusId, bool isPartiallyApproved);
    }
}
