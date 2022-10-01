import { Route, Routes } from 'react-router-dom';
import './App.css';
import { Loader } from './Components/Loader/Loader';
import { ModalStatus } from './Components/ModalStatus/ModalStatus';
import { RoutePrivate } from './Components/RoutePrivate/RoutePrivate';
import { GlobalProvider } from './Context/GlobalProvider';
import { AuthProvider } from './Pages/Authentication/Context/AuthProvider';
import { Authentication } from './Pages/Authentication/Index';
import { Home } from './Pages/Home/Index';
import { FiguritasCompra } from './Pages/FiguritasCompra/Index';
import { ImagenFigurita } from './Pages/ImagenFigurita/Index';
import { Album } from './Pages/Album/Index';
import { AlbumUnitario } from './Pages/AlbumUnitario/Index';
import { AlbumUsuario } from './Pages/AlbumUsuario/Index';






function App() {

  return (

      <GlobalProvider>
          {/*Quitar algun momento GlobalProvider por redux */}
          
          {/* Contenedor de rutas. */}
          <Routes>

            <Route path="/" element={
              <AuthProvider>
                <Authentication />
              </AuthProvider>
            }/>

        
            <Route path="/home" element={
                <RoutePrivate>
                    <Home />
                </RoutePrivate>
            } />

            <Route path="/AlbumUsuario" element={
                <RoutePrivate>
                   <AlbumUsuario />
               </RoutePrivate>
              } />

            <Route path="/FiguritasCompra" element={
                <RoutePrivate>
                      <FiguritasCompra />
               </RoutePrivate>
            } />


            <Route path="/ImagenFigurita" element={
                <RoutePrivate>
                      <ImagenFigurita />
                </RoutePrivate>
            } />

            <Route path="/home" element={
                <RoutePrivate>
                      <Home />
                  </RoutePrivate>
              } />


            <Route path="/Album" element={
                <RoutePrivate>
                  <Album/>
                </RoutePrivate> 
            }/>
            

          </Routes>

          <Loader/>

          <ModalStatus />

      </GlobalProvider>
  );
}
const AppWrapper = () => {
  return (
    // Englobamos Redux al proyecto
    // <Provider store={store}>
      <App />
    /* </Provider> */
  );
};


export default AppWrapper;