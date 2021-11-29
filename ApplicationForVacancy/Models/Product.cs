using System;
using System.ComponentModel.DataAnnotations;


namespace ApplicationForVacancy.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Введите идентификатор изделия.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Введите наименование изделия.")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
