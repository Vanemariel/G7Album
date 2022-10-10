/* eslint-disable jsx-a11y/anchor-is-valid */
import './style.css'
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import 'bootstrap/dist/css/bootstrap.min.css';

import AlbumesMock from './Mocks/Albumes.json'
import { useEffect, useState } from 'react';
import { carouselTarjets } from '../../Utils/carouselTarjets';
import AlbumService from './Services/Album.service';

export const Album: React.FC = () => {

    /// VARIABLES
    const config = [
        {
            individualItem: '#album-item0',
            carouselWidth: 1000, // in px
            carouselId: '#album-rotator0',    
            // carousel should be <div id="carouselId3"><div id="carouselHolderId3">{items}</div></div>
            carouselHolderId: '#album-rotator-holder0',
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
        }
    ]

    /// HOOKS
    const [allAlbumes, setAllAlbumes] = useState()
    
    /// METODOS
    const getAllAlbumes = () => {
        // eslint-disable-next-line @typescript-eslint/no-unused-expressions
        AlbumService.GetAllAlbumes(1)
    }





    useEffect(()=> {
        carouselTarjets(config)
        getAllAlbumes()
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

                            <Nav.Link href="FiguritasCompra">Figuritas</Nav.Link>

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
        
                    {
                        AlbumesMock.map((Album: any, indexAlbum: number) => (
                            <div id={`album-rotator${indexAlbum}`} key={indexAlbum} className="albumRotatorContainer">
                                <h1>{Album.titleSectionMain}</h1>
                                <section id={`album-rotator-holder${indexAlbum}`} className="albumRotatorHolder">
                                    {
                                        Album.targetEsports.map((eSport: any, indexEsport: number) => (
                                            <a  id={`album-item${indexAlbum}`}
                                                className={`albumItem`} 
                                                target="_top" href='#' key={indexEsport}
                                            >
                                                <div className={`albumItem__details`}>
                                                    <span className="title"> {eSport.title}</span>
                                                    <span className="subtext">
                                                        {eSport.subCategorys.map((subCategory: any, indexSubCategory: number) => (
                                                            <p key={indexSubCategory}>{subCategory.title}</p>
                                                        ))}
                                                    </span>
                                                </div>
                                            </a>
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