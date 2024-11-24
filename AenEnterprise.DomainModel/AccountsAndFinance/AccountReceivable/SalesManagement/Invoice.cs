using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement
{
    public class Invoice
    {
        public int Id { get; set; }
        private SalesOrder _salesOrder;
        private string _invoiceNo;
        private IList<InvoiceItem> _invoiceItems;
        private decimal _outstandingAmount;
        private decimal _invoiceAmount;
        public Invoice()
        {
            _invoiceItems = new List<InvoiceItem>();
            CreatedDate = DateTime.Today;
        }
        public DateTime CreatedDate { get; set; }
        public int SalesOrderId { get; set; }
        public SalesOrder SalesOrder { get => _salesOrder; set => _salesOrder = value; }
        public string InvoiceNo { get => _invoiceNo; set => _invoiceNo = value; }

        public List<DeliveryOrder> DeliveryOrders { get; set; }
        public List<DispatcheOrder> DispatcheOrders { get; set; }
        public List<PaymentReceipt> paymentReceipts  { get; set; }
        public List<CreditMemo> CreditMemos { get; set; }
        public IEnumerable<InvoiceItem> InvoiceItems { get => _invoiceItems; }
        public decimal OutstandingAmount { get => _outstandingAmount; set => _outstandingAmount = value; }
        public decimal InvoiceAmount { get => _invoiceAmount; set => _invoiceAmount = value; }
        
        public void setInvoiceItem(InvoiceItem invoiceItem, decimal quantity)
        {
            GetInvoiceItems(invoiceItem.Id).SetBalanceQuantity(quantity);
        }

        public InvoiceItem GetInvoiceItems(int invoiceItemId)
        {
            return _invoiceItems.FirstOrDefault(invItem => invItem.Id == invoiceItemId);
        }
        public void RecalculateInvoiceAmount()
        {
            _invoiceAmount = _invoiceItems.Sum(item => item.InvoiceAmount);
            OutstandingAmount = _invoiceAmount; // Initially, OutstandingAmount equals InvoiceAmount
        }

        public void CreateInvoiceItem(OrderItem orderItem, decimal invoiceQuantity, int statusId)
        {
            _invoiceItems.Add(InvoiceItemFactory.CreateInvoiceItemFactory(this, orderItem, invoiceQuantity, statusId, true));
            RecalculateInvoiceAmount();
        }

        public void ApplyPayment(decimal paymentAmount)
        {
            if(OutstandingAmount > paymentAmount)
            {
                OutstandingAmount -= paymentAmount;
            }
            else
            {
                throw new Exception("Payment amount exceeds the outstanding invoice amount");
            }
        }
    }
}
