using exercises.Data.Models;
using exercises.Models;

namespace exercises.Data.CourseData
{
    public interface ICourseDB
    {
        Task<IEnumerable<Course>> GetAll();
        Task<Course> Add(Course course);
        Task<Course> DeleteById(int id);
    }
}
