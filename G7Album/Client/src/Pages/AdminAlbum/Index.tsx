import { useEffect, useState } from "react";
import { IAlbumData } from "../../Interface/DTO Back/Album/IAlbumData";
import { IColeccionData } from "../../Interface/DTO Back/ColeccionAlbum/IColeccionAlbumData";
import { useGlobalContext } from "../../Context/useGlobalContext";
import { Loader } from "../../Components/Loader/Loader";
import AdminAlbumService from "./AdminAlbum.Service";
import { ConfigCarrouselModels } from "../../Models/ConfigCarrousel.models";

export const Album: React.FC = () => {

    const storeGlobal = useGlobalContext();
    const [allColecciones, setAllColecciones] = useState<IColeccionData[]>([])


    const getAll = async () => {
        // eslint-disable-next-line @typescript-eslint/no-unused-expressions

        const data = await AdminAlbumService.GetAllAdminAlbumes()

        let arrAlbum: ConfigCarrouselModels[] = []

        data.Result?.map((coleccion: any, index: number) => {
            arrAlbum.push({
                individualItem: `#album-item${index}`,
                carouselWidth: 1000, // in p
                carouselId: `#album-rotator${index}`,
                carouselHolderId: `#album-rotator-holder${index}`,
            })
        })
    }   

  return (
    <>
      <div>
        <table border={1}>
          <tr>
            <th>Nombre Album</th>
            <th>Selcciona la opcion deseada</th>
          </tr>
        </table>

        {allColecciones.length === 0 && <Loader />}

        {allColecciones?.map(
          (Coleccion: IColeccionData, indexAlbum: number) => (
            <div
              id={`album-rotator${indexAlbum}`}
              key={indexAlbum}
              className="albumRotatorContainer"
            >
              <h1 className="title">{Coleccion.tituloColeccion}</h1>

              <section
                id={`album-rotator-holder${indexAlbum}`}
                className="albumRotatorHolder"
              >
                {Coleccion?.listadoAlbum.map(
                  (album: IAlbumData, indexEsport: number) => (
                    <article
                      id={`album-item${indexAlbum}`}
                      className={`albumItem`}
                      key={indexEsport}
                      style={{ cursor: "pointer" }}
                    ></article>
                  )
                )}
              </section>
            </div>
          )
        )}
      </div>
    </>
  );
};
