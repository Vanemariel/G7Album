using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G7Album.Shared.DTO_Back
{
    public class Pagination<TypeData>
    {
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
        public TypeData ListItems { get; set; }
    }
}
