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

export const AdminFiguritas: React.FC = () => {
  //HOOKS
  const [allFigurita, setAllFigurita] = useState<IAlbumImagenesData[]>([]);
  const [allListAlbumes, setAllListAlbum] = useState<IAlbumData[]>([]);
  const { paginate, setPaginate } = usePaginate()
  const storeGlobal = useGlobalContext();
  const [statusAction, setStatusction] = useState({
    action: "", idFigurita: 0
  })
  const { formulario, handleChange, resetForm, setFormulario } = useFormCustom<IDataFiguritaForm>({
    NumeroImagen: "", CodigoImagenOriginal: "", CantidadImpresa: "",
    Imagen: "", Titulo: "", AlbumId: ""
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

  const getAllColecction = async () => {
    const data = await AdminFiguritaService.GetAllAdminFiguritas(1);

    setAllFigurita(data.Result);
  }

  const openAddFigurita = () => {
    setFormulario({
        NumeroImagen: "", CodigoImagenOriginal: "", CantidadImpresa: "",
        Imagen: "", Titulo: "", AlbumId: ""
    })
    setStatusction({
      action: "add",
      idFigurita: 0
    })
    storeGlobal.SetShowModalContainer(true)
  }

  const Add = async (event: any) => {

    /*try {
      event.preventDefault();
      storeGlobal.SetShowLoader(true)


      console.log("Crear", formulario)
      const { Result, MessageError } = await AdminFiguritaService.AddAdminFigurita(formulario);

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
    }*/

  };


  const openEditFigurita = (Figurita: IAlbumImagenesData) => {
    setFormulario({
        numeroImagen: Figurita.numeroImagen,
        codigoImagenOriginal: Figurita.codigoImagenOriginal,
        cantidadImpresa: Figurita.cantidadImpresa,
        imagen: Figurita.imagen,
        titulo: Figurita.titulo,
        albumId: Figurita.albumId,
     
    })
    setStatusction({
      action: "update",
      idFigurita: Figurita.id
    })
    storeGlobal.SetShowModalContainer(true)
  }

  const Put = async (event: any) => {

    /*try {
      event.preventDefault();
      storeGlobal.SetShowLoader(true)


      console.log("Crear", formulario)
      const { Result, MessageError } = await AdminFiguritaService.updateAdminFigurita(statusAction.idFigurita, formulario);

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
    }*/
  };

  const Delete = async (idFigurita: number) => {
    /*try {

      storeGlobal.SetShowLoader(true)

      const { Result, MessageError } = await AdminFiguritaService.DeleteAdminFigurita(idFigurita);

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
    }*/
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

        <div className={`${AdminFiguritaCSS.lalala}`} >
          <h1 className={`${AdminFiguritaCSS.titulo}`}>Administracion de G7 Album </h1>
          <p className={`${AdminFiguritaCSS.texto}`}>Bienvenidos al area administrativa "LA SCALONETA"</p>

          <table className={`${AdminFiguritaCSS.table}`} border={1}>
            <tr>
              <th>Nombre Figuritas</th>
              <th>Selcciona la opcion deseada</th>
              <th>
                <button className={`${AdminFiguritaCSS.buttonAdmin}`} onClick={openAddFigurita}>
                  Agregar Album
                </button>
              </th>
            </tr>

            {allFigurita?.map((Albumes: IAlbumImagenesData, indexAlbum: number) => (
              <tr key={indexAlbum}>
                <th>{Albumes.titulo}</th>
                <th>
                  <button className={`${AdminFiguritaCSS.buttonAdmin}`} onClick={() => openEditFigurita(Albumes)}>Modificar</button>
                  <button
                    className={`${AdminFiguritaCSS.buttonAdmin}`}
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
          {allFigurita.length === 0 && <Loader />}


        </div>


        <ModalContainer personCss={`${AdminFiguritaCSS.containerModalAlbum}`}>

          <p onClick={() => {
            storeGlobal.SetShowModalContainer(false)
          }} className={AdminFiguritaCSS.containerModalAlbum__closeBtn}>
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
                    {allListFigurita.map((coleccion, index) => (
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
