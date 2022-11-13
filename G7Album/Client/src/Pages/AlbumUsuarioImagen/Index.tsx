
import './style.css'
import { useEffect, useState } from 'react';
import { useGlobalContext } from '../../Context/useGlobalContext';
import AlbumUnitarioService from './Services/AlbumUsuarioImagen.service';
import { IAlbumUsuarioData } from '../../Interface/DTO Back/AlbumUsuario/IAlbumUsuario';
import { carouselTarjets } from '../../Utils/carouselTarjets';
import { ConfigCarrouselModels } from '../../Models/ConfigCarrousel.models';
import { usePaginate } from '../../Hooks/usePaginate';
import { Paginate } from '../../Components/Paginate/Paginate';
import { IAlbumUsuarioImagenes } from '../../Interface/DTO Back/AlbumUsuarioImagenes/IAlbumUsuarioImagenes';
import AlbumUsuarioImagenService from './Services/AlbumUsuarioImagen.service';
import { useLocation, useNavigate, useParams } from 'react-router-dom';



export const AlbumUsuarioImagen: React.FC = () => {

    /// HOOKS

    const navigate = useNavigate()
    const params = useParams()
    const { paginate, setPaginate } = usePaginate()
    const storeGlobal = useGlobalContext();
    const [allMyFiguritas, setAllMyFiguritas] = useState<IAlbumUsuarioImagenes[]>([])
    //usestate es un estado propio de react que maneja un estado que se modifica el valor de una variable
    //de q manera se modifica a traves del setallmy figuritas. estado inicial arreglo vacio

    /// METODOS
    const getAllMyFiguritas = async (page: number = 1) => {


        try {

            storeGlobal.SetShowLoader(true)

            const { Result, MessageError } = await AlbumUsuarioImagenService.GetAllMyFiguritas({
                page,
                idAlbum: params.id !== undefined ? parseInt(params.id) : 0,
                idUsuario: storeGlobal.GetMyUserData().Id
            })

            if (MessageError !== undefined) {
                throw new Error(MessageError);
            }

            let arrAlbum: ConfigCarrouselModels[] = []
            //es para crear dinamico las tarjetas
            Result?.listItems.map((coleccion: any, index: number) => {
                arrAlbum.push({
                    individualItem: `#album-item${index}`,
                    carouselWidth: 1000, // in p
                    carouselId: `#album-rotator${index}`,
                    carouselHolderId: `#album-rotator-holder${index}`,
                })
            })
            setPaginate({
                currentPage: Result.currentPage - 1, //xq en react empiezo desde 0
                pagesTotal: Result.pages
            })
            setAllMyFiguritas(Result.listItems)//modificando el estado de mi variable allmyfigurita
            //este estado contiene mi arreglo de figuitas que lo muestro a traves del .map 
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
        getAllMyFiguritas(selected + 1)
    }

    useEffect(() => {
        getAllMyFiguritas()
    }, [])

    return (


        <div className="containerPageAlbum">
            <div id="m">

                <h1>Mis Figuritas de {params.nombreAlbum}</h1>


                {allMyFiguritas.length === 0 &&
                    <div className='containerNotFigus'>
                        <h3>Uups... Aun no tiene ninguna Figurita! ¿Desea comprar una? </h3>

                        <button className='btnAlbumComprar' onClick={() => navigate('/AlbumImagenes')}>Ir a Figuritas</button>
                    </div>
                }

                {

                    <div id={`album-rotator0`} className="albumRotatorContainer">

                        <section id={`album-rotator-holder0`} className="albumRotatorHolder">
                            {
                                allMyFiguritas.map((myFigus: IAlbumUsuarioImagenes, indexEsport: number) => (
                                    <article id={`album-item${indexEsport}`} style={{ cursor: 'pointer' }}
                                        className={`albumItem`} key={indexEsport}
                                    >
                                        <img className="image" src={myFigus.albumImagenes.imagen} alt="" />

                                        <div className={`albumItem__details`}>
                                            <h3>{myFigus.albumImagenes.titulo}</h3>

                                        </div>

                                    </article>
                                ))
                            }
                        </section>

                        {
                            allMyFiguritas.length > 0 && (
                                <h5 className='titleFigus'>Figuritas: {allMyFiguritas.length} de {allMyFiguritas[0].albumImagenes.album.cantidadImagen}</h5>
                            )
                        }
                    </div>

                }

                {allMyFiguritas.length !== 0 && <div>
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
