import { useEffect, useState } from "react";
import { IAlbumData } from "../../Interface/DTO Back/Album/IAlbumData";
import { useGlobalContext } from "../../Context/useGlobalContext";
import { Loader } from "../../Components/Loader/Loader";
import AdminAlbumService from "./AdminAlbum.Service";
import "./style.css";
import { ConfigCarrouselModels } from "../../Models/ConfigCarrousel.models";
import { usePaginate } from "../../Hooks/usePaginate";
import { Paginate } from "../../Components/Paginate/Paginate";

export const AdminAlbum: React.FC = () => {
  //HOOKS
  const [allAlbunes, setAllAlbumes] = useState<IAlbumData[]>([]);
  const { paginate, setPaginate } = usePaginate()


  //METODOS
  const getAll = async (page: number = 1) => {
    // eslint-disable-next-line @typescript-eslint/no-unused-expressions

    const data = await AdminAlbumService.GetAllAdminAlbumes(page);
    console.log("🚀 ~ file: Index.tsx:18 ~ getAll ~ data", data)

    setPaginate({
      currentPage: data.Result.currentPage - 1,
      pagesTotal: data.Result.pages
    })

    setAllAlbumes(data.Result.listItems);
  };

  const Put = async (idAlbum: number, titulo: string) => {
    try {
      const { Result, MessageError } =
        await AdminAlbumService.updateAdminAlbumes(idAlbum, titulo);

      if (MessageError !== undefined) {
        throw new Error(MessageError);
      }
    } catch (error: any) {
      return `Uups... ha occurrido un ${error}. \n \n Intentelo nuevamente`;
    }
  };

  const Delete = async (idAlbum: number) => {
    try {
      const { Result, MessageError } =
        await AdminAlbumService.DeleteAdminAlbumes(idAlbum);

      if (MessageError !== undefined) {
        throw new Error(MessageError);
      }
      alert("Se elimino el album");
      getAll();
    } catch (error: any) {
      return `Uups... ha occurrido un ${error}. \n \n Intentelo nuevamente`;
    }
  };

  const changePage = ({ selected }: any) => {
    window.scrollTo(0, 0);
    getAll(selected + 1)
  }

  useEffect(() => {
    getAll();
  }, []);

  return (
    <>
      <div>
        <div className="lalala">
          <h1 id="titulo">Administracion de G7 Album </h1>
          <p className="texto">Bienvenidos al area administrativa</p>

          <table className="table" border={1}>
            <tr>
              <th>Nombre Album</th>
              <th>Selcciona la opcion deseada</th>
            </tr>

            {allAlbunes?.map((Albumes: IAlbumData, indexAlbum: number) => (
              <tr>
                <th>{Albumes.titulo}</th>
                <th>
                  <button className="buttonAdmin">Modificar</button>
                  <button
                    className="buttonAdmin"
                    onClick={() => Delete(Albumes.id)}
                  >
                    Eliminar
                  </button>
                </th>
              </tr>
            ))}
          </table>

          <div>
            <Paginate
              ChangePage={changePage}
              PageCount={paginate.pagesTotal}
              LocatedPageNumber={paginate.currentPage}
            />
          </div>
        </div>

        {allAlbunes.length === 0 && <Loader />}


      </div>
    </>
  );
};
