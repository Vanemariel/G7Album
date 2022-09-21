import LoaderCSS from "./Loader.module.css";


export const Loader = () => {
  return (
    <div className={LoaderCSS.backgroundSpinner}>
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
        <h3> Espere por favor...</h3>
      </div>
    </div>
  );
};
