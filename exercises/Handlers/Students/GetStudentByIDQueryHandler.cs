using exercises.Data;
using exercises.Queries.Students;
using MediatR;

namespace exercises.Handlers.Students
{
    public class GetStudentByIDQueryHandler : IRequestHandler<GetStudentByIDQuery, Student>
    {
        private readonly IStudentDB _studentDB;
        public GetStudentByIDQueryHandler(IStudentDB studentDB)
        {
            _studentDB = studentDB;
        }
        public Task<Student> Handle(GetStudentByIDQuery request, CancellationToken cancellationToken)
        {
            return _studentDB.GetById(request.StudentId);
        }
    }
}
