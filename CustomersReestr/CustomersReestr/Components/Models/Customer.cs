﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomersReestr.Components.Models

    /*тут задается структура нашей таблицы или таблиц
     * можно прописать почти все, что создается в SQL*/

{
   public class Customers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //автогенерация ИД
        public int Id { get; set; }

        [Required] [Column("Имя")]
        public string Name { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required] [MaxLength(10)]
        public string Sex { get; set; }

        [MaxLength(30)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
        
        public DateTime RegDate { get; set; }
        
        public DateTime LastModified { get; set; }

        [NotMapped]
        public string FullName {
            get {
                return LastName + " " + Name + " " + MiddleName;
            }
        }

        [NotMapped]
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - BirthDate.Year;
                if (today < BirthDate.AddYears(age)) // когда текущая дата меньше даты дня рождения, нужно уменьшить получившийся возраст
                    age--;
                return age;
            }
        }

        [NotMapped]
        public DateTime NextBirthDate
        {
            get
            {
                return BirthDate.AddYears(1);
            }
        }
    }
}

