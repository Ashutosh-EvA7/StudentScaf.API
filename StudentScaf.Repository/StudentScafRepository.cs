using StudentScaf.ViewModel;
using StudentScaf.Business;
using StudentScaf.Entity.Models;

namespace StudentScaf.Repository
{
    public class StudentRepository : IStudentScafRepository
    {
        private readonly StudentScaffoldContext _dbContext;
        public StudentRepository(StudentScaffoldContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public List<StudentScaff> GetList()
        {
            List<StudentScaff> studentList = new();
            studentList = _dbContext.StudentScaffs.ToList();
            return studentList;
        }

        public StudentScaff GetById(int id)
        {
            StudentScaff std = new();
            std = _dbContext.StudentScaffs.First(p => p.StudentId == id);
            return std;
        }

        public void Add(StudentModel student)
        {
            StudentScaff newStudent = new();
            newStudent.StudentId = student.StudentId;
            newStudent.Sname = student.Sname;
            newStudent.Sclass = student.Sclass;
            newStudent.StotalMarksObtained = student.StotalMarksObtained;

            _dbContext.StudentScaffs.Add(newStudent);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var x = _dbContext.StudentScaffs.FirstOrDefault(p => p.StudentId == id);
            _dbContext.StudentScaffs.Remove(x);
            _dbContext.SaveChanges();
        }

        List<StudentModel> IStudentScafRepository.GetList()
        {
            throw new NotImplementedException();
        }

        StudentModel IStudentScafRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
