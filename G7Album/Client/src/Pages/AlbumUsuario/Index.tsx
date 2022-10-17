//import { useEffect } from "react";
//import { FormLogin } from "./Components/FormLogin/FormLogin";
import './style.css'
import { useEffect, useState } from 'react';
import { useGlobalContext } from '../../Context/useGlobalContext';
import AlbumUnitarioService from './Services/AlbumUnitario';
import { IAlbumUsuarioData } from '../../Interface/DTO Back/AlbumUsuario/IAlbumUsuario';
import { carouselTarjets } from '../../Utils/carouselTarjets';
import { ConfigCarrouselModels } from '../../Models/ConfigCarrousel.models';



export const AlbumUsuario: React.FC = () => {

    /// HOOKS
    const storeGlobal = useGlobalContext();
    const [allMyAlbumes, setAllMyAlbumes] = useState<IAlbumUsuarioData[]>([])


    /// METODOS
    const getAllMyAlbumes = async () => {

        try {
                      
            storeGlobal.SetShowLoader(true)
                                        
            const {Result, MessageError } = await AlbumUnitarioService.GetAllMyAlbumes({
                page: 1,
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
                {/* {
                    allMyAlbumes?.map((Coleccion: IAlbumUsuarioData, indexAlbum: number) => (

                        <div id={`album-rotator${indexAlbum}`} key={indexAlbum} className="albumRotatorContainer">
                      
                            <section id={`album-rotator-holder${indexAlbum}`} className="albumRotatorHolder">
                                {
                                    Coleccion?.listadoAlbum.map((album: IAlbumData, indexEsport: number)=>(
                                        <article id={`album-item${indexAlbum}`} style={{cursor: 'pointer'}}
                                            className={`albumItem`} key={indexEsport}
                                        >
                                            <div className={`albumItem__details`}>  

                                                <h3>{album.titulo}</h3>
            
                                                <button className="btnAlbumComprar" type='submit' onClick={() => sendAlbum(album.id)}>Comprar</button>
                                            </div>
                                        </article>
                                    ))
                                }
                            </section>
                        </div> 
                    ))
                } */}
        
            </div>
        </div>

    )
}


 
