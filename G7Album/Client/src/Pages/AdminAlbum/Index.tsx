import { useEffect, useState } from "react";
import { IAlbumData } from "../../Interface/DTO Back/Album/IAlbumData";
import { useGlobalContext } from "../../Context/useGlobalContext";
import { Loader } from "../../Components/Loader/Loader";
import AdminAlbumService from "./AdminAlbum.Service";
import AdminAlbumCSS from "./style.module.css";
import { usePaginate } from "../../Hooks/usePaginate";
import { Paginate } from "../../Components/Paginate/Paginate";
import { ModalContainer } from "../../Components/ModalContainer";
import { useFormCustom } from "../../Hooks/useFormCustom";
import { IDataAlbumForm } from "../../Interface/DTO Front/Album/IDataAlbumForm";
import { Input } from "../../Components/Input/Input";
import { InputsMockAlbum } from "./Mocks/InputsAlbum";
import { IInputs } from "../../Components/Input/Inputs.interface";
import { IListColeccion } from "../../Interface/DTO Back/ColeccionAlbum/IListColeccion";

export const AdminAlbum: React.FC = () => {
  //HOOKS
  const [allAlbunes, setAllAlbumes] = useState<IAlbumData[]>([]);
  const [allListColeccion, setAllListColeccion] = useState<IListColeccion[]>([]);
  const { paginate, setPaginate } = usePaginate()
  const storeGlobal = useGlobalContext();
  const [statusAction, setStatusction] = useState({
    action: "", idAlbum: 0
  })
  const { formulario, handleChange, resetForm, setFormulario } = useFormCustom<IDataAlbumForm>({
    ImgAlbum: "", Titulo: "", IdColeccion: "",
    CantidadImagen: "", CantidadImpreso: "", CodigoAlbum: "", Descripcion: ""
  });

  //METODOS
  const getAll = async (page: number = 1) => {
    // eslint-disable-next-line @typescript-eslint/no-unused-expressions

    const data = await AdminAlbumService.GetAllAdminAlbumes(page);

    setPaginate({
      currentPage: data.Result.currentPage - 1,
      pagesTotal: data.Result.pages
    })

    setAllAlbumes(data.Result.listItems);
  };

  const getAllColecction = async () => {
    const data = await AdminAlbumService.GetAllColecction();

    setAllListColeccion(data.Result);
  }

  const openAddAlbum = () => {
    setFormulario({
      ImgAlbum: "", Titulo: "", IdColeccion: "",
      CantidadImagen: "", CantidadImpreso: "", CodigoAlbum: "", Descripcion: ""
    })
    setStatusction({
      action: "add",
      idAlbum: 0
    })
    storeGlobal.SetShowModalContainer(true)
  }

  const Add = async (event: any) => {

    try {
      event.preventDefault();
      storeGlobal.SetShowLoader(true)


      console.log("Crear", formulario)
      const { Result, MessageError } = await AdminAlbumService.AddAdminAlbumes(formulario);

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
    }

  };


  const openEditAlbum = (Albumes: IAlbumData) => {
    setFormulario({
      ImgAlbum: Albumes.imagen,
      Titulo: Albumes.titulo,
      IdColeccion: Albumes.coleccionAlbumId,
      CantidadImagen: Albumes.cantidadImagen,
      CantidadImpreso: Albumes.cantidadImpreso,
      CodigoAlbum: Albumes.codigoAlbum,
      Descripcion: Albumes.descripcion
    })
    setStatusction({
      action: "update",
      idAlbum: Albumes.id
    })
    storeGlobal.SetShowModalContainer(true)
  }

  const Put = async (event: any) => {

    try {
      event.preventDefault();
      storeGlobal.SetShowLoader(true)


      console.log("Crear", formulario)
      const { Result, MessageError } = await AdminAlbumService.updateAdminAlbumes(statusAction.idAlbum, formulario);

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

  const Delete = async (idAlbum: number) => {
    try {

      storeGlobal.SetShowLoader(true)

      const { Result, MessageError } = await AdminAlbumService.DeleteAdminAlbumes(idAlbum);

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
    getAllColecction();
  }, []);

  return (
    <>
      <div>

        <div className={`${AdminAlbumCSS.lalala}`} >
          <h1 className={`${AdminAlbumCSS.titulo}`}>Administracion de G7 Album </h1>
          <p className={`${AdminAlbumCSS.texto}`}>Bienvenidos al area administrativa</p>

          <table className={`${AdminAlbumCSS.table}`} border={1}>
            <tr>
              <th>Nombre Album</th>
              <th>Selcciona la opcion deseada</th>
              <th>
                <button className={`${AdminAlbumCSS.buttonAdmin}`} onClick={openAddAlbum}>
                  Agregar Album
                </button>
              </th>
            </tr>

            {allAlbunes?.map((Albumes: IAlbumData, indexAlbum: number) => (
              <tr key={indexAlbum}>
                <th>{Albumes.titulo}</th>
                <th>
                  <button className={`${AdminAlbumCSS.buttonAdmin}`} onClick={() => openEditAlbum(Albumes)}>Modificar</button>
                  <button
                    className={`${AdminAlbumCSS.buttonAdmin}`}
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
          {allAlbunes.length === 0 && <Loader />}


        </div>


        <ModalContainer personCss={`${AdminAlbumCSS.containerModalAlbum}`}>

          <p onClick={() => {
            storeGlobal.SetShowModalContainer(false)
          }} className={AdminAlbumCSS.containerModalAlbum__closeBtn}>
            <i className="fas fa-times"></i>
          </p>

          <h1>{statusAction.action === 'add' ? 'Crear' : 'Actualizar'} Album</h1>

          <form onSubmit={statusAction.action === 'add' ? Add : Put} >

            {
              statusAction.action === 'add' && (

                <label>
                  Eliga coleccion de Album:
                  <select onChange={handleChange} name="IdColeccion" value={formulario.IdColeccion}>
                    <option value={0}> </option>
                    {allListColeccion.map((coleccion, index) => (
                      <option value={coleccion.id} key={index}>{coleccion.nombreCompleto}</option>
                    ))}
                  </select>
                </label>
              )
            }

            {InputsMockAlbum.map((inputProps: IInputs, index: number) => (
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
