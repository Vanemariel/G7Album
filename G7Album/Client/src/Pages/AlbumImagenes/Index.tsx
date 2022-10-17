//import { useEffect } from "react";
//import { FormLogin } from "./Components/FormLogin/FormLogin";
import './style.css'
import {useNavigate} from 'react-router-dom'

import AlbumImagenesMock from './Mocks/AlbumImagenes.json'
import { useEffect, useState } from 'react';
import { carouselTarjets } from '../../Utils/carouselTarjets';
import { IAlbumImagenesData } from '../../Interface/DTO Back/AlbumImagenes/IAlbumImagenes';
import { ConfigCarrouselModels } from '../../Models/ConfigCarrousel.models';
import AlbumImagenService from './Services/AlbumImagen.service';
import { IAlbumData } from '../../Interface/DTO Back/Album/IAlbumData';
import { usePaginate } from '../../Hooks/usePaginate';
import { Paginate } from '../../Components/Paginate/Paginate';

export const AlbumImagenes: React.FC = () => {

    /// HOOKS
    const [allAlbumImagenes, setAllAlbumImagenes] = useState<IAlbumData[]>([])
    const {paginate, setPaginate} = usePaginate()


    /// METODOS
    const config = [
        {
            individualItem: '#album-item0',
            carouselWidth: 1000, // in px
            carouselId: '#album-rotator0',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder0'
        },
        {
            individualItem: '#album-item1',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator1',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder1',
        },

        {
            individualItem: '#album-item2',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator2',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder2',
        },

        {
            individualItem: '#album-item3',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator3',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder3',
        },
        {
            individualItem: '#album-item4',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator4',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder4',
        },
        {
            individualItem: '#album-item5',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator5',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder5',
        },
        {
            individualItem: '#album-item6',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator6',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder6',
        },
        {
            individualItem: '#album-item7',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator7',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder7',
        },
        {
            individualItem: '#album-item8',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator8',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder8',
        },
        {
            individualItem: '#album-item9',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator9',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder9',
        },
        {
            individualItem: '#album-item10',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator10',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder10',
        },
        {
            individualItem: '#album-item11',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator11',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder11',
        },
        {
            individualItem: '#album-item12',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator12',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder12',
        },
        {
            individualItem: '#album-item13',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator13',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder13',
        },
        {
            individualItem: '#album-item14',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator14',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder14',
        },
        {
            individualItem: '#album-item15',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator15',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder15',
        },
        {
            individualItem: '#album-item16',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator16',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder16',
        },
        {
            individualItem: '#album-item17',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator17',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder17',
        },
        {
            individualItem: '#album-item18',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator18',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder18',
        },
        {
            individualItem: '#album-item19',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator19',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder19',
        },
        {
            individualItem: '#album-item20',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator20',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder20',
        },
        {
            individualItem: '#album-item21',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator21',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder21',
        },
        {
            individualItem: '#album-item22',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator22',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder22',
        },
        {
            individualItem: '#album-item23',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator23',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder23',
        },
        {
            individualItem: '#album-item24',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator24',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder24',
        },
        {
            individualItem: '#album-item25',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator25',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder25',
        },
        {
            individualItem: '#album-item26',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator26',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder26',
        },
        {
            individualItem: '#album-item27',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator27',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder27',
        },
        {
            individualItem: '#album-item28',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator28',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder28',
        },
        {
            individualItem: '#album-item29',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator29',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder29',
        },
        {
            individualItem: '#album-item30',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator30',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder30',
        },
        {
            individualItem: '#album-item31',
            carouselWidth: 1000, // in p
            carouselId: '#album-rotator31',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder31',
        },
    ]


    const getAllAlbumImagenes = async (page: number = 1) => {

        const data = await AlbumImagenService.GetAllFiguritasAlbumes(page)

        let arrAlbumImg: ConfigCarrouselModels[] = []
        
        data.Result?.listItems.map((coleccion: any, index: number) => {
            arrAlbumImg.push({
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
        setAllAlbumImagenes(data.Result.listItems)
        carouselTarjets(arrAlbumImg)
    }

    const changePage = ({selected}: any) => {
        window.scrollTo(0,0);
        getAllAlbumImagenes(selected+1)
    }

    useEffect(()=> {
        getAllAlbumImagenes()
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

                    {
                        allAlbumImagenes.map((AlbumIMG: IAlbumData, indexAlbum: number) => (

                            <div id={`album-rotator${indexAlbum}`} key={indexAlbum} className="albumRotatorContainer">

                                <h1 className='title'>{AlbumIMG.titulo}</h1>

                                <section id={`album-rotator-holder${indexAlbum}`} className="albumRotatorHolder">
                                    {
                                        AlbumIMG.listadoImagenes.map((figuritas: IAlbumImagenesData, indexEsport: number) => (
                                            <article id={`album-item${indexAlbum}`} style={{cursor: 'pointer'}}
                                                className={`albumItem`} key={indexEsport}
                                            >   
                                                <div className={`albumItem__details`}>  

                                                   <h3>{figuritas.titulo}</h3>

                                                   <button className="btnFiguritasComprar" type='submit' onClick={() => alert("Funcion no realizada")}>Comprar</button>

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

            </div></>


)}