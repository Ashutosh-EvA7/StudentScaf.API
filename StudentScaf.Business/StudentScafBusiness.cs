using StudentScaf.Business.Interfaces;
using StudentScaf.Entity.Models;

namespace StudentScaf.Business
{
    public class StudentScafBusiness : IStudentScafBusiness
    {
        private readonly IStudentScafRepository _studentScafRepository;

        public StudentScafBusiness(IStudentScafRepository studentScafRepository)
        {
            _studentScafRepository = studentScafRepository;
        }

        public List<StudentScaff> GetList()
        {
            List<StudentScaff> studentScaffModels = _studentScafRepository.GetList();
            List<StudentScaff> students = new List<StudentScaff>();
            foreach (StudentScaff studentScaffModel in studentScaffModels)
            {
                students.Add(new StudentScaff
                {
                    StudentId = studentScaffModel.StudentId,
                    Sname = studentScaffModel.Sname,
                    Sclass = studentScaffModel.Sclass,
                    StotalMarksObtained = studentScaffModel.StotalMarksObtained
                });
            }
            return students;
        }

        public StudentScaff GetById(int id)
        {
            StudentScaff studentScaffModel = _studentScafRepository.GetById(id);
            if (studentScaffModel == null)
            {
                return null;
            }
            return new StudentScaff
            {
                StudentId = studentScaffModel.StudentId,
                Sname = studentScaffModel.Sname,
                Sclass = studentScaffModel.Sclass,
                StotalMarksObtained = studentScaffModel.StotalMarksObtained
            };
        }

        public void Add(StudentScaff student)
        {
            _studentScafRepository.Add(new StudentScaff
            {
                StudentId = student.StudentId,
                Sname = student.Sname,
                Sclass = student.Sclass,
                StotalMarksObtained = student.StotalMarksObtained
            });
        }

        public void Update(int id, StudentScaff student)
        {
            _studentScafRepository.Update(id, new StudentScaff
            {
                StudentId = student.StudentId,
                Sname = student.Sname,
                Sclass = student.Sclass,
                StotalMarksObtained = student.StotalMarksObtained
            });
        }

        public void Delete(int id)
        {
            _studentScafRepository.Delete(id);
        }
    }
}