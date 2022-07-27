using exercises.Models;

namespace exercises.Data.CourseData
{
    public interface ICourseDB
    {
        Task<IEnumerable<exercises.Model.Course>> GetAll();
        Task<exercises.Model.Course> Add(exercises.Model.Course course);
        Task<exercises.Model.Course> DeleteById(int id);
    }
}
