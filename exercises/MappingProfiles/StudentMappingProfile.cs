using AutoMapper;
using exercises.Models.Students;
using exercises.Request.Students;
using exercises.Respounses.Students;

namespace exercises.MappingProfiles
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>();

            #region Respounses Mapping
            CreateMap<Student, GetAllStudentsResponsetDTO>();
            CreateMap<Student, GetStudentByIdResponseDTO>();
            CreateMap<Student, DeleteStudentResponseDTO>();
            CreateMap<Student, CreateStudentResponseDTO>();
            CreateMap<Student, UpdateStudentResponseDTO>();
            #endregion

            #region Requests Mapping
            CreateMap<Student, DeleteStudentRequestDTO>();
            CreateMap<Student, GetStudentByIdRequestDTO>();
            CreateMap<Student, CreateStudentRequestDTO>();
            CreateMap<Student, UpdateStudentRequestDTO>();

            CreateMap<CreateStudentRequestDTO, Student>();
            #endregion


        }
    }
}
