import ReactPaginate from 'react-paginate';
import PaginateCSS from "./Paginate.module.css"


interface Props {
    ChangePage: ({selected}: any) => void;
    PageCount: number;
    LocatedPageNumber: number | undefined;
}

export const Paginate : React.FC<Props> = (props) => {
    
    // https://www.npmjs.com/package/react-paginate

    const { ChangePage,  PageCount, LocatedPageNumber } = props;
    
    return (
        <ReactPaginate
            nextLabel={"Siguiente"}
            onPageChange={ChangePage}
            previousLabel={"Anterior"}
            
            pageCount={PageCount}
            forcePage={LocatedPageNumber}
            containerClassName={PaginateCSS.PaginationBttns}
            activeClassName={PaginateCSS.paginationActive}
            pageRangeDisplayed={3}            
            previousLinkClassName={"AnteriorBtn"}
            nextLinkClassName={"SiguienteBtn"}
            disabledClassName={"paginationDisabled"}
        />
    )
}