import React, { useEffect } from "react";
import ModalContainerCSS from "./ModalContainer.module.css";

interface Props {
  validation: any;
  message: string;
  cssModalCOntainer: any;
}

export const openAndShowMessageModal = (hashModal: any) => {
  window.location.hash = hashModal;
  setTimeout(() => {
    window.location.hash = "#close";
  }, 3000);
  setTimeout(() => {
    window.location.hash = "#";
  }, 4000);
};

export const ModalContainer: React.FC<Props> = (props) => {
  const { message, validation, cssModalCOntainer } = props;
  const openModalCSS = `${ModalContainerCSS.portfolioModal} ${ModalContainerCSS.openPortafolioModal}`;
  const modalCSS = `${ModalContainerCSS.portfolioModal}`;

  useEffect(() => {
    const $body = document.querySelector("body") as HTMLBodyElement;
    if (validation) {
      // slideCarrusel();
      $body.style.overflowY = "hidden";
    } else {
      $body.style.overflowY = "scroll";
    }
    document.addEventListener("keydown", (e) => {
      if (e.code === "Escape") {
        window.location.hash = "#close";
      }
    });
  }, [validation]);

  return (
    <article className={validation ? openModalCSS : modalCSS}>
      <div>
        <article className={cssModalCOntainer}>
          <h3>{message}</h3>
          <i className="far fa-smile-wink" />
        </article>
      </div>
    </article>
  );
};

/*  EJEMPLO de USO:

  1) En "validation", indicamos 

    <ModalContainer
      validation={validationHash}
      cssModal=""
      message={
        "Uupss... Ha ocurrido un error, intentelo mas tarde."
      }
    />



  CASO EXTRA: En caso de utilizar este componente en un 
  formulario y necesitamos que elimine un contenido o algo, utilizaremos la siguiente funcion:
  
  const openModal = (message: string) => {
    setLoaderActive(false);
    window.location.hash = message;

    setTimeout(() => {
      window.location.hash = "#close";
    }, 3000);

    document.querySelectorAll("form i").forEach((enlace) => {
      enlace.classList.remove("fa-check-circle");
      enlace.classList.remove("fa-times-circle");
    }); /// ELIMINA ICONOS DE LOS INPUTS
    reset(); /// ELIMINA CONTENIDO INPUTS
  };
*/
