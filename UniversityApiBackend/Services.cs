using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend
{
    public class Services
    {
        private readonly UniversityDBContext _context;

        public Services(UniversityDBContext context)
        {
            _context = context;
        }

        public User searchUserByEmail(string email) 
        {
            return _context.Users.FirstOrDefault(x => x.Email.Equals(email));
        }

        public List<Student> olderStudents() 
        {
            var olderStudents = from student in _context.Students where student.Dob < new DateTime(2004, 01, 01) select student;
                            
            return olderStudents.ToList();
        }

        public List<Student> studentWithCourses()
        {
            var students = from student in _context.Students where student.Courses.Count > 0 select student;

            return students.ToList();
        }

        public List<Course> cursesWithStudentsByLevel(Level level)
        {
            var courses = _context.Courses.Include(s=>s.Students).Where(s => s.Level == level).ToList();

            return courses;

        }

        public List<Course> cursesByLevelAndCategory(Level level, string nameCategory)
        {
            var courses = _context.Courses.Include(c => c.Categories).ThenInclude(n => n.Name == nameCategory).Where(l => l.Level == level).ToList();
            return courses;
        }

        public List<Course> cursesWithoutStudents()
        {
            var courses = _context.Courses.Include(s => s.Students == null).ToList();
            return courses;
        }
    }
}
