import { useEffect, useState } from "react";
import { useGlobalContext } from "../../Context/useGlobalContext";
import { Loader } from "../../Components/Loader/Loader";
import AdminFiguritaCSS from "./style.module.css";
import { usePaginate } from "../../Hooks/usePaginate";
import { Paginate } from "../../Components/Paginate/Paginate";
import { ModalContainer } from "../../Components/ModalContainer";
import { useFormCustom } from "../../Hooks/useFormCustom";
import { Input } from "../../Components/Input/Input";
import { IInputs } from "../../Components/Input/Inputs.interface";
import { IListColeccion } from "../../Interface/DTO Back/ColeccionAlbum/IListColeccion";
import { IAlbumImagenesData } from "../../Interface/DTO Back/AlbumImagenes/IAlbumImagenes";
import { IDataFiguritaForm } from "../../Interface/DTO Front/AlbumImagen/IDataFiguritaForm";
import AdminFiguritaService from "./AdminFigurita.Services";
import { IAlbumData } from "../../Interface/DTO Back/Album/IAlbumData";
import { IListAlbum } from "../../Interface/DTO Back/Album/IListAlbum";
import { InputsMockFiguritas } from "./Mocks/InputsFiguritas";

export const AdminFiguritas: React.FC = () => {
  //HOOKS
  const [allFigurita, setAllFigurita] = useState<IAlbumImagenesData[]>([]);
  const [allListAlbumes, setAllListAlbum] = useState<IListAlbum[]>([]);
  const { paginate, setPaginate } = usePaginate()
  const storeGlobal = useGlobalContext();
  const [statusAction, setStatusAction] = useState({
    action: "", idAlbumFigurita: 0
  })
  const { formulario, handleChange, resetForm, setFormulario } = useFormCustom<IDataFiguritaForm>({
    NumeroImagen: "", CodigoImagenOriginal: "", CantidadImpresa: "",
    Imagen: "", Titulo: "", AlbumId: 0
  });

  //METODOS
  const getAll = async (page: number = 1) => {
    // eslint-disable-next-line @typescript-eslint/no-unused-expressions

    const data = await AdminFiguritaService.GetAllAdminFiguritas(page);
    console.log("🚀 ~ file: Index.tsx:18 ~ getAll ~ data", data)

    setPaginate({
      currentPage: data.Result.currentPage - 1,
      pagesTotal: data.Result.pages
    })

    setAllFigurita(data.Result.listItems);
  };

  const getAllAlbumes = async () => {
    const data = await AdminFiguritaService.getAllAlbumes();

    setAllListAlbum(data.Result);
  }

  const openAddFigurita = () => {
    setFormulario({
      NumeroImagen: "", CodigoImagenOriginal: "", CantidadImpresa: "",
      Imagen: "", Titulo: "", AlbumId: 0
    })
    setStatusAction({
      action: "add",
      idAlbumFigurita: 0
    })
    storeGlobal.SetShowModalContainer(true)
  }

  const Add = async (event: any) => {

    try {
      event.preventDefault();
      storeGlobal.SetShowLoader(true)

      const data = {
        ...formulario,
        idAlbumFigurita: statusAction.idAlbumFigurita
      }


      console.log("Crear", formulario)
      const { Result, MessageError } = await AdminFiguritaService.AddAdminAlbumes(data);

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


  const openEditFigurita = (Figurita: IAlbumImagenesData) => {
    setFormulario({
      NumeroImagen: Figurita.numeroImagen,
      CodigoImagenOriginal: Figurita.codigoImagenOriginal,
      CantidadImpresa: Figurita.cantidadImpresa,
      Imagen: Figurita.imagen,
      Titulo: Figurita.titulo,
      AlbumId: Figurita.albumId
    })
    setStatusAction({
      action: "update",
      idAlbumFigurita: Figurita.id,
    })
    storeGlobal.SetShowModalContainer(true)
  }

  const Put = async (event: any) => {

    try {
      event.preventDefault();
      storeGlobal.SetShowLoader(true)

      const { Result, MessageError } = await AdminFiguritaService.updateAdminAlbumes(
        statusAction.idAlbumFigurita, 
        formulario
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

  const Delete = async (idAlbumFigurita: number) => {
    try {
      storeGlobal.SetShowLoader(true)

      const { Result, MessageError } = await AdminFiguritaService.DeleteAdminAlbumes(idAlbumFigurita);

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
    getAllAlbumes();
  }, []);

  return (
    <>
      <div>

        <div className={`${AdminFiguritaCSS.lalala}`} >
          <h1 className={`${AdminFiguritaCSS.titulo}`}>Administracion de G7 Album </h1>
          <p className={`${AdminFiguritaCSS.texto}`}>Bienvenidos al area administrativa "LA SCALONETA"</p>

          <table className={`${AdminFiguritaCSS.table}`} border={1}>
            <tr>
              <th>Nombre Figuritas</th>
              <th>Selcciona la opcion deseada</th>
              <th>
                <button className={`${AdminFiguritaCSS.buttonAdmin}`} onClick={openAddFigurita}>
                  Agregar Figuritas
                </button>
              </th>
            </tr>

            {allFigurita?.map((Figurita: IAlbumImagenesData, indexAlbum: number) => (
              <tr key={indexAlbum}>
                <th>{Figurita.titulo}</th>
                <th>
                  <button className={`${AdminFiguritaCSS.buttonAdmin}`} onClick={() => openEditFigurita(Figurita)}>Modificar</button>
                  <button
                    className={`${AdminFiguritaCSS.buttonAdmin}`}
                    onClick={() => Delete(Figurita.id)}
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
          {allFigurita.length === 0 && <Loader />}


        </div>


        <ModalContainer personCss={`${AdminFiguritaCSS.containerModalFiguritas}`}>

          <p onClick={() => {
            storeGlobal.SetShowModalContainer(false)
          }} className={AdminFiguritaCSS.containerModalFiguritas__closeBtn}>
            <i className="fas fa-times"></i>
          </p>

          <h1>{statusAction.action === 'add' ? 'Crear' : 'Actualizar'} Figurita</h1>

          <form onSubmit={statusAction.action === 'add' ? Add : Put} >

            {
              statusAction.action === 'add' && (

                <label>
                  Eliga el Album al que pertenece:
                  <select onChange={handleChange} name="AlbumId" value={formulario.AlbumId}>
                    <option value={0}> </option>
                    {allListAlbumes.map((coleccion, index) => (
                      <option value={coleccion.id} key={index}>{coleccion.nombreCompleto}</option>
                    ))}
                  </select>
                </label>
              )
            }

            {InputsMockFiguritas.map((inputProps: IInputs, index: number) => (
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
