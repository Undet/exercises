using exercises.Data;
using exercises.Data.Models;
using exercises.Queries.Students;
using MediatR;

namespace exercises.Handlers.Students
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IEnumerable<Student>>
    {
        private readonly IStudentDB _studentDB;
        public GetStudentsQueryHandler(IStudentDB studentDB)
        {
            _studentDB = studentDB;
        }
        public Task<IEnumerable<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            return _studentDB.GetAll();
        }
    }
}
