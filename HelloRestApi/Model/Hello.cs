using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelloRestApi.Model
{
    public class Hello
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Treść wiadomości nie może być pusta")]
        public string Message { get; set; }
        [Required(ErrorMessage = "Proszę podać autora wpisu")]
        public string Author { get; set; }

        [Column("TimeStamp")]
        public DateTime DateTimeStamp { get; private set; }

        [NotMapped]
        public string TimeStamp { get => DateTimeStamp.ToShortDateString(); }

        public Hello()
        {
            DateTimeStamp = DateTime.Now;
        }
    }
}
