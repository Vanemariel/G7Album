import React from "react";
import { useGlobalContext } from "../../Context/useGlobalContext";
import MessageModalCSS from "./MessageModal.module.css";


export const MessageModal: React.FC = () => {

  const OpenModalCss = `${MessageModalCSS.containerModal} ${MessageModalCSS["containerModal--openModal"]}`;
  const CloseModalCss = `${MessageModalCSS.containerModal}`;

    
  const storeGlobal  = useGlobalContext()
  
  return (
    <article className={`${storeGlobal.IsShowMessageModal() ? OpenModalCss : CloseModalCss}`}>
      <div>
        <article className="contentModal">
          <p>{storeGlobal.GetMessageModal()}</p> 
          <i className="fa-solid fa-face-laugh-beam"/>
        </article>
      </div>
    </article>
  );
};
