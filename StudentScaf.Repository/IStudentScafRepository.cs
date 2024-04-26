using StudentScaf.ViewModel;

namespace StudentScaf.Business
{
    public interface IStudentScafRepository
    {
        List<StudentModel> GetList();
        StudentModel GetById(int id);
    }
}