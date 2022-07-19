using exercises.Data;
using MediatR;

namespace exercises.Command_and_Query.Students.Queries
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IEnumerable<Student>>
    {
        private readonly IStudentDB _studentDB;
        GetStudentsQueryHandler(IStudentDB studentDB)
        {
            _studentDB = studentDB;
        }
        public Task<IEnumerable<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            return _studentDB.GetAll();
        }
    }
}
