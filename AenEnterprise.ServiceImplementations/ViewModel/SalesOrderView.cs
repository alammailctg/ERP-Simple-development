using AenEnterprise.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AenEnterprise.ServiceImplementations.Implementation.SalesOrderService;

namespace AenEnterprise.ServiceImplementations.ViewModel
{
    public class SalesOrderView
    {
        public SalesOrderView()
        {
            Invoices = new List<InvoiceView>();
            OrderItems = new List<OrderItemView>();
            DeliveryOrders =new List<DeliveryOrderView>();
            DispatcheOrders = new List<DispatcheOrderView>();
        }
        public int Id { get; set; }
        public string DispatchNo { get; set; }
        public string DeliveryOrderNo { get; set; }
        public string InvoiceNo { get; set; }
        public string SalesOrderNo { get; set; } = string.Empty;
        public string CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime OrderedDate { get; set; }
        public List<SalesOrderDetails> SalesOrders { get; set; }
        public string OrderDateInFormat
        {
            get
            {
                return OrderedDate.ToString("dddd, dd MMMM yyyy");
            }
        }

        public string Description { get; set; } = string.Empty;
        public int CustomerId { get; set; }
       
        public IEnumerable<InvoiceView> Invoices { get; set; }
        public IEnumerable<OrderItemView> OrderItems { get; set; }
        public IEnumerable<DeliveryOrderView> DeliveryOrders { get; set; }
        public IEnumerable<DispatcheOrderView> DispatcheOrders { get; set; }
        public int SalesOrderStatusId { get; set; }

        public string TotalAmountInCurrency
        {
            get
            {
                return $"{TotalAmount:#,#.##}";
            }
        }

        public string TotalInvoicedQuantityInFormat
        {
            get
            {
                return $"{TotalInvoicedQuantity:#,#.##}";
            }
        }

        public string TotalQuantityInFormat
        {
            get
            {
                return $"{TotalQuantity:#,#.##}";
            }
        }

        public decimal TotalAmount { get; set; }
        public decimal TotalInvoicedQuantity { get; set; }
        public decimal TotalQuantity { get; set; }
    }
}
