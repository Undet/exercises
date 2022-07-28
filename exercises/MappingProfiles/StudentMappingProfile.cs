using AutoMapper;
using exercises.Data.Models;
using exercises.Models;
using exercises.Request.Students;
using exercises.Respounses.Students;

namespace exercises.MappingProfiles
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            #region DTO Mapping
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>();

            CreateMap<EntryPass, EntryPassDTO>();
            CreateMap<EntryPassDTO, EntryPass>();



            CreateMap<University, UniversityDTO>();
            CreateMap<UniversityDTO, University>();
            #endregion

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

            CreateMap<UpdateStudentRequestDTO, Student>();
            CreateMap<CreateStudentRequestDTO, Student>();


            #endregion
        }
    }
}
