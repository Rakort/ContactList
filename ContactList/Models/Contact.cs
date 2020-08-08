using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactList.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Имя должно быть заполнено")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Фамилия должна быть заполнена")]
        public string SecondName { get; set; }
        public string Phone { get; set; }
        [EmailAddress(ErrorMessage = "Некорректный электронный адрес")]
        public string Email { get; set; }

        public Contact()
        {
            Id = Guid.Empty;
        }

        public Contact(string firstName, string secondName, string phone = null, string email = null)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            SecondName = secondName;
            Phone = phone;
            Email = email;
        }
    }
}
