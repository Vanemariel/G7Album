using G7Album.BaseDatos.Data.Comun;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace G7Album.Shared.Repositorio
{
    public class QueryProperty<TypeData> where TypeData : BaseEntity
    {
        public QueryProperty()
        {

        }

        public QueryProperty(int page, int pageCount)
        {
            page = page > 0 ? page : 1;
            pageCount = pageCount > 0 ? pageCount : 1;

            Skip = (page - 1) * pageCount;
            Take = pageCount;
        }

        public int Skip { get; set; }
        public int Take { get; set; }
        public Expression<Func<TypeData, bool>> Where { get; set; }
        public List<Expression<Func<TypeData, object>>> Includes { get; set; } = new List<Expression<Func<TypeData, object>>>();
        public Expression<Func<TypeData, object>> OrderBy { get; set; }
        public bool Descending { get; set; }
    }
}
