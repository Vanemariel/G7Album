import React, { useEffect } from "react";
import { useGlobalContext } from "../../Context/useGlobalContext";
import ModalStatusCSS from "./ModalStatus.module.css";



export const ModalStatus: React.FC = () => {

    /// VARIABLES
    const OpenModalCss = `${ModalStatusCSS.containerModal} ${ModalStatusCSS["containerModal--openModal"]}`;
    const CloseModalCss = `${ModalStatusCSS.containerModal}`;

    /// HOOKS
    const storeGlobal  = useGlobalContext()

    useEffect(()=>{
        const $body = document.querySelector("body") as HTMLBodyElement;
        if (storeGlobal.IsShowModalStatus()) {
          // slideCarrusel();
          $body.style.overflowY = "hidden";
        } else {
          $body.style.overflowY = "scroll";
        }        
    },[storeGlobal.IsShowModalStatus()])


    return (
      <article className={`${storeGlobal.IsShowModalStatus() ? OpenModalCss : CloseModalCss}`}>
          <div>
              <article className={ModalStatusCSS.contentModal}>
                  <p>{`${storeGlobal.GetMessageModalStatus()}`}</p>
                  <i className="far fa-smile-wink"/>
              </article>
          </div>
      </article>
    );
};
