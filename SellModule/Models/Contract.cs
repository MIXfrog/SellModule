using System;
using System.ComponentModel.DataAnnotations;

namespace SellModule.Models
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }
        
        public int ProductId { get; set; }

        [Display(Name = "Цена")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Дата заключения")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int ContractStatusId { get; set; }

        public int CustomerId { get; set; }

        public int VendorId { get; set; }
    }

    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        
        public int CustomerTypeId { get; set; }

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

    public class Vendor
    {
        [Key]
        public int VendorId { get; set; }

        public string VendorLogin { get; set; }

        public string VendorPassword { get; set; }

        [Display(Name = "Имя продавца")]
        public string VendorName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string VendorEmail { get; set; }

        public int VendorRoleId { get; set; }
    }

    public class VendorRole
    {
        [Key]
        public int VendorRoleId { get; set; }

        [Display(Name = "Должность продавца")]
        public string VendorRoleName { get; set; }
    }

    public class ContractStatus
    {
        [Key]
        public int ContractStatusId { get; set; }
        
        [Display(Name = "Статус договора")]
        public string ContractStatusName { get; set; }
    }
}