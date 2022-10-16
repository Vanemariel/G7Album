import {  Route, Routes } from 'react-router-dom';
import './App.css';
import { Loader } from './Components/Loader/Loader';
import { ModalStatus } from './Components/ModalStatus/ModalStatus';
import { RoutePrivate } from './Components/RoutePrivate/RoutePrivate';
import { useLocation } from "react-router-dom";

import { GlobalProvider } from './Context/GlobalProvider';
import { AuthProvider } from './Pages/Authentication/Context/AuthProvider';
import { Authentication } from './Pages/Authentication/Index';
import { Home } from './Pages/Home/Index';
import { AlbumImagenes } from './Pages/AlbumImagenes/Index';
import { ImagenFigurita } from './Pages/ImagenFigurita/Index';
import { Album } from './Pages/Album/Index';

import { AlbumUsuario } from './Pages/AlbumUsuario/Index';
import { Navigate } from './Components/Navigate/Navigate';


function App() {

  return (
    <>
      <GlobalProvider>
  
        <Navigate/>

        <Routes>
          <Route path="/" element={
            <AuthProvider>
              <Authentication />
            </AuthProvider>
          }/>
      
          <Route path="/Home" element={
              <RoutePrivate>
                  <Home />
              </RoutePrivate>
          } />
          <Route path="/AlbumUsuario" element={
              <RoutePrivate>
                 <AlbumUsuario />
             </RoutePrivate>
            } />
          <Route path="/AlbumImagenes" element={
              <RoutePrivate>
                    <AlbumImagenes />
             </RoutePrivate>
          } />

          <Route path="/Album" element={
            <RoutePrivate>
                <Album/>
              </RoutePrivate> 
          }/>
          
          {/* 
            <Route path="/ImagenFigurita" element={
                <RoutePrivate>
                      <ImagenFigurita />
                </RoutePrivate>
            } /> */}

          {/* <Route path="/AlbumUnitario" element={
              <RoutePrivate>
                <AlbumUnitario/>
              </RoutePrivate> 
          }/> */}
          
        </Routes>

        <Loader/>

        <ModalStatus />

      </GlobalProvider>

    </>
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