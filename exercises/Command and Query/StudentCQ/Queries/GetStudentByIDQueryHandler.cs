using exercises.Data;
using MediatR;

namespace exercises.Command_and_Query.Students.Queries
{
    public class GetStudentByIDQueryHandler : IRequestHandler<GetStudentByIDQuery, Student>
    {
        private readonly IStudentDB _studentDB;
        GetStudentByIDQueryHandler(IStudentDB studentDB)
        {
            _studentDB = studentDB;
        }
        public Task<Student> Handle(GetStudentByIDQuery request, CancellationToken cancellationToken)
        {
            return _studentDB.GetById(request.Id);
        }
    }
}
