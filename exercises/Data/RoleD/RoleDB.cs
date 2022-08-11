using exercises.Data.Models;

namespace exercises.Data.RoleD
{
    public class RoleDB : IRoleDB
    {
        private readonly AppDBContext _DBContext;

        public RoleDB(AppDBContext appDBContext)
        {
            _DBContext = appDBContext;
        }

        public Task<string> Add(string roleName, int studentid)
        {
            var student = _DBContext.Students.FirstOrDefault(x => x.StudentId == studentid);
            if (roleName == null && student == null)
            {
                throw new ArgumentNullException("Entity must not be null");
            }

            var role = new Role { RoleName = roleName, Student = student };
            _DBContext.Roles.Add(role);
            _DBContext.SaveChanges();
            return Task.FromResult(roleName);
        }

        public Task<Role> DeleteById(int id)
        {
            Role result;
            try
            {
                result = _DBContext.Roles.FirstOrDefault(x => x.RoleId == id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            if (result == null)
            {
                throw new ArgumentNullException("Entity must not be null");
            }
            try
            {
                _DBContext.Remove(result);
                _DBContext.SaveChanges();
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Task.FromResult(result);
        }

        public Task<IEnumerable<Role>> GetAll()
        {
            try
            {
                return Task.FromResult(_DBContext.Roles.AsEnumerable());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
