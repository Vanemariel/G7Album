//import { useEffect } from "react";
//import { FormLogin } from "./Components/FormLogin/FormLogin";
import './style.css'
import './style2.css'
import './style3.css'
// import Container from 'react-bootstrap/Container';
// import Nav from 'react-bootstrap/Nav';
// import Navbar from 'react-bootstrap/Navbar';
// import NavDropdown from 'react-bootstrap/NavDropdown';
import 'bootstrap/dist/css/bootstrap.min.css';
import AlbumUnitarioMock from './Mocks/AlbumUnitario.json'


export const AlbumUnitario: React.FC = () => {


    /// METODOS


    return (

        <div className="containerPageAlbum">

            <div>

                {
                    AlbumUnitarioMock.map(( AlbumUnitario: any, indexAlbumUnitario: number)=>(

                        <div id="album-rotator">
                           <h1>{AlbumUnitario.title}</h1>
                      
                            <div id="album-rotator-holder">
                            
                            {
                                    AlbumUnitario.Albumes.map((Albumdeuno: any, indexAlbumUnitario: number)=>(

                                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                                            <span className="album-details">
                                                
                                                <span className="subtitle">{Albumdeuno.title}</span>
                                                
                                            </span>
                                        </a>
                                    ))
                            }
                            </div>
                        </div> 
                    ))


                }

                
{/*             
                <div id="album-rotator">
                    <h1>Albumes Tenis</h1>
                    <div id="album-rotator-holder">
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                
                                <span className="subtitle">Wimbledom</span>
                               
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                
                                <span className="subtitle">Rollan Garros</span>
                                
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                
                                <span className="subtitle">Us Open</span>
                                
                            </span>
                        </a>
                    </div>
                </div>
                
                <div id="album-rotator">
                    <h1>Seccion Basket</h1>
                    <div id="album-rotator-holder">
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                
                                <span className="subtitle">Liga Endesa</span>
                                
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                
                                <span className="subtitle">NBA</span>
                               
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                
                                <span className="subtitle">Liga Argentina</span>
                               
                            </span>
                        </a>
                    </div>
                </div>
            
                <div id="album-rotator">
                    <h1>Albumes Rugby</h1>
                    <div id="album-rotator-holder">
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                
                                <span className="subtitle">National Rugby League</span>
                                
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                
                                <span className="subtitle">Super League</span>
                                
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                
                                <span className="subtitle">The Rugby Championship</span>
                                
                            </span>
                        </a>
                    </div>
                </div>
                
                <div id="album-rotator">
                    <h1>Albumes Monster Inc</h1>
                    <div id="album-rotator-holder">
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                
                                <span className="subtitle">Monster Inc</span>
                               
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                
                                <span className="subtitle">Monster University</span>
                                
                            </span>
                        </a>
                    </div>
                </div>
            
                <div id="album-rotator">
                    <h1>Albumes High School Musical</h1>
                    <div id="album-rotator-holder">
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                
                                <span className="subtitle">High school Musical</span>
                                
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                
                                <span className="subtitle">High school Musical 2</span>
                                
                            </span>
                        </a>
                    </div>
                </div>
            
                <div id="album-rotator">
                    <h1>Albumes La Era del Hielo</h1>
                    <div id="album-rotator-holder">
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                
                                <span className="subtitle">La era del Hielo</span>
                               
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                
                                <span className="subtitle">La era del Hielo 2</span>
                                
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                               
                                <span className="subtitle">La era del Hielo 3</span>
                                
                            </span>
                        </a>
                    </div>
                </div>
            
                <div id="album-rotator">
                    <h1>Albumes Avatar</h1>
                    <div id="album-rotator-holder">
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                               
                                <span className="subtitle">Avatar</span>
                               
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                
                                <span className="subtitle">Avatar 2</span>
                                
                            </span>
                        </a>
                    </div>
                </div>
            
                <div id="album-rotator">
                    <h1>Albumes Dragon Ball </h1>
                    <div id="album-rotator-holder">
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                               
                                <span className="subtitle">Dragon Ball</span>
                                
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                
                                <span className="subtitle">Dragon Ball Z</span>
                                
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                
                                <span className="subtitle">Dragon Ball GT</span>
                                
                            </span>
                        </a>
                    </div>
                </div>
                
                <div id="album-rotator">
                    <h1>Albumes Naruto </h1>
                    <div id="album-rotator-holder">
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                
                                <span className="subtitle">Naruto </span>
                                
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                
                                <span className="subtitle">Naruto shippuden</span>
                                
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                               
                                <span className="subtitle">Naruto Next Generation</span>
                                
                            </span>
                        </a>  
                    </div>
                </div>
                
                <div id="album-rotator">
                    <h1>Albumes Caballeros del Zodiaco </h1>
                    <div id="album-rotator-holder">
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                
                                <span className="subtitle">Saint Seiya the Lost Canvas</span>
                                
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                               
                                <span className="subtitle">Batalla de Poseidon</span>
                               
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                
                                <span className="subtitle">Batalla de Asgard</span>
                                
                            </span>
                        </a>
                    </div>
                </div>
                
                <div id="album-rotator">
                    <h1>Albumes Ataque a los Titanes </h1>
                    <div id="album-rotator-holder">
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                               
                                <span className="subtitle">Ataque a los Titanes Temporada 1<br/></span>
                                
                            </span>
                        </a>
                        <a target="_top" className="album-item" href="https://twitter.com/smpnjn">
                            <span className="album-details">
                                <span className="icon"><i className="far fa-at"></i> GroupAlbumesEdition</span>
                                
                                <span className="subtitle">Ataque a los Titanes Temporada 2</span>
                                
                            </span>
                        </a>
                    </div>
                </div> */}

            </div>

        </div>

    )
}