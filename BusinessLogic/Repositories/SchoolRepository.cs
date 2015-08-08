using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Constants;
using BusinessLogic.Entities;
using BusinessLogic.Interface;
using log4net;
using log4net.Config;
using MongoRepository;

namespace BusinessLogic.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly ILog _log = LogManager.GetLogger("BusinessLogic.UserRepository.cs");
        private readonly MongoRepository<School> _schoolRepository = new MongoRepository<School>();
        private readonly IAuditTrailRepository _auditTrailRepository = new AuditTrailRepository();
        private readonly IStudentRepository _studentRepository = new StudentRepository();
        private readonly IClassTermFeeRepository _classTermFeeRepository = new ClassTermFeeRepository();

        public SchoolRepository()
        {
            XmlConfigurator.Configure();
        }

        public School Get()
        {
            try
            {
                var school = _schoolRepository.FirstOrDefault();

                return school ?? new School();
            }
            catch (Exception ex)
            {
                _log.Error("Error", ex);
                return null;
            }
        }

        public bool PromoteStudents(List<Student> repeatingStudents)
        {
            // Get all active students
            try
            {
                var students = _studentRepository.GetActiveStudents();

                // Get promoting students
                var promotingStudents = students.Where(x => repeatingStudents.All(y => y.Id != x.Id)).ToList();

                foreach (var student in promotingStudents)
                {
                    var presentClass = student.PresentClass;

                    switch (presentClass)
                    {
                        case ClassEnum.JSS1:
                            {
                                //Promote to Jss 2
                                student.PresentClass = ClassEnum.JSS2;
                                _studentRepository.Edit(student);
                            }
                            break;
                        case ClassEnum.JSS2:
                            {
                                //Promote to Jss 3
                                student.PresentClass = ClassEnum.JSS3;
                                _studentRepository.Edit(student);
                            }
                            break;
                        case ClassEnum.JSS3:
                            {
                                //Promote to Sss 1
                                student.PresentClass = ClassEnum.SSS1;
                                _studentRepository.Edit(student);
                            }
                            break;
                        case ClassEnum.SSS1:
                            {
                                //Promote to Sss 2
                                student.PresentClass = ClassEnum.SSS2;
                                _studentRepository.Edit(student);
                            }
                            break;
                        case ClassEnum.SSS2:
                            {
                                //Promote to Sss 3
                                student.PresentClass = ClassEnum.SSS3;
                                _studentRepository.Edit(student);
                            }
                            break;
                        case ClassEnum.SSS3:
                            {
                                // Deactivate student
                                student.Active = false;
                                _studentRepository.Edit(student);
                            }
                            break;
                    }


                    var school = _schoolRepository.FirstOrDefault();

                    //Update School details

                    //todo: test that school is not null
                    school.PresentTermEnum = TermEnum.First;
                    school.PromotionDate = DateTime.Now;
                    school.TermStart = DateTime.Now;
                    school.PresentSession = $"{DateTime.Now.Year}/{DateTime.Now.Year + 1}}}";
                    school.SessionStart = DateTime.Now;

                    _schoolRepository.Update(school);
                }
                return true;
            }
            catch (Exception ex)
            {
                _log.Error("Error", ex);
                return false;
            }
        }

        public bool UpdateStudentFees()
        {
            try
            {
                var students = _studentRepository.GetActiveStudents();
                var currentFees = _classTermFeeRepository.GetCurrentFees();

                foreach (var student in students)
                {
                    var presentClass = student.PresentClass;

                    var isNewIntake = presentClass == student.StartClass && student.StartTerm == student.PresentTerm;

                    if (isNewIntake)
                    {
                        if (presentClass == ClassEnum.JSS1 || presentClass == ClassEnum.JSS2 || presentClass == ClassEnum.JSS3)
                        {
                            student.OutstandingFee += currentFees.FirstOrDefault(x => x.ClassEnum == ClassEnum.JSS).Fee;
                            break;
                        }
                        else
                        {
                            student.OutstandingFee += currentFees.FirstOrDefault(x => x.ClassEnum == ClassEnum.SSS).Fee;
                            break;
                        }
                    }

                    var classTermFee = currentFees.FirstOrDefault(x => x.ClassEnum == presentClass);

                    if (classTermFee != null)
                    {
                        student.OutstandingFee += classTermFee.Fee;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                _log.Error("Error", ex);
                return false;
            }

        }

        public bool UndoUpdatedFees()
        {
            try
            {
                var students = _studentRepository.GetActiveStudents();
                var currentFees = _classTermFeeRepository.GetCurrentFees();

                foreach (var student in students)
                {
                    var presentClass = student.PresentClass;

                    var isNewIntake = presentClass == student.StartClass && student.StartTerm == student.PresentTerm;

                    if (isNewIntake)
                    {
                        if (presentClass == ClassEnum.JSS1 || presentClass == ClassEnum.JSS2 || presentClass == ClassEnum.JSS3)
                        {
                            student.OutstandingFee -= currentFees.FirstOrDefault(x => x.ClassEnum == ClassEnum.JSS).Fee;
                            break;
                        }
                        else
                        {
                            student.OutstandingFee -= currentFees.FirstOrDefault(x => x.ClassEnum == ClassEnum.SSS).Fee;
                            break;
                        }
                    }

                    var classTermFee = currentFees.FirstOrDefault(x => x.ClassEnum == presentClass);

                    if (classTermFee != null)
                    {
                        student.OutstandingFee -= classTermFee.Fee;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                _log.Error("Error", ex);
                return false;
            }
        }

        public string SchoolSetup(School school)
        {
            try
            {
                _schoolRepository.Add(school);

                _auditTrailRepository.Log($"School {school.Name} Created", AuditActionEnum.Created);
                _log.Info("School Created");
                return school.Id;
            }
            catch (Exception ex)
            {
                _log.Error("Error", ex);
                return null;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                _schoolRepository.Delete(id);
                _log.Info("School Deleted");
                return true;
            }
            catch (Exception ex)
            {
                _log.Error("Error", ex);
                return false;
            }
        }

    }
}
