import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Button, Form } from 'react-bootstrap';
import { useLocation } from 'react-router-dom';

export const Navigate: React.FC = () => {


    if (useLocation().pathname === '/') {
        return <></>
    }

    return (

        <Navbar bg="dark" variant="dark">
        <Container>
          <Navbar.Brand href="">G7Album</Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="me-auto">
              {/* <Nav.Link href="Home">Inicio</Nav.Link> */}
              <Nav.Link href="AlbumUsuario">Mis albumes</Nav.Link>
              <Nav.Link href="Album">Albumes</Nav.Link>
              <Nav.Link href="AlbumImagenes">Figuritas</Nav.Link>

              <NavDropdown title="Mi cuenta" id="basic-nav-dropdown">
                {/* <NavDropdown.Item href="AlbumUsuario">Mis albumes</NavDropdown.Item> */}
                {/* <NavDropdown.Item href="AlbumUsuario">Comprar albumes</NavDropdown.Item> */}
                <NavDropdown.Item href=""> Cerar sesion </NavDropdown.Item>
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
    )
}