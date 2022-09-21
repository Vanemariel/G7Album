import React from "react";
import ButtonCSS from "./Button.module.css";

interface Props {
  method?: any;
  text?: string;
  style?: any;
}

export const Button: React.FC<Props> = (Props) => {
  // const { method, style, text, children } = Props;
  const { method, style, text } = Props;

  return (
    // <button
    //   type="submit"
    //   className={style ?? ButtonCSS.button}
    //   onClick={method}
    // >
    //   {text || children}
    // </button>
    /* ---- SIMILARES ---- */ 
    // <button
    //   type="submit"
    //   className={style ?? ButtonCSS.button}
    //   onClick={method}
    //   children={text || children}
    // />
    <p>sad</p>
  );
};
