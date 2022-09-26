import React, { useEffect, useState } from "react";
import InputCSS from "./Input.module.css";
import { IInputs } from "./Inputs.interface";

interface Props {
  handleChange: any;
  inputProps: IInputs;
  value: string | any;
  errorMessage: string;
  pattern: RegExp;
  key?: number;
}

export const Input: React.FC<Props> = (props) => {
  const {
    inputProps,
    handleChange,
    value,
    errorMessage,
    pattern,
  } = props;

  /* Para utilizar este componente, hace falta utilizar Font Awesome,
      <link
      rel="stylesheet"
      href="https://use.fontawesome.com/releases/v5.15.1/css/all.css"
      integrity="sha384-vp86vTRFVJgpjF9jiIGPEEqYqlDwgyBgEF109VFjmqGmIY/Y4HV4d3Gp2irVfcrp"
      crossorigin="anonymous"
    />*/
  const IconFormClass = `${InputCSS.contact__form__iconValidate} fas fa-times-circle`;

  /// METODOS
  const validateInput = () => {

    const $iconInput = document.querySelector(
      `#form__${inputProps["name"]} i`
    ) as HTMLElement;
    const $formError = document.querySelector(
      `#form__${inputProps["name"]} p`
    ) as HTMLElement;

    if (pattern.exec(value)) {
      //Cambiamos el color del icono a VERDE
      $iconInput.classList.remove(
        `${InputCSS.iconValidate_incorrect}`
      );
      $iconInput.classList.add(`${InputCSS.iconValidate_correct}`);

      //Cambiamos el icono de la X al icono valido
      $iconInput.classList.add("fa-check-circle");
      $iconInput.classList.remove("fa-times-circle");

      //Quitamos la clase para que no aparezca el mensaje de error
      $formError.classList.remove(
        `${InputCSS.contact_messageErrorActive}`
      );

    } else {
      //Cambiamos el color del icono a incorrecto(rojo)
      $iconInput.classList.add(`${InputCSS.iconValidate_incorrect}`);
      $iconInput.classList.remove(`${InputCSS.iconValidate_correct}`);

      //Cambiamos el icono de valido a la X
      $iconInput.classList.remove("fa-check-circle");
      $iconInput.classList.add("fa-times-circle");

      //Agregamos la clase para que aparezca el mensaje de error
      $formError.classList.add(
        `${InputCSS.contact_messageErrorActive}`
      );
    }
    
    verifyisValueBlank(value);
  };

  const verifyisValueBlank = (value: any) => {
    const $iconInput = document.querySelector(
      `#form__${inputProps["name"]} i`
    ) as HTMLElement;
    const $formError = document.querySelector(
      `#form__${inputProps["name"]} p`
    ) as HTMLElement;

    if (value === "") {
      //Quitamos el icono en cuestion
      $iconInput.classList.remove("fa-check-circle");
      $iconInput.classList.remove("fa-times-circle");

      //Quitamos la clase para que no aparezca el mensaje de error
      $formError.classList.remove(
        `${InputCSS.contact_messageErrorActive}`
      );
    }
  };

  useEffect(() => {
    verifyisValueBlank(value);

    //console.log("LALALA", props)
  }, [value]);

  return (
    <div id={`form__${inputProps["name"]}`}>
      {
        <div className={InputCSS.contact__form__inputs}>
          <input
            name={inputProps["name"]}
            placeholder={inputProps.placeholder}
            type={inputProps.type}
            value={value}
            onChange={handleChange}
            onKeyUp={validateInput}
            required
            autoComplete="off"
          />
          <i className={IconFormClass} />
        </div>
      }

      <p className={InputCSS.contact_messageError}>{errorMessage}</p>
    </div>
  );
};

/* Puntos necesarios para poder utilizar este Componente 

  Necesitaremos pasarle
  - Value: Un state para poder obtener el valor del input 
  - handleChange: el setState del useState();
  - expReg: Una expresion regular para que pueda validar 
    lo que se escribe.
  - errorMessage: Un mensaje de error para cuando estemos escribiendo
    algo que no debamos.
  - inputProps: Un objeto que contenga
      * type=""
      * placeholder=""
      * name=""
    Con sus respectivos valores dependiendo del Input.

  La interface de esto seria:
  export interface IFormInputs {
    placeholder: string;
    type: any;
    name: string;
    expReg: RegExp;
    errorMessage: string;
  }
  
  Por ejem.:

  const [inputText, setInputText] = useState("")
  const propsInput = {
    placeholder: "Correo electronico: ",
    type: "email",
    name: "emailLogin",
    expReg: /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/i,
    errorMessage:
      "El correo solo puede contener letras, numeros, puntos, guiones y guion bajo.",
  },

  <Input
    inputProps={propsInput}
    value={inputText}
    handleChange={setInputText}
    errorMessage={propsInput.errorMessage}
    expReg={propsInput.expReg}
  />
*/
