using System;
using System.ComponentModel.DataAnnotations;

namespace SellModule.Models
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Тип продукта")]
        public string ProductType { get; set; }

        [Display(Name = "Цена")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Дата заключения")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Статус договора")]
        public string Status { get; set; }

        [Display(Name = "Тип страхователя")]
        public string CustomerType { get; set; }

        [Display(Name = "Имя страхователя")]
        public string CustomerName { get; set; }

        [Display(Name = "Номер банковского счета")]
        public int BankNumber { get; set; }

        [Display(Name = "Адрес страхователя")]
        public string Adress { get; set; }

    }
}