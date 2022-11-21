import { useEffect, useState } from "react";
import { IAlbumData } from "../../Interface/DTO Back/Album/IAlbumData";
import { useGlobalContext } from "../../Context/useGlobalContext";
import { Loader } from "../../Components/Loader/Loader";
import AdminAlbumService from "./AdminAlbum.Service";
import "./style.css"
import { ConfigCarrouselModels } from "../../Models/ConfigCarrousel.models";

export const AdminAlbum: React.FC = () => {
  const [allAlbunes, setAllAlbumes] = useState<IAlbumData[]>([]);

  const getAll = async () => {
    // eslint-disable-next-line @typescript-eslint/no-unused-expressions

    const data = await AdminAlbumService.GetAllAdminAlbumes();
    setAllAlbumes(data.Result.listItems);
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
                <th><button>MODIFICAR</button><button>ELIMINAR</button></th>

              </tr>
            ))}
          </table>
        </div>

        {allAlbunes.length === 0 && <Loader />}
      </div>
    </>
  );
};
