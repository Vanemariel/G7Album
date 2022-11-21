import { useEffect, useState } from "react";
import { IAlbumData } from "../../Interface/DTO Back/Album/IAlbumData";
import { useGlobalContext } from "../../Context/useGlobalContext";
import { Loader } from "../../Components/Loader/Loader";
import AdminAlbumService from "./AdminAlbum.Service";
import "./style.css";
import { ConfigCarrouselModels } from "../../Models/ConfigCarrousel.models";

export const AdminAlbum: React.FC = () => {
  //HOOKS
  const storeGlobal = useGlobalContext();
  const [allAlbunes, setAllAlbumes] = useState<IAlbumData[]>([]);

  //METODOS
  const getAll = async () => {
    // eslint-disable-next-line @typescript-eslint/no-unused-expressions

    const data = await AdminAlbumService.GetAllAdminAlbumes();
    setAllAlbumes(data.Result.listItems);
  };

  const Put = async (idAlbum: number, titulo: string) => {
    try {
      const { Result, MessageError } =
        await AdminAlbumService.updateAdminAlbumes(idAlbum,titulo);

      if (MessageError !== undefined) {
        throw new Error(MessageError);
      }
    } catch (error: any) {
      return `Uups... ha occurrido un ${error}. \n \n Intentelo nuevamente`;
    }
  };

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
                  <button className="buttonAdmin">Eliminar</button>
                </th>
              </tr>
            ))}
          </table>
        </div>

        {allAlbunes.length === 0 && <Loader />}
      </div>
    </>
  );
};
