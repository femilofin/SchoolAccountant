using System;
using BusinessLogic.Constants;

namespace BusinessLogic.Entities
{
    /// <summary>
    /// Class model for dgv
    /// </summary>
    public class StudentView
    {
        public string Id { get; set; }
        public int Index { get; set; }
        public string FullName { get; set; }
        public string PresentClass { get; set; }
        public string OutstandingFee { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public ClassEnum StartClass { get; set; }
        public TermEnum StartTerm { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
        public DateTime StartDate { get; set; }
        public string PaidFee { get; set; }
        public TermEnum PresentTerm { get; set; }
        public ArmEnum PresentArm { get; set; }
        public ClassEnum PresentClassEnum { get; set; }
    }

    public class CompactStudentView
    {
        public string Id { get; set; }
        public int Index { get; set; }
        public string FullName { get; set; }
        public string PresentClass { get; set; }
    }
}