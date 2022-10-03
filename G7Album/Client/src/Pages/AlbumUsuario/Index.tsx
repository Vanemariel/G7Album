//import { useEffect } from "react";
//import { FormLogin } from "./Components/FormLogin/FormLogin";
import './style.css'
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import 'bootstrap/dist/css/bootstrap.min.css';







export const AlbumUsuario: React.FC = () => {


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

                    <br />

                    <div id="album-rotator">
                     
                    <h1>Mis Albumes </h1>
                        <br />
                    <div id="album-rotator-holder">
                        <a target="_top" className="album-item">
                            <span className="album-details">


                                <span className="title"> Futbol</span>
                                <span className="subtext">
                                    <a href="1"> Copa Libertadores <br /> </a>
                                    <a href="2"> Champions League <br /> </a>
                                    <a href="3"> Copa America<br />  </a>
                                </span>
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://fjolt.com/article/apple-cards-webl-gl-javascript">
                            <span className="album-details">


                                <span className="title"> Tenis</span>
                                <span className="subtext">Wimledon<br />Rollan Garros<br />Us Open</span>
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">


                                <span className="title"> Basket</span>
                                <span className="subtext">Liga Endesa<br />NBA<br />La Liga Argentina</span></span>
                        </a>

                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">


                                <span className="title"> Rugby</span>
                                <span className="subtext">National Rugby League<br />Super League<br />The Rugby Championship</span>
                            </span>
                        </a>


                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> Destacado</span>
                                <span className="title">Monster Inc</span>
                                <span className="subtitle"></span>
                                <span className="subtext">Monster Inc<br />Monster University</span>
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://fjolt.com/article/apple-cards-webl-gl-javascript">
                            <span className="album-details">

                                <span className="title">High school Musical</span>

                                <span className="subtext">High school Musical<br />High school Musical 2</span>
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">

                                <span className="title">Era del Hielo</span>

                                <span className="subtext">La era del hielo 1<br />La era del hielo 2<br />La era del hielo 3</span>
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">

                                <span className="title">Avatar</span>

                                <span className="subtext">Avatar<br />Avatar 2</span>
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> Destacado</span>
                                <span className="title">Dragon Ball</span>

                                <span className="subtext">Dragon Ball <br />Dragon Ball Z<br /> Dragon Ball GT</span>
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://fjolt.com/article/apple-cards-webl-gl-javascript">
                            <span className="album-details">

                                <span className="title">Naruto</span>

                                <span className="subtext">Naruto<br />Naruto shippuden<br />Naruto Next Generation</span>
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">

                                <span className="title">Cab del Zodiaco</span>

                                <span className="subtext">Saint Seiya the Lost Canvas<br />Batalla de Poseidon<br />Batalla de Asgard</span>
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">

                                <span className="title">Ataque a los Titanes</span>

                                <span className="subtext">Temporada 1<br />Temporada 2</span>
                            </span>
                        </a>

                    </div>
                 </div>
                </div>
         </div></>


    //    <div id="album-rotator2">
    //    <h1>Mis figuritas</h1>
    //    <br>
    //    <div id="album-rotator-holder2">
    //        <a target="_top" className="album-item2" href="https://twitter.com/smpnjn">
    //            <span class="album-details2">
                   
    //                <span className="title">Monster Inc</span>
                   
    //                <span className="subtext">Monster Inc<br>Monster University</span>
    //            </span>
    //        </a>
    //        <a target="_top" className="album-item2" href="https://fjolt.com/article/apple-cards-webl-gl-javascript">
    //            <span className="album-details2">
                
    //                <span className="title">High school Musical</span>
                   
    //                <span className="subtext">High school Musical<br>High school Musical 2</span>
    //            </span>
    //        </a>
    //        <a target="_top" className="album-item2" href="https://twitter.com/smpnjn">
    //            <span class="album-details2">
                  
    //                <span className="title">La Hera de hielo</span>
                   
    //                <span className="subtext">La Hera de hielo 1<br>La era de hielo 2<br>La era de hielo 3</span>
    //            </span>
    //        </a>
    //        <a target="_top" className="album-item2" href="https://twitter.com/smpnjn">
    //            <span className="album-details2">
                   
    //            <span className="title">Avatar</span>
                  
    //                <span className="subtext">Avatar<br>Avatar 2</span>
    //            </span>
    //        </a>
    //    </div>
    //</div>


    )
}


 
