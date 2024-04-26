using StudentScaf.Entity.Models;

namespace StudentScaf.Business.Interfaces
{
    public interface IStudentScafBusiness
    {
        List<StudentScaff> GetList();
        StudentScaff GetById(int id);
        void Add(StudentScaff student);
        void Update(int id, StudentScaff student);
        void Delete(int id);
    }
}