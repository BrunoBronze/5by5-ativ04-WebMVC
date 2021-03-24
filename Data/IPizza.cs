using System.Collections.Generic;
using Model;

namespace Data
{
    public interface IPizza
    {
        bool Insert(Pizza pizza);
        List<Pizza> Select();
        bool Remover(int id);
    }
}
