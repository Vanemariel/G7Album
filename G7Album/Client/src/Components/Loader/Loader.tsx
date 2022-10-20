import { useEffect } from "react";
import { useGlobalContext } from "../../Context/useGlobalContext";
import LoaderCSS from "./Loader.module.css";


export const Loader: React.FC = () => {


    return (

        <div className={LoaderCSS.containerPage}>
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