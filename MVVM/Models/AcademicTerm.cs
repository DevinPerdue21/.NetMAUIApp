using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C971.MVVM.Models
{
    [Table("Terms")]
    public class AcademicTerm
    {
        [PrimaryKey, AutoIncrement, Column("TermID")]
        public int termID { get; set; }
        public string termName { get; set; }
        public DateTime termStartDate { get; set; }
        public DateTime termEndDate { get; set; }
    }
}
