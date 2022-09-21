import { Route, Routes } from 'react-router-dom';
import './App.css';
import { Authentication } from './Pages/Authentication/Index';
import { Home } from './Pages/Home/Index';

function App() {
  return (
      <Routes>
        <Route path="/home" element={<Home />} />
        <Route path="/" element={<Authentication />} />
        <Route path="/auth" element={<Authentication />} />

        {/* <Route path="/notFound" element={<NotFound />} />
        <Route path="*" element={<Navigate to={"/notFound"} />} /> */}
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