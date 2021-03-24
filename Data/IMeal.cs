using System.Collections.Generic;
using Model;

namespace Data
{
    public interface IMeal
    {
        bool Insert(Meal meal);
        List<Meal> Select();
        bool Remover(int id);
        bool Update(Meal meal);
        Meal SelectById(int id);
        bool Delete(int id);
        decimal FullValue(int Id);

    }
}
