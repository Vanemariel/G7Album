/* eslint-disable jsx-a11y/anchor-is-valid */
import { useNavigate } from "react-router-dom";
import './style.css'
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import 'bootstrap/dist/css/bootstrap.min.css';

// import AlbumesMock from './Mocks/Albumes.json'
import AlbumesMock from './Mocks/AlbumesV2.json'
import { useEffect, useState } from 'react';
import { carouselTarjets } from '../../Utils/carouselTarjets';
import ColeccionAlbumService from './Services/ColeccionAlbum.service';
import { IColeccionData } from "../../Interface/DTO Back/ColeccionAlbum/ColeccionAlbumData";
import { AlbumData } from "../../Interface/DTO Back/Album/AlbumData";
import { ConfigCarrouselModels } from "../../Models/ConfigCarrousel.models";

export const Album: React.FC = () => {


    const navigate = useNavigate();

 
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
            carouselWidth: 1000, // in px
            carouselId: '#album-rotator2',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder2',
        },
        {
            individualItem: '#album-item3',
            carouselWidth: 1000, // in px
            carouselId: '#album-rotator3',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder3'
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
            carouselWidth: 1000, // in px
            carouselId: '#album-rotator5',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder5',
        }
    ]

    /// HOOKS
    const [allColecciones, setAllColecciones] = useState<IColeccionData[]>([])

    /// METODOS
    const getAllColeccionAlbumes = async () => {
        // eslint-disable-next-line @typescript-eslint/no-unused-expressions
        const data = await ColeccionAlbumService.GetAllColeccionAlbumes()
        
        let arrAlbum: ConfigCarrouselModels[] = []
        
        data.Result.map((coleccion: any, index: number) => {
            arrAlbum.push({
                individualItem: `#album-item${index}`,
                carouselWidth: 1000, // in p
                carouselId: `#album-rotator${index}`,    
                carouselHolderId: `#album-rotator-holder${index}`,
            })
        })
    
        setAllColecciones(data.Result)
        carouselTarjets(arrAlbum)
    }





    useEffect(()=> {
        getAllColeccionAlbumes()
    },[])

    return (


        <>
            <Navbar bg="dark" variant="dark">
                <Container>
                    <Navbar.Brand href="">G7Album</Navbar.Brand>
                    <Navbar.Toggle aria-controls="basic-navbar-nav" />
                    <Navbar.Collapse id="basic-navbar-nav">
                        <Nav className="me-auto">
                            <Nav.Link href="Home">Inicio</Nav.Link>
                            <Nav.Link href="Album">Albumes</Nav.Link>

                            <Nav.Link href="AlbumImagenes">Figuritas</Nav.Link>

                            <NavDropdown title="Mi cuenta" id="basic-nav-dropdown">
                                <NavDropdown.Item href="AlbumUsuario">Mis albumes</NavDropdown.Item>
                                <NavDropdown.Item href="AlbumUsuario">Comprar albumes</NavDropdown.Item>
                                <NavDropdown.Item href="">
                                    Cerrar sesion
                                </NavDropdown.Item>
                                <input type="text" className="form-control" placeholder="Escribe album o torneo deseado" aria-label="Recipient's username" aria-describedby="basic-addon2" />
                                <div className="input-group-append">
                                    <button type="button" className="btn btn-primary">
                                        <i className="fas fa-search"></i>
                                    </button>
                                </div>
                            </NavDropdown>
                        </Nav>
                    </Navbar.Collapse>
                </Container>
            </Navbar>

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
                
                {/* {
                    AlbumesMock.map((Album: any, indexAlbum: number) => (

                        <div id={`album-rotator${indexAlbum}`} key={indexAlbum} className="albumRotatorContainer">
                           <h1 className='title'>{Album.title}</h1>
                      
                            <section id={`album-rotator-holder${indexAlbum}`} className="albumRotatorHolder">
                                {
                                    Album.subCategorys.map((category: any, indexEsport: number)=>(
                                        <article id={`album-item${indexAlbum}`} style={{cursor: 'pointer'}}
                                            className={`albumItem`} key={indexEsport}
                                        >
                                            <div className={`albumItem__details`}>  

                                                <h3>{category.title}</h3>
            
                                                <button className="btnAlbumComprar" type='submit' onClick={() => navigate('/AlbumImagenes')}>Comprar</button>
                                            </div>
                                        </article>
                                    ))
                                }
                            </section>
                        </div> 
                    ))
                } */}
                {
                    allColecciones?.map((Coleccion: IColeccionData, indexAlbum: number) => (

                        <div id={`album-rotator${indexAlbum}`} key={indexAlbum} className="albumRotatorContainer">
                           <h1 className='title'>{Coleccion.tituloColeccion}</h1>
                      
                            <section id={`album-rotator-holder${indexAlbum}`} className="albumRotatorHolder">
                                {
                                    Coleccion?.listadoAlbum.map((album: AlbumData, indexEsport: number)=>(
                                        <article id={`album-item${indexAlbum}`} style={{cursor: 'pointer'}}
                                            className={`albumItem`} key={indexEsport}
                                        >
                                            <div className={`albumItem__details`}>  

                                                <h3>{album.titulo}</h3>
            
                                                <button className="btnAlbumComprar" type='submit' onClick={() => navigate('/AlbumImagenes')}>Comprar</button>
                                            </div>
                                        </article>
                                    ))
                                }
                            </section>
                        </div> 
                    ))
                }
                </div>
            </div>
        </>
    );
}