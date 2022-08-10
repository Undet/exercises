using exercises.Data.Models;

namespace exercises.Data.RoleD
{
    public interface IRoleDB
    {
        Task<IEnumerable<Role>> GetAll();
        Task<string> Add(string roleName, int studentid);
        Task<Role> DeleteById(int id);
    }
}
