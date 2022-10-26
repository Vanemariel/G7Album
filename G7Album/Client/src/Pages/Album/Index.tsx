/* eslint-disable jsx-a11y/anchor-is-valid */
import './style.css'
import 'bootstrap/dist/css/bootstrap.min.css';

import { useEffect, useState } from 'react';
import { carouselTarjets } from '../../Utils/carouselTarjets';
import AlbumService from './Services/Album.service';
import { IColeccionData } from "../../Interface/DTO Back/ColeccionAlbum/IColeccionAlbumData";
import { IAlbumData } from "../../Interface/DTO Back/Album/IAlbumData";
import { ConfigCarrouselModels } from "../../Models/ConfigCarrousel.models";
import { useGlobalContext } from "../../Context/useGlobalContext";
import { Paginate } from '../../Components/Paginate/Paginate';
import { usePaginate } from '../../Hooks/usePaginate';
import { Loader } from '../../Components/Loader/Loader';

export const Album: React.FC = () => {


    
    /// HOOKS
    const storeGlobal = useGlobalContext();
    const [allColecciones, setAllColecciones] = useState<IColeccionData[]>([])
    const {paginate, setPaginate} = usePaginate()



    /// METODOS
    const getAllColeccionAlbumes = async (page: number = 1) => {
        // eslint-disable-next-line @typescript-eslint/no-unused-expressions
        
        const data = await AlbumService.GetAllColeccionAlbumes(page)

        let arrAlbum: ConfigCarrouselModels[] = []
        
        data.Result?.listItems.map((coleccion: any, index: number) => {
            arrAlbum.push({
                individualItem: `#album-item${index}`,
                carouselWidth: 1000, // in p
                carouselId: `#album-rotator${index}`,    
                carouselHolderId: `#album-rotator-holder${index}`,
            })
        })
        
        setPaginate({
            currentPage: data.Result.currentPage -1,
            pagesTotal: data.Result.pages 
        })
        setAllColecciones(data.Result.listItems)
        carouselTarjets(arrAlbum) 
    }

    const buyAlbum = async (idAlbum: number) => {

        try {
                      
            storeGlobal.SetShowLoader(true)
                                        
            const {Result, MessageError } = await AlbumService.buyAlbum({
               IdUsuario: storeGlobal.GetMyUserData().Id, 
               IdAlbum: idAlbum
            })

            if (MessageError != undefined)
            {
              throw new Error(MessageError);
            }
                               
            storeGlobal.SetShowLoader(false)                                         
            storeGlobal.SetMessageModalStatus(Result)
                  
        } catch (error: any) {
            
            storeGlobal.SetShowLoader(false)
            storeGlobal.SetMessageModalStatus(`Uups... ha occurrido un ${error}. \n \n Intentelo nuevamente`)
            
        } finally {
            storeGlobal.SetShowModalStatus(true)
                      
            setTimeout(() => {
               storeGlobal.SetShowModalStatus(false)
            }, 5000);
      
        }
    }

    const changePage = ({selected}: any) => {
        window.scrollTo(0,0);
        getAllColeccionAlbumes(selected+1)
    }

    useEffect(()=> {
        getAllColeccionAlbumes()
    },[])

    return (

        <>

            <div className="containerPageAlbum">
                <div id="m">
                    <div className="container">
                        <div className="input-group mb-3">
                            <input type="text" className="form-control" placeholder="Escribe album o torneo deseado" aria-label="Recipient's username" aria-describedby="basic-addon2" />
                            <div className="input-group-append">
                                <button type="button" className="btn btn-primary">
                                    <i className="fas fa-search"></i>
                                </button>
                            </div>
                        </div>
                    </div>
                    <br />

                    {allColecciones.length === 0 && <Loader/>}

                    {
                        allColecciones?.map((Coleccion: IColeccionData, indexAlbum: number) => (

                            <div id={`album-rotator${indexAlbum}`} key={indexAlbum} className="albumRotatorContainer">
                            <h1 className='title'>{Coleccion.tituloColeccion}</h1>
                        
                                <section id={`album-rotator-holder${indexAlbum}`} className="albumRotatorHolder">
                                    {
                                        Coleccion?.listadoAlbum.map((album: IAlbumData, indexEsport: number)=>(
                                            <article id={`album-item${indexAlbum}`} style={{cursor: 'pointer'}}
                                                className={`albumItem`} key={indexEsport}
                                            >
                                                <div className={`albumItem__details`}>  

                                                    <h3>{album.titulo}</h3>
                                                    <img src={album.imagen} alt="" />
                                                    <button className="btnAlbumComprar" type='submit' onClick={() => buyAlbum(album.id)}>Comprar</button>
                                                </div>
                                            </article>
                                        ))
                                    }
                                </section>
                            </div> 
                        ))
                    }
                    <div>
                        <Paginate
                            ChangePage={changePage}
                            PageCount={paginate.pagesTotal}
                            LocatedPageNumber={paginate.currentPage}
                        />
                    </div>
                </div>

            </div>
        </>
    );
}