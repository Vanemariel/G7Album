import { Route, Routes } from 'react-router-dom';
import './App.css';
import { AuthProvider } from './Pages/Authentication/Context/AuthProvider';
import { Authentication } from './Pages/Authentication/Index';
import { Home } from './Pages/Home/Index';

function App() {

  return (
      <Routes>
        <Route path="/" element={ // --  /auth
          <AuthProvider>
            <Authentication />
          </AuthProvider>
        } />
        <Route path="/home" element={<Home />} />

      </Routes>
  );
}
// https://bobbyhadz.com/blog/react-useroutes-may-be-used-only-in-context-of-router
const AppWrapper = () => {
  return (
    // Englobamos Redux al proyecto
    // <Provider store={store}>
      <App />
    /* </Provider> */
  );
};


export default AppWrapper;