using exercises.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace exercises.Data
{
    public class StudentDB : IStudentDB
    {
        private readonly AppDBContext _DBContext;
        private readonly UserManager<Student> _userManager;

        public StudentDB(AppDBContext appDBContext, UserManager<Student> userManager)
        {
            _DBContext = appDBContext;
            _userManager = userManager;
        }

        public Task<Student> Add(Student student)
        {            
            if (student == null)
            {
                throw new ArgumentNullException("Entity must not be null");
            }

            try
            {
                _DBContext.Students.Add(student);
                _DBContext.SaveChanges();
                return Task.FromResult(student);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<Student> DeleteById(int id)
        {
            Student result;
            try
            {
                result = _DBContext.Students.FirstOrDefault(x => x.StudentId == id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            if (result == null)
            {
                throw new ArgumentNullException("Entity must not be null");
            }
            try
            {
                _DBContext.Remove(result);
                _DBContext.SaveChanges();
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Task.FromResult(result);
        }

        public Task<IEnumerable<Student>> GetAll()
        {
            try
            {
                return Task.FromResult(_DBContext.Students.AsEnumerable());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<Student> GetById(int id)
        {
            var result = _DBContext.Students.FirstOrDefault((i) => i.StudentId == id);
            if (result == null)
            {
                throw new ArgumentException("Entity must not be null");
            }
            return Task.FromResult(result);
        }


        public Task<Student> Update(Student student)
        {

            if (student == null)
            {
                throw new ArgumentException("Entity must not be null");
            }

            try
            {
                _DBContext.Update(student);
                _DBContext.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            return Task.FromResult(student);
        }
    }
}