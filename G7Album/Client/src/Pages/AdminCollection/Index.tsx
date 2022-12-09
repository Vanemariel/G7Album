import { useEffect, useState } from "react";
import { useGlobalContext } from "../../Context/useGlobalContext";
import { Loader } from "../../Components/Loader/Loader";
import AdminAlbumService from "./AdminCollection.Service";
import AdminColeccionCSS from "./style.module.css";
import { IColeccionData } from "../../Interface/DTO Back/ColeccionAlbum/IColeccionAlbumData";
import { Paginate } from "../../Components/Paginate/Paginate";
import { usePaginate } from "../../Hooks/usePaginate";
import { useFormCustom } from "../../Hooks/useFormCustom";
import { ModalContainer } from "../../Components/ModalContainer";
import { Input } from "../../Components/Input/Input";
import { InputsMockColeccion } from "./Mocks/InputsColeccion";
import { IInputs } from "../../Components/Input/Inputs.interface";
import { IDataColeccionForm } from "../../Interface/DTO Front/Coleccion/IDataColeccionForm";

export const AdminCollection: React.FC = () => {
  //HOOKS
  const storeGlobal = useGlobalContext();
  const [allAlbunesColecion, setAllAlbumes] = useState<IColeccionData[]>([]);
  const { paginate, setPaginate } = usePaginate()


  const [statusAction, setStatusction] = useState({
    action: "", idAlbum: 0
  })
  const { formulario, handleChange, resetForm } = useFormCustom<IDataColeccionForm>({
    Titulo: ""
  });



  //METODOS
  const getAll = async (page: number = 1) => {
    // eslint-disable-next-line @typescript-eslint/no-unused-expressions

    const data = await AdminAlbumService.GetAllAdminCollection(page);

    setPaginate({
      currentPage: data.Result.currentPage - 1,
      pagesTotal: data.Result.pages
    })

    setAllAlbumes(data.Result.listItems);
  };

  const Put = async (event: any) => {

    event?.preventDefault()

    console.log("LALA", formulario)

    // try {
    //   const { Result, MessageError } =
    //     await AdminCollectionService.updateAdminCollection(id, TituloColeccion);

    //   if (MessageError !== undefined) {
    //     throw new Error(MessageError);
    //   }
    // } catch (error: any) {
    //   return `Uups... ha occurrido un ${error}. \n \n Intentelo nuevamente`;
    // }
  };

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
        <div className={`${AdminColeccionCSS.lalala}`} >
          <h1 className={`${AdminColeccionCSS.titulo}`}>Administracion de G7 Album </h1>
          <p className={`${AdminColeccionCSS.texto}`}>Bienvenidos al area administrativa</p>

          <table className={`${AdminColeccionCSS.table}`} border={1}>

            <tr>
              <th>Titulo de Coleccion de Album</th>
              <th>Selcciona la opcion deseada</th>
              <th>
                <button className={`${AdminColeccionCSS.buttonAdmin}`} onClick={() => {
                  setStatusction({
                    action: "add",
                    idAlbum: 0
                  })
                  storeGlobal.SetShowModalContainer(true)
                }}>
                  Agregar Coleccion
                </button>
              </th>
            </tr>

            {allAlbunesColecion?.map((ColeccionAlbumes: IColeccionData, indexColeccion: number) => (
              <tr>
                <th>{ColeccionAlbumes.tituloColeccion}</th>
                <th>
                  <button className={`${AdminColeccionCSS.buttonAdmin}`} onClick={() => {
                    setStatusction({
                      action: "update",
                      idAlbum: ColeccionAlbumes.id
                    })
                    storeGlobal.SetShowModalContainer(true)
                  }}>Modificar</button>
                  <button
                    className={`${AdminColeccionCSS.buttonAdmin}`}
                    onClick={() => Delete(ColeccionAlbumes.id)}
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

        {allAlbunesColecion.length === 0 && <Loader />}


        <ModalContainer personCss={`${AdminColeccionCSS.containerModalColeccion}`}>

          <p onClick={() => {
            storeGlobal.SetShowModalContainer(false)
          }} className={AdminColeccionCSS.containerModalColeccion__closeBtn}>
            <i className="fas fa-times"></i>
          </p>

          <h1>{statusAction.action === 'add' ? 'Crear' : 'Actualizar'}</h1>

          <form onSubmit={statusAction.action === 'add' ? Put : Put} >

            {InputsMockColeccion.map((inputProps: IInputs, index: number) => (
              <Input
                key={index}
                inputProps={inputProps}
                value={formulario[inputProps.name]}
                handleChange={handleChange}
                errorMessage={inputProps.errorMessage}
                pattern={inputProps.expReg}
              />
            ))}

            <button type="submit">Crear</button>
          </form>

        </ModalContainer>
      </div>
    </>
  );
};
