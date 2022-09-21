// Recortador de texto
export const cropText = (texto: string, limit: number) => {
  if (texto.length > limit) {
    return `${texto.slice(0, limit)}...`;
  } else {
    return texto;
  }
};
