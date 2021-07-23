using System.Collections.Generic;
using Webtonic.Models.Entities;

namespace Webtonic.Models.Services.Interface
{
    public interface IStudentResultsRepository : IRepositoryBase<StudentResults>
    {
        List<StudentResults> GetStundentsResults();
    }
}