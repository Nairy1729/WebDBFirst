using System;
using System.Collections.Generic;

namespace WebDBFirst.Models
{
    public partial class TblDeparment
    {
        public TblDeparment()
        {
            TblEmployees = new HashSet<TblEmployee>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string DepartmentHead { get; set; } = null!;

        public virtual ICollection<TblEmployee> TblEmployees { get; set; }
    }
}
