import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from '@env/environment';
import { utiles } from '@env/utiles';

const methodApi = 'token/token';
const methodGetRolScreenActions = 'api/RolScreenAction/List';
const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };

@Injectable()
export class AuthenticationService {

  constructor(private http: HttpClient) { }

  loginLocalApi(loginData: any) {

    let url =environment.apiURLStart +'api/Token/Token' ;

    let data = {
      Password_Autenticacion: loginData.autentication_Password,
      Usuario_Autenticacion: loginData.autentication_User,
      userName: loginData.user_Name
    }
    return this.http.post<any>(url, data, httpOptions)
      .pipe(map(user => {
        // store user details and jwt token in local storage to keep user logged in between page refreshes
        utiles.createCacheObject("infoSecurity", user);
        return user;
      }));
  }

}
