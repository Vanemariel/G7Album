import { Route, Routes } from 'react-router-dom';
import './App.css';
import { Loader } from './Components/Loader/Loader';
import { MessageModal } from './Components/ModalContainer/MessageModal';
import { GlobalProvider } from './Context/GlobalProvider';
import { AuthProvider } from './Pages/Authentication/Context/AuthProvider';
import { Authentication } from './Pages/Authentication/Index';
import { Home } from './Pages/Home/Index';

function App() {

  return (
    <GlobalProvider>

      <Routes>

        <Route path="/" element={
          <AuthProvider>
            <Authentication />
          </AuthProvider>
        } />
        
        <Route path="/home" element={<Home />} />

      </Routes>

      <Loader/>

      <MessageModal/>

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