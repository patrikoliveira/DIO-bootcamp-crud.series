using CrudSeries.Src.Domain.Entities;
using System.Collections.Generic;

namespace CrudSeries.Src.Domain.Repositories
{
    public interface ISerieRepository
    {
        List<Serie> Lista();
        Serie RetornaPorId(int id);
        void Insere(Serie entidade);
        void Excluir(int id);
        void Atualizar(int id, Serie entidade);
        int ProximoId();
    }
}