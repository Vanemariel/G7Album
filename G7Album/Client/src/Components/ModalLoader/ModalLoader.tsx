import { useEffect } from "react";
import { useGlobalContext } from "../../Context/useGlobalContext";
import LoaderCSS from "./ModalLoader.module.css";


export const ModalLoader: React.FC = () => {
  
  const storeGlobal  = useGlobalContext()
  
  useEffect(()=>{
    const $body = document.querySelector("body") as HTMLBodyElement;
    if (storeGlobal.IsShowLoader()) {
      // slideCarrusel();
      $body.style.overflowY = "hidden";
    } else {
      $body.style.overflowY = "scroll";
    }
    
  },[storeGlobal.IsShowLoader()])

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
