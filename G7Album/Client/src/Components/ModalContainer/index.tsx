import React, { Children, useEffect } from "react";
import { useGlobalContext } from "../../Context/useGlobalContext";
import ModalContainerCSS from "./index.module.css";

interface Props {
    children: string | any;
    personCss: any;
}

export const ModalContainer: React.FC<Props> = (props) => {

    const { children, personCss } = props;

    /// VARIABLES
    const OpenModalCss = `${ModalContainerCSS.containerModal} ${ModalContainerCSS["containerModal--openModal"]}`;
    const CloseModalCss = `${ModalContainerCSS.containerModal}`;

    /// HOOKS
    const storeGlobal = useGlobalContext()


    useEffect(() => {
        const $body = document.querySelector("body") as HTMLBodyElement;
        if (storeGlobal.IsShowModalContainer()) {
            // slideCarrusel();
            $body.style.overflowY = "hidden";
        } else {
            $body.style.overflowY = "scroll";
        }
    }, [storeGlobal.IsShowModalContainer()])


    return (
        <article className={`${storeGlobal.IsShowModalContainer() ? OpenModalCss : CloseModalCss} `}>
            <div>
                <article className={` ${ModalContainerCSS.contentModal} ${personCss}  `}>
                    {children}
                </article>
            </div>
        </article>
    );
};