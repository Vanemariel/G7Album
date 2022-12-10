import { ChangeEvent, useState } from "react";

//Custom Hook Generico Tipado
export const useFormCustom = <TypeFormData extends Object>(
  initialState: TypeFormData
) => {
  const [formulario, setFormulario] = useState<any>(initialState);
  /* Nota: Colocamos <any> para poner hacer un arreglo de INPUTS y luego hacer 
    value={formulario[name]} ya que nos salta mil errores y no se solucionarlo (aun)
    Caso de que no se haga un array de INPUTS, quitar el <any>
  */

  const handleChange = ({
    target,
  }: ChangeEvent<HTMLInputElement>) => {
    const { name, value, files } = target;

    // En caso de cargar imagenes tb
    const imageInput = files != null && files[0];

    setFormulario({
      ...formulario,
      // [name]: value,

      // En caso de cargar imagenes tb
      [name]: imageInput ? imageInput : value,
    });
  };

  // console.log(formulario);

  const resetForm = () => setFormulario(initialState);

  return {
    ...formulario,
    formulario,
    handleChange,
    resetForm,
    setFormulario
  };
};

/* Puntos necesarios para poder utilizar este custom hooks 

1) Crear una interface que contenta todos los campos que tendra el formulario.
  Por ejem.:

  export interface IFormLogin {
    emailLogin: string;
    passwordLogin: string;
  }

2) Cuando ejecutamos nuestro custom hooks, le deberemos pasar, la interface definida
  en el paso anterior y un objeto con los valores iniciales de los campos de nuestro 
  formulario.

  Por ejem.: 
    const formularioLogin = useFormCustom<IFormLogin>({
      emailLogin: "",
      passwordLogin: "",
    });
    const { formulario, handleChange, resetForm } = formularioLogin;

  Este CustomHook nos devolvera
  - Objeto con todos los campos del formulario y sus valores.
  - Metodo HandleChange, para rellenar los valores del formulario.
  - Metodo resetForm, para resetear los valores del formulario.
  - Cada uno de los campos del formulario.
*/
