using MVC_Task.Data;
using MVC_Task.Models.Entities;
using MVC_Task.Services;

namespace MVC_Task.Models.Repos.StudentRepo
{
    public class StudentRepo: IStudent
    {
        MVC_TaskContext Context;
        public StudentRepo(MVC_TaskContext context)
        {
            Context = context;
        }

        public void AddStudent(Student student)
        {
            Context.Students.Add(student);
        }

        public List<Student> GetAllStudentsForPage(int toSkip, int pageSize)
        {
            return Context.Students.Skip(toSkip).Take(pageSize).ToList();
        }        
        public List<Student> GetAllStudents()
        {
            return Context.Students.ToList();
        }

        public Student GetStudentById(int Id)
        {
            Student Student= Context.Students.FirstOrDefault(student=>student.Id==Id);

            return Student;

        }
        public void UpdateStudent( Student Student)
        {
            Context.Update(Student);
        }
        public void DeleteStudent(int Id)
        {
            var Student= GetStudentById(Id);

            Context.Remove(Student);    
        }
        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public List<Student> GetStudentsByName(string Name)
        {
            var Students= Context.Students.Where(student=>student.Name.Contains(Name)).ToList();

            return Students;
        }

        public List<Student> GetStudentsByGender(string Gender)
        {
            List<Student> Students = null;
            if (Gender == "All")
            {
                Students = Context.Students.ToList();
            }
            else
            {
                Students = Context.Students.Where(student => student.Gender.ToUpper() == Gender.ToUpper()).ToList();

            }

            return Students;
        }

        public List<Student> GetStudentsByCity(string City)
        {
            var Students = Context.Students.Where(student => student.City.Contains(City)).ToList();

            return Students;
        }

        public List<Student> GetStudentsByDate(DateTime? From, DateTime? To)
        {
            List<Student> Students = null;
            if (To == null)
            {
                 Students = Context.Students.Where(student => student.DateOfBirth >= From).ToList();

            }else if(From == null)
            {
                Students = Context.Students.Where(student => student.DateOfBirth <= To).ToList();


            }else if (From!=null && To != null)
            {
                Students = Context.Students.Where(student => student.DateOfBirth <= To && student.DateOfBirth >= From).ToList();

            }
            else
            {
                return null;
            }

            return Students;
        }
        public List<Student> SearchStudent(StudentSearch StudentSearch)
        {
            List<Student> Students = GetAllStudents();

            if (StudentSearch.Name != null)
            {
                Students = Students.Where(student => student.Name.Contains(StudentSearch.Name)).ToList();

            }

            else if (StudentSearch.City != null)
            {
                Students = Students.Where(student => student.City.Contains(StudentSearch.City)).ToList();
            }
            else if (StudentSearch.From != null)
            {

                Students = Students.Where(student => student.DateOfBirth >= StudentSearch.From).ToList();

            }
            else if (StudentSearch.To != null)
            {
                Students = Students.Where(student => student.DateOfBirth <= StudentSearch.To).ToList();
            }
            else if (StudentSearch.Gender != null)
            {
                if (StudentSearch.Gender != "All")
                {
                    Students = Students.Where(student => student.Gender.ToUpper() == StudentSearch.Gender.ToUpper()).ToList();
                }
            }

            return Students;


        }
    }
}
