using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autovokzal_v1._0.Models
{
    public class Personal
    {
        public int Id { get; set; }
        public int? Short_Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public DateTime? Date { get; set; }
        public string? Otdel { get; set; } = null!;
        public string Phone { get; set; }
    }
}
