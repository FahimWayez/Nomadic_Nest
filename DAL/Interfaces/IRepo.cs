using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRepo<CLASS, ID, RET>
    {
        void Create(CLASS obj);
        CLASS Get(ID id);
        List<CLASS> Get();
        RET Update(int id, CLASS obj);
        RET Delete(ID id);

        List<CLASS> Search(string term);

        List<CLASS> Sort(string sortBy, bool ascending);

        List<CLASS> Filter(string filterBy, string value);

        List<CLASS> GetPaged(int pageNumber, int pageSize);
    }

}
