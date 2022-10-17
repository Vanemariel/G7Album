//import { useEffect } from "react";
//import { FormLogin } from "./Components/FormLogin/FormLogin";
import './style.css'
import { useEffect, useState } from 'react';
import { useGlobalContext } from '../../Context/useGlobalContext';
import AlbumUnitarioService from './Services/AlbumUnitario';
import { IAlbumUsuarioData } from '../../Interface/DTO Back/AlbumUsuario/IAlbumUsuario';
import { carouselTarjets } from '../../Utils/carouselTarjets';
import { ConfigCarrouselModels } from '../../Models/ConfigCarrousel.models';
import { usePaginate } from '../../Hooks/usePaginate';
import { Paginate } from '../../Components/Paginate/Paginate';



export const AlbumUsuario: React.FC = () => {

    /// HOOKS
    const {paginate, setPaginate} = usePaginate()
    const storeGlobal = useGlobalContext();
    const [allMyAlbumes, setAllMyAlbumes] = useState<IAlbumUsuarioData[]>([])


    /// METODOS
    const getAllMyAlbumes = async (page: number = 1) => {

        try {
                      
            storeGlobal.SetShowLoader(true)
                                        
            const {Result, MessageError } = await AlbumUnitarioService.GetAllMyAlbumes({
                page,
                idUsuario: storeGlobal.GetMyUserData().Id
            })

            if (MessageError !== undefined)
            {
              throw new Error(MessageError);
            }
                               
            let arrAlbum: ConfigCarrouselModels[] = []
        
            Result?.listItems.map((coleccion: any, index: number) => {
                arrAlbum.push({
                    individualItem: `#album-item${index}`,
                    carouselWidth: 1000, // in p
                    carouselId: `#album-rotator${index}`,    
                    carouselHolderId: `#album-rotator-holder${index}`,
                })
            })
            setPaginate({
                currentPage: Result.currentPage -1,
                pagesTotal: Result.pages 
            })
            setAllMyAlbumes(Result.listItems)
            // carouselTarjets(arrAlbum)

            storeGlobal.SetShowLoader(false)  
                  
        } catch (error: any) {
            storeGlobal.SetShowLoader(false)
            storeGlobal.SetShowModalStatus(true)
            storeGlobal.SetMessageModalStatus(`Uups... ha occurrido un ${error}. \n \n Intentelo nuevamente`)
        } finally {
            setTimeout(() => {
               storeGlobal.SetShowModalStatus(false)
            }, 5000);
      
        }

    }

    const changePage = ({selected}: any) => {
        window.scrollTo(0,0);
        getAllMyAlbumes(selected+1)
    }
   
    useEffect(()=> {
        getAllMyAlbumes()
    },[])
    
    return (


        <div className="containerPageAlbum">
            <div id="m">
              
                <h1>Mis Albumes </h1>
        
                {
                        <div id={`album-rotator0`} className="albumRotatorContainer">
                      
                            <section id={`album-rotator-holder0`} className="albumRotatorHolder">
                                {
                                    allMyAlbumes.map((myAlbum: IAlbumUsuarioData, indexEsport: number)=>(
                                        <article id={`album-item0`} style={{cursor: 'pointer'}}
                                            className={`albumItem`} key={indexEsport}
                                        >
                                            <div className={`albumItem__details`}>  

                                                <h3>{myAlbum.album.titulo}</h3>
            
                                            </div>
                                        </article>
                                    ))
                                }
                            </section>
                        </div>
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

    )
}


 
