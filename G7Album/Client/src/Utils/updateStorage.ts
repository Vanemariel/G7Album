export const updateStorage = <TypeStorage extends Object>(
  nameStorage: string,
  datesStorage: TypeStorage
): void => {
  //Cambiar nombre por el que sea en la circunstancia.
  localStorage.setItem(nameStorage, JSON.stringify(datesStorage));
};

export const getStorage = <TypeStorage>(nameStorage: string) => {
    return JSON.parse(localStorage.getItem(nameStorage) as any) as TypeStorage;
};


export const deleteStorage = (nameStorage: string) => {
  localStorage.removeItem(nameStorage);
}