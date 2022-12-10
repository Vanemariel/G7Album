import { useEffect, useState } from "react";
import { useGlobalContext } from "../../Context/useGlobalContext";
import { Loader } from "../../Components/Loader/Loader";
import AdminCollectionService from "./AdminCollection.Service";
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
    action: "", idColeccion: 0
  })
  const { formulario, handleChange, resetForm, setFormulario } = useFormCustom<IDataColeccionForm>({
    Titulo: ""
  });



  //METODOS
  const getAll = async (page: number = 1) => {
    // eslint-disable-next-line @typescript-eslint/no-unused-expressions

    const data = await AdminCollectionService.GetAllAdminCollection(page);

    setPaginate({
      currentPage: data.Result.currentPage - 1,
      pagesTotal: data.Result.pages
    })

    setAllAlbumes(data.Result.listItems);
  };

  const openAddColeccion = () => {
    setFormulario({ Titulo: "" })
    setStatusction({
      action: "add",
      idColeccion: 0
    })
    storeGlobal.SetShowModalContainer(true)
  }


  const Add = async (event: any) => {

    try {
      event.preventDefault();
      storeGlobal.SetShowLoader(true)

      const { Result, MessageError } = await AdminCollectionService.AddAdminColeccion(formulario);

      if (MessageError !== undefined) {
        throw new Error(MessageError);
      }

      storeGlobal.SetShowLoader(false);
      storeGlobal.SetMessageModalStatus(Result);
      storeGlobal.SetShowModalStatus(true);

      await getAll();
    } catch (error: any) {

      storeGlobal.SetShowLoader(false)
      storeGlobal.SetMessageModalStatus(`Uups... ha occurrido un ${error}. \n \n Intentelo nuevamente`)
      storeGlobal.SetShowModalStatus(true)

    } finally {
      resetForm()
      setTimeout(() => {
        storeGlobal.SetShowModalStatus(false)
      }, 5000);
      storeGlobal.SetShowModalContainer(false)
    }
  };


  const openUpdateColeccion = (ColeccionAlbumes: IColeccionData) => {
    setFormulario({ Titulo: ColeccionAlbumes.tituloColeccion })
    setStatusction({
      action: "update",
      idColeccion: ColeccionAlbumes.id
    })
    storeGlobal.SetShowModalContainer(true)
  }

  const Put = async (event: any) => {

    try {
      event.preventDefault();
      storeGlobal.SetShowLoader(true)

      const { Result, MessageError } = await AdminCollectionService.updateAdminCollection(
        statusAction.idColeccion, formulario.Titulo
      );

      if (MessageError !== undefined) {
        throw new Error(MessageError);
      }

      storeGlobal.SetShowLoader(false);
      storeGlobal.SetMessageModalStatus(Result);
      storeGlobal.SetShowModalStatus(true);

      await getAll();
    } catch (error: any) {

      storeGlobal.SetShowLoader(false)
      storeGlobal.SetMessageModalStatus(`Uups... ha occurrido un ${error}. \n \n Intentelo nuevamente`)
      storeGlobal.SetShowModalStatus(true)

    } finally {
      resetForm()
      setTimeout(() => {
        storeGlobal.SetShowModalStatus(false)
      }, 5000);
      storeGlobal.SetShowModalContainer(false)
    }
  };

  const Delete = async (id: number) => {
    try {
      storeGlobal.SetShowLoader(true)

      const { Result, MessageError } = await AdminCollectionService.DeleteAdminCollection(id);

      if (MessageError !== undefined) {
        throw new Error(MessageError);
      }

      storeGlobal.SetShowLoader(false);
      storeGlobal.SetMessageModalStatus(Result);
      storeGlobal.SetShowModalStatus(true);

      await getAll();
    } catch (error: any) {

      storeGlobal.SetShowLoader(false)
      storeGlobal.SetMessageModalStatus(`Uups... ha occurrido un ${error}. \n \n Intentelo nuevamente`)
      storeGlobal.SetShowModalStatus(true)

    } finally {
      setTimeout(() => {
        storeGlobal.SetShowModalStatus(false)
      }, 5000);
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
                <button className={`${AdminColeccionCSS.buttonAdmin}`} onClick={openAddColeccion}>
                  Agregar Coleccion
                </button>
              </th>
            </tr>

            {allAlbunesColecion?.map((ColeccionAlbumes: IColeccionData, indexColeccion: number) => (
              <tr>
                <th>{ColeccionAlbumes.tituloColeccion}</th>
                <th>
                  <button className={`${AdminColeccionCSS.buttonAdmin}`} onClick={() => openUpdateColeccion(ColeccionAlbumes)}>Modificar</button>
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

          <form onSubmit={statusAction.action === 'add' ? Add : Put} >

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

            <button type="submit">{statusAction.action === 'add' ? 'Crear' : 'Actualizar'}</button>
          </form>

        </ModalContainer>
      </div>
    </>
  );
};
