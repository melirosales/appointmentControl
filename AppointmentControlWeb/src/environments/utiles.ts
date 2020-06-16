export class utiles {
  constructor() { }

  /************************DETALLE DE OBJETOS DE CACHE *********************
  infoSecurityUser: Get user info from Security System
  infoSecurity: Get security info from HR_CONTROL API


  ************************DETALLE DE OBJETOS DE CACHE *********************/

  /************************LIMPIEZA DEL CACHE*********************/

  static clearCache() {
    localStorage.removeItem("infoSecurityUser");
    localStorage.removeItem("infoSecurity");
  }
  /************************LIMPIEZA DEL CACHE*********************/

  /************************CREACION DEL CACHE*********************/
  static createCacheObject(name, data) {
    localStorage.setItem(name, JSON.stringify(data));
  };

  /************************CREACION DEL CACHE*********************/

  /************************OBTENER INFORMACION DEL CACHE*********************/

  static getCacheObject(name) {
    var data = localStorage.getItem(name);
    var dataObject = JSON.parse(data);

    return dataObject;
  };

  /************************OBTENER INFORMACION DEL CACHE*********************/

}