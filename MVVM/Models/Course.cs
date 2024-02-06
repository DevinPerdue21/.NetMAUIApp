using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForeignKeyAttribute = SQLiteNetExtensions.Attributes.ForeignKeyAttribute;

namespace C971.MVVM.Models
{
    [SQLite.Table("Courses")]
    public class Course
    {
        [PrimaryKey, AutoIncrement, SQLite.Column("CourseID")]
        public int courseID { get; set; }
        public string courseName { get; set; }
        public DateTime courseStartDate { get; set; }
        public DateTime courseEndDate { get; set; }
        public string courseStatus { get; set; }
        public string instructorName { get; set; }
        public string instructorPhoneNumber { get; set; }
        public string instructorEmail { get; set; }
        public bool startCourseAlert { get; set; }
        public bool endCourseAlert { get; set; }    
        public string optionalNotes { get; set; }
        public string performanceName { get; set; }
        public string objectiveName { get; set; }
        public DateTime performanceDue { get; set; }
        public DateTime objectiveDue { get; set; }
        public bool performanceAlert { get; set; }
        public bool objectiveAlert { get; set; }

        [ForeignKey(typeof(AcademicTerm))]
        public int TermID { get; set; }
    }
}
