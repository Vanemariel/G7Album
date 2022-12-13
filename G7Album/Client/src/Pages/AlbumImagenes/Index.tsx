//import { useEffect } from "react";
//import { FormLogin } from "./Components/FormLogin/FormLogin";
import './style.css'
import { useNavigate } from 'react-router-dom'

import AlbumImagenesMock from './Mocks/AlbumImagenes.json'
import { useEffect, useState } from 'react';
import { carouselTarjets } from '../../Utils/carouselTarjets';
import { IAlbumImagenesData } from '../../Interface/DTO Back/AlbumImagenes/IAlbumImagenes';
import { ConfigCarrouselModels } from '../../Models/ConfigCarrousel.models';
import AlbumImagenService from './Services/AlbumImagen.service';
import { IAlbumData } from '../../Interface/DTO Back/Album/IAlbumData';
import { usePaginate } from '../../Hooks/usePaginate';
import { Paginate } from '../../Components/Paginate/Paginate';
import { Loader } from '../../Components/Loader/Loader';
import { useGlobalContext } from '../../Context/useGlobalContext';

export const AlbumImagenes: React.FC = () => {


    /// HOOKS
    const [allAlbumImagenes, setAllAlbumImagenes] = useState<IAlbumData[]>([])
    const { paginate, setPaginate } = usePaginate()
    const storeGlobal = useGlobalContext();
    const [query, setQuery] = useState('');


    /// METODOS


    const getAllAlbumImagenes = async (page: number = 1, query?: string) => {

        const data = await AlbumImagenService.GetAllFiguritasAlbumes(page, query)

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
            currentPage: data.Result.currentPage - 1,
            pagesTotal: data.Result.pages
        })
        setAllAlbumImagenes(data.Result.listItems)
        carouselTarjets(arrAlbumImg)
    }

    const changePage = ({ selected }: any) => {
        window.scrollTo(0, 0);
        getAllAlbumImagenes(selected + 1, query)
    }

    const buyFigurita = async (idFigurita: number, IdAlbum: number) => {

        try {

            storeGlobal.SetShowLoader(true)

            const { Result, MessageError } = await AlbumImagenService.buyFigurita({
                IdUsuario: storeGlobal.GetMyUserData().Id,
                IdAlbumImagen: idFigurita,
                IdAlbum: IdAlbum
            })

            if (MessageError != undefined) {
                throw new Error(MessageError);
            }

            storeGlobal.SetShowLoader(false)
            storeGlobal.SetMessageModalStatus(Result)

        } catch (error: any) {

            storeGlobal.SetShowLoader(false)
            storeGlobal.SetMessageModalStatus(`Uups... ${error}. \n \n Intentelo nuevamente`)

        } finally {
            storeGlobal.SetShowModalStatus(true)

            setTimeout(() => {
                storeGlobal.SetShowModalStatus(false)
            }, 5000);

        }
    }

    useEffect(() => {
        getAllAlbumImagenes()
    }, [])

    return (

        <>

            <div className="containerPageAlbum">

                <div id="m">


                <div className="container">
                        <div className="input-group mb-3">
                            <input
                                type="text" className="form-control"
                                placeholder="Escribe album o torneo deseado"
                                onChange={(e) => setQuery(e.target.value)}
                            />
                            <div className="input-group-append">
                                <button type="button" className="btn btn-primary" 
                                    onClick={()=> getAllAlbumImagenes(1, query)}>
                                    <i className="fas fa-search"></i>
                                </button>
                            </div>
                        </div>
                    </div>

                    {allAlbumImagenes.length === 0 && <Loader />}

                    {
                        allAlbumImagenes.map((AlbumIMG: IAlbumData, indexAlbum: number) => (

                            <div id={`album-rotator${indexAlbum}`} key={indexAlbum} className="albumRotatorContainer">

                                <h1 className='title'>{AlbumIMG.titulo}</h1>

                                <section id={`album-rotator-holder${indexAlbum}`} className="albumRotatorHolder">
                                    {
                                        AlbumIMG.listadoImagenes.map((figuritas: IAlbumImagenesData, indexEsport: number) => (
                                            <article id={`album-item${indexAlbum}`} style={{ cursor: 'pointer' }}
                                                className={`albumItem`} key={indexEsport}
                                            >
                                                <img src={figuritas.imagen} alt="" className="image" />

                                                <div className={`albumItem__details`}>
                                                    <h3>{figuritas.titulo}</h3>
                                                    <button className="btnFiguritasComprar" type='submit'
                                                        onClick={() => buyFigurita(figuritas.id, figuritas.albumId)}>Comprar</button>
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


    )
}