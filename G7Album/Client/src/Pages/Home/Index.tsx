import { useEffect } from "react";
import { useGlobalContext } from "../../Context/useGlobalContext";
import { UserModels } from "../../Models/User.models";
import { getStorage } from "../../Utils/updateStorage";
import './style.css'
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import 'bootstrap/dist/css/bootstrap.min.css';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';


export const Home : React.FC = () => {
    const storeGlobal = useGlobalContext();

    useEffect(() => {
        console.log("AAAAASD", getStorage<UserModels>("User"))
    }, [])


    return (
/*

        <div>

            <p>ESTO ES EL HOME</p>

            <p>{JSON.stringify(storeGlobal.GetMyUserData())}</p>

        </div>

    )
        */






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
                        Cerar sesion
                    </NavDropdown.Item>

                </NavDropdown>
          </Nav>
          <Form className="d-flex">
            <Form.Control
              type="search"
              placeholder="Buscar album, figus"
              className="me-2"
              aria-label="Search"
            />
            <Button variant="outline-success">Buscar</Button>
          </Form>
        </Navbar.Collapse>
      </Container>
    </Navbar>


    <div className="containerPageAlbum">

        <div id="m">
          

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


)
}
