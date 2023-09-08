namespace QLSV_TEST.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public Guid? APK { get; set; }

        [StringLength(50)]
        public string EmployeeID { get; set; }

        [StringLength(250)]
        public string EmployeeName { get; set; }

        public DateTime? Birthday { get; set; }

        [StringLength(100)]
        public string IdentifyCardNo { get; set; }

        public DateTime? IdentifyDate { get; set; }

        [StringLength(250)]
        public string IndentifyPlace { get; set; }

        public string Address { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Phone { get; set; }
    }
}
