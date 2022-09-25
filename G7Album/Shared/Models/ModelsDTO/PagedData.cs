using System;
using System.Collections.Generic;

namespace G7Album.Shared.Models.ModelsDTO
{
    public class PagedData<TypeData>:List<TypeData> 
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        //public string PreviousPage { get; private set; }
        public string NextPage { get; private set; }
        public bool HasPrevious => (CurrentPage > 1);
        public bool HasNext => (CurrentPage < TotalPages);
        public TypeData Items { get; private set; }
        public PagedData(TypeData items,int count, int pageNumber, int pageSize, string entidades)
        {
            Items = items;
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)PageSize);
            //AddRange(items);
            //NextPage = (HasNext && count > pageSize) ? $"https://localhost:7086/api/{entity}?Page={pageNumber + 1}" : string.Empty;
            //PreviousPage = (HasPrevious && count > pageSize) ? $"https://localhost:7086/api/{entity}?Page={pageNumber - 1}" : string.Empty;
        }
        
        /*public static PagedData<TypeData>Create(IQueryable<TypeData> source, int pagenumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) pageSize).Take(pageSize).Tolist();
            return PagedData<TypeData>(items, count, pageNumber, pageSize);
        }*/
    }

}
