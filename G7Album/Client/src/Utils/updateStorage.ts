export const updateStorage = <TypeStorage extends Object>(
  nameStorage: string,
  datesStorage: TypeStorage
) => {
  //Cambiar nombre por el que sea en la circunstancia.
  localStorage.setItem(nameStorage, JSON.stringify(datesStorage));
};

export const getStorage = (nameStorage: string) => {
  return JSON.parse(localStorage.getItem(nameStorage) as any);
};
