import { useEffect, useState } from "react";
import { useGlobalContext } from "../../Context/useGlobalContext";
import { Loader } from "../../Components/Loader/Loader";
import AdminAlbumService from "./AdminCollection.Service";
import "./style.css";
import { ConfigCarrouselModels } from "../../Models/ConfigCarrousel.models";
import { IColeccionData } from "../../Interface/DTO Back/ColeccionAlbum/IColeccionAlbumData";
import AdminCollectionService from "./AdminCollection.Service";

export const AdminCollection: React.FC = () => {
  //HOOKS
  const storeGlobal = useGlobalContext();
  const [allAlbunesColecion, setAllAlbumes] = useState<IColeccionData[]>([]);

  //METODOS
  const getAll = async () => {
    // eslint-disable-next-line @typescript-eslint/no-unused-expressions

    const data = await AdminAlbumService.GetAllAdminCollection();
    setAllAlbumes(data.Result.listItems);
  };

  /*const Put = async (id: number, TituloColeccion: string) => {
    try {
      const { Result, MessageError } =
        await AdminCollectionService.updateAdminCollection(id, TituloColeccion);

      if (MessageError !== undefined) {
        throw new Error(MessageError);
      }
    } catch (error: any) {
      return `Uups... ha occurrido un ${error}. \n \n Intentelo nuevamente`;
    }
  };*/

  const Delete = async (id: number) => {
    try {
      const { Result, MessageError } =
        await AdminAlbumService.DeleteAdminCollection(id);

      if (MessageError !== undefined) {
        throw new Error(MessageError);
      }
      alert("Se elimino esta coleccion");
      getAll();
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
              <th>Titulo de Coleccion de Album</th>
              <th>Selcciona la opcion deseada</th>
            </tr>

            {allAlbunesColecion?.map((ColeccionAlbumes: IColeccionData, indexColeccion: number) => (
              <tr>
                <th>{ColeccionAlbumes.tituloColeccion}</th>
                <th>
                  <button className="buttonAdmin">Modificar</button>
                  <button
                    className="buttonAdmin"
                    onClick={() => Delete(ColeccionAlbumes.id)}
                  >
                    Eliminar
                  </button>
                </th>
              </tr>
            ))}
          </table>
        </div>

        {allAlbunesColecion.length === 0 && <Loader />}
      </div>
    </>
  );
};
