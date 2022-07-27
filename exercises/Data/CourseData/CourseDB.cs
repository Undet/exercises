using exercises.Model;
using exercises.Models;

namespace exercises.Data.CourseData
{
    public class CourseDB : ICourseDB
    {
        private readonly AppDBContext _DBContext;

        public CourseDB(AppDBContext appDBContext)
        {
            _DBContext = appDBContext;
        }

        public Task<Course> Add(Course course)
        {
            _DBContext.Course.Add(course);
            _DBContext.SaveChanges();
            return Task.FromResult(course);
        }

        public Task<Course> DeleteById(int id)
        {
            var result = _DBContext.Course.FirstOrDefault(i=> i.CourseId == id);
            _DBContext.Remove(result);
            return Task.FromResult(result);
        }

        public Task<IEnumerable<Course>> GetAll()
        {
            return Task.FromResult(_DBContext.Course.AsEnumerable());
        }
    }
}
