using System;
using System.ComponentModel.DataAnnotations;

namespace SellModule.Models
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }
        
        public string ProductId { get; set; }

        [Display(Name = "Цена")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Дата заключения")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Статус договора")]
        public string Status { get; set; }

        public string CustomerId { get; set; }
    }

    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        
        public string CustomerTypeId { get; set; }

        [Display(Name = "Имя страхователя")]
        public string CustomerName { get; set; }

        [Display(Name = "Номер банковского счета")]
        public int BankNumber { get; set; }
        
        [Display(Name = "Адрес страхователя")]
        public string Adress { get; set; }
    }

    public class ProductType
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "Тип продукта")]
        public string ProductName { get; set; }
    }

    public class CustomerType
    {
        [Key]
        public int CustomerTypeId { get; set; }
        
        [Display(Name = "Тип страхователя")]
        public string CustomerTypeName { get; set; }
    }
}