import { Route, Routes } from 'react-router-dom';
import './App.css';
import { Loader } from './Components/Loader/Loader';
import { ModalStatus } from './Components/ModalStatus/ModalStatus';
import { RoutePrivate } from './Components/RoutePrivate/RoutePrivate';
import { GlobalProvider } from './Context/GlobalProvider';
import { AuthProvider } from './Pages/Authentication/Context/AuthProvider';
import { Authentication } from './Pages/Authentication/Index';
import { Home } from './Pages/Home/Index';

function App() {

  return (

      <GlobalProvider>
          {/*Quitar algun momento GlobalProvider por redux */}
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