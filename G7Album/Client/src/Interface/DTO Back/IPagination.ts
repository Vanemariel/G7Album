export interface IPagination<TypeData> {
    pages: number;
    currentPage: number;
    listItems: TypeData;
}