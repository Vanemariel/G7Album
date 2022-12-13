
import './style.css'
import { useEffect, useState } from 'react';
import { useGlobalContext } from '../../Context/useGlobalContext';
import AlbumUsuarioService from './Services/AlbumUsuario.service';
import { IAlbumUsuarioData } from '../../Interface/DTO Back/AlbumUsuario/IAlbumUsuario';
import { carouselTarjets } from '../../Utils/carouselTarjets';
import { ConfigCarrouselModels } from '../../Models/ConfigCarrousel.models';
import { usePaginate } from '../../Hooks/usePaginate';
import { Paginate } from '../../Components/Paginate/Paginate';
import { useNavigate } from 'react-router-dom';



export const AlbumUsuario: React.FC = () => {

    /// HOOKS
    const navigate = useNavigate()
    const { paginate, setPaginate } = usePaginate()
    const storeGlobal = useGlobalContext();
    const [allMyAlbumes, setAllMyAlbumes] = useState<IAlbumUsuarioData[]>([])


    /// METODOS
    const getAllMyAlbumes = async (page: number = 1) => {

        try {

            storeGlobal.SetShowLoader(true)

            const { Result, MessageError } = await AlbumUsuarioService.GetAllMyAlbumes({
                page,
                idUsuario: storeGlobal.GetMyUserData().Id
            })

            if (MessageError !== undefined) {
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
                currentPage: Result.currentPage - 1,
                pagesTotal: Result.pages
            })
            setAllMyAlbumes(Result.listItems)
            carouselTarjets(arrAlbum)

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

    const changePage = ({ selected }: any) => {
        window.scrollTo(0, 0);
        getAllMyAlbumes(selected + 1)
    }



    useEffect(() => {
        getAllMyAlbumes()
    }, [])

    return (


        <div className="containerPageAlbum">
            <div id="m">

                <h1>Mis Albumes </h1>


                {allMyAlbumes.length === 0 &&
                    <div className='containerNotAlbum'>
                        <h3>Uups... Aun no tiene ningun Album! ¿Desea comprar uno? </h3>

                        <button className='btnAlbumComprar' onClick={() => navigate('/Album')}>Ir a Album</button>
                    </div>
                }

                {
                    <div id={`album-rotator0`} className="albumRotatorContainer">

                        <section id={`album-rotator-holder0`} className="albumRotatorHolder">
                            {
                                allMyAlbumes.map((myAlbum: IAlbumUsuarioData, indexEsport: number) => (
                                    <article id={`album-item0`} style={{ cursor: 'pointer' }}
                                        className={`albumItem`} key={indexEsport}
                                    >
                                        <img src={myAlbum.album.imagen} className="image" alt="" />

                                        <div className={`albumItem__details`}>
                                            <h3>{myAlbum.album.titulo}</h3>

                                            <button
                                              onClick={() => navigate(`/AlbumUsuarioImagen/${myAlbum.album.titulo}/${myAlbum.albumId}`)}
                                            > Ver figuritas</button>
                                        </div>
                                    </article>
                                ))
                            }
                        </section>
                    </div>
                }

                {allMyAlbumes.length != 0 && <div>
                    <Paginate
                        ChangePage={changePage}
                        PageCount={paginate.pagesTotal}
                        LocatedPageNumber={paginate.currentPage}
                    />
                </div>}

            </div>
        </div>

    )
}
