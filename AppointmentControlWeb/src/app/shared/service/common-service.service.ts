import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { utiles } from '@env/utiles';
import { map } from 'rxjs/operators';
import { environment } from '@env/environment';

const methodGetPatient = 'api/Patient/Get';
const methodListPatient = 'api/Patient/List';
const methodListMedicalService = 'api/MedicalService/List';
const methodSaveAppointment = 'api/AppointmentHistory/Save';
const methodListAppointment = 'api/AppointmentHistory/List';
const methodLoginUser = 'api/User/Get';

const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };

@Injectable({
  providedIn: 'root'
})
export class CommonService{

  constructor(public http: HttpClient) { }


  
  _getPatient(model: any) {
    const url =environment.apiURLStart + methodGetPatient;
    return this.http.post<any>(url, model, httpOptions)
      .pipe(map(response => {
        return response;
      }));
  }
  _listPatient(model: any) {
    const url =environment.apiURLStart + methodListPatient;
    return this.http.post<any>(url, model, httpOptions)
      .pipe(map(response => {
        return response;
      }));
  }
  _listMedicalService(model: any) {
    const url =environment.apiURLStart + methodListMedicalService;
    return this.http.post<any>(url, model, httpOptions)
      .pipe(map(response => {
        return response;
      }));
  }
  _listAppointment(model: any) {
    const url =environment.apiURLStart + methodListAppointment;
    return this.http.post<any>(url, model, httpOptions)
      .pipe(map(response => {
        return response;
      }));
  }
  _saveAppointment(model: any) {
    const url =environment.apiURLStart + methodSaveAppointment;
    return this.http.post<any>(url, model, httpOptions)
      .pipe(map(response => {
        return response;
      }));
  }
  _loginUser(model: any) {
    const url =environment.apiURLStart + methodLoginUser;
    return this.http.post<any>(url, model, httpOptions)
      .pipe(map(response => {
        return response;
      }));
  }
}
