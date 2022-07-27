using AutoMapper;
using exercises.Model;
using exercises.Models;
using exercises.Models.Request.Course;
using exercises.Models.Responses.Course;

namespace exercises.MappingProfiles
{
    public class CoursesMappingProfile : Profile
    {
        public CoursesMappingProfile()
        {
            CreateMap<Course, CourseDTO>();
            CreateMap<CourseDTO, Course>();

            #region  Respounses Mapping
            CreateMap<Course, CreateCourseResDTO>();
            CreateMap<Course, DeleteCourseResDTO>();
            CreateMap<Course, GetAllCoursesResDTO>();
            #endregion

            #region Requests Mapping
            CreateMap<Course, CreateCourseRequestDTO>();
            CreateMap<Course, DeleteCourseRequestDTO>();

            CreateMap<CreateCourseRequestDTO, Course>();
            #endregion
        }
    }
}
