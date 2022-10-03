//import { useEffect } from "react";
//import { FormLogin } from "./Components/FormLogin/FormLogin";
import './style.css'
import './style2.css'
import './style3.css'
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import 'bootstrap/dist/css/bootstrap.min.css';

export const FiguritasCompra: React.FC = () => {


    /// METODOS


    return (



        <><Navbar bg="dark" variant="dark">
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
                            <NavDropdown.Item href="">
                                Cerar sesion
                            </NavDropdown.Item>
                        
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

                    <div id="album-rotator">
                        <h1>FIGURITAS DE DEPORTES</h1>
                        <div id="album-rotator-holder">
                            <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                                <span className="album-details">
                                    <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                    <span className="title">Click</span>
                                    <span className="subtitle">Figus Futbol</span>
                                    <span className="subtext">Copa Libertadores<br />Copa America<br />Champios League</span>
                                </span>
                            </a>
                            <a target="_top" className="album-item" href="https://fjolt.com/article/apple-cards-webl-gl-javascript">
                                <span className="album-details">
                                    <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                    <span className="title">Click</span>
                                    <span className="subtitle">Figus Tenis</span>
                                    <span className="subtext">Wimledon<br />Rollan Garros<br />Us Open</span>
                                </span>
                            </a>
                            <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                                <span className="album-details">
                                    <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                    <span className="title">Click</span>
                                    <span className="subtitle">Figus Basket</span>
                                    <span className="subtext">Liga Endesa<br />NBA<br />La Liga Argentina</span>
                                </span>
                            </a>
                            <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                                <span className="album-details">
                                    <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                    <span className="title">Click para ver las figuritas</span>
                                    <span className="subtitle">Figus Rugby</span>
                                    <span className="subtext">Nationas Rugby League<br />Super League<br />The Rugby ChampionsShip</span>
                                </span>
                            </a>
                        </div>
                    </div>


                    <div id="album-rotator2">
                        <h1>FIGURITAS DE DISNEY</h1>
                        <div id="album-rotator-holder2">
                            <a target="_top" className="album-item2" href="https://twitter.com/smpnjn">
                                <span className="album-details2">
                                    <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                    <span className="title">Click</span>
                                    <span className="subtitle">Figus Monster Inc</span>
                                    <span className="subtext">Monster Inc<br />Monster University</span>
                                </span>
                            </a>
                            <a target="_top" className="album-item2" href="https://fjolt.com/article/apple-cards-webl-gl-javascript">
                                <span className="album-details2">
                                    <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                    <span className="title">Click</span>
                                    <span className="subtitle">Figus High school Musical</span>
                                    <span className="subtext">High school Musical<br />High school Musical 2</span>
                                </span>
                            </a>
                            <a target="_top" className="album-item2" href="https://twitter.com/smpnjn">
                                <span className="album-details2">
                                    <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                    <span className="title">hielo</span>
                                    <span className="subtitle">Figus </span>
                                    <span className="subtext">La Hera de hielo 1<br />La era de hielo 2<br />La era de hielo 3</span>
                                </span>
                            </a>
                            <a target="_top" className="album-item2" href="https://twitter.com/smpnjn">
                                <span className="album-details2">

                                    <span className="title">Avatar</span>
                                    <span className="subtitle">Figus Avatar</span>
                                    <span className="subtext">Avatar<br />Avatar 2</span>
                                </span>
                            </a>
                        </div>
                    </div>

                    <div id="album-rotator3">
                        <h1>FIGURITAS DE ANIME</h1>
                        <div id="album-rotator-holder3">
                            <a target="_top" className="album-item3" href="https://twitter.com/smpnjn">
                                <span className="album-details3">
                                    <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                    <span className="title">Click</span>
                                    <span className="subtitle">Figus Dragon Ball Z</span>
                                    <span className="subtext">Dragon Ball Z<br />Dragon Ball GT</span>
                                </span>
                            </a>
                            <a target="_top" className="album-item3" href="https://fjolt.com/article/apple-cards-webl-gl-javascript">
                                <span className="album-details3">
                                    <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                    <span className="title">Click</span>
                                    <span className="subtitle">Figus Naruto</span>
                                    <span className="subtext">Naruto<br />Naruto Shippuden<br />Naruto Next Generation</span>
                                </span>
                            </a>
                            <a target="_top" className="album-item3" href="https://twitter.com/smpnjn">
                                <span className="album-details3">
                                    <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                    <span className="title">Click</span>
                                    <span className="subtitle">Figus Los Caballeros de Zodiaco</span>
                                    <span className="subtext">Saint Seiya the Lost Canvas<br />Batalla de Poseidon<br />Batalla de Asgard</span>
                                </span>
                            </a>
                            <a target="_top" className="album-item3" href="https://twitter.com/smpnjn">
                                <span className="album-details3">
                                    <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                    <span className="title">Click para ver las figuritas</span>
                                    <span className="subtitle">Figus da Ataque a los Titanes</span>
                                    <span className="subtext">Temprada 1<br />Temporada 2</span>
                                </span>
                            </a>
                        </div>
                    </div>

                </div>

            </div></>


)}