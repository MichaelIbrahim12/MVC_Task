using MVC_Task.Models;
using MVC_Task.Models.Entities;

namespace MVC_Task.Services
{
    public interface IStudent
    {
        List<Student> GetAllStudentsForPage(int toSkip, int pageSize);
        public List<Student> GetAllStudents();

        void AddStudent(Student student);

        Student GetStudentById(int Id);

        void UpdateStudent( Student Student);
        void DeleteStudent(int Id);

        List<Student> GetStudentsByName(string Name);
        List<Student> GetStudentsByGender(string Gender);
        List<Student> GetStudentsByCity(string City);
        List<Student> GetStudentsByDate(DateTime? From, DateTime? To);
        public List<Student> SearchStudent(StudentSearch Student);

        void SaveChanges();

    }
}
