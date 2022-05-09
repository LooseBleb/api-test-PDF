using Trabs_BLL.Models;

namespace Trabs_DAO.Select
{
    public class WorksSpefic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Matter Matter { get; set; }
        public DateTime Created { get; set; }
    }
}