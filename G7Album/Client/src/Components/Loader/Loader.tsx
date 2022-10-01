import { useGlobalContext } from "../../Context/useGlobalContext";
import LoaderCSS from "./Loader.module.css";


export const Loader = () => {
  
  const storeGlobal  = useGlobalContext()
  
  return (
    <div className={`${storeGlobal.IsShowLoader() ? LoaderCSS.backgroundSpinner : LoaderCSS.CloseLoader} `}>

      <div className={LoaderCSS.containerSpinner}>

        <div className={LoaderCSS.spinner}>
          <div></div>
          <div></div>
          <div></div>
          <div></div>
          <div></div>
          <div></div>
          <div></div>
          <div></div>
        </div>

        <h5> Espere por favor...</h5>

      </div>

    </div>
  );
};