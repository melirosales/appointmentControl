import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { utiles } from 'environments/utiles';
import { CommonService } from '../service/common-service.service';

@Injectable({
  providedIn: 'root'
})
export class ErrorDialogService {

  constructor(public matDialog: MatDialog, private router: Router, private _common: CommonService) { }

  _openDialog(data): void {

    const datainfo = {
      labelTitile: 'Error',
      icon: 'cancel',
      textDescription: (data.error == null) ? '' : (data.error.Message) ? data.error.Message : data.error,
      status: 'error'
    };

    console.log(data); 
    if (data.status !== 0 && data.status !== 401) {
      alert((data.error == null) ? '' : (data.error.Message) ? data.error.Message : data.error)
    } else if (data.status == 0) {

      alert('Conection lost')
      utiles.clearCache();
      this.router.navigate(['login']);


      setTimeout(() => this.matDialog.closeAll(), 3000);

    } else if (data.status == 401) { 
      alert('Not authorized')
      this.router.navigate(['login']);

    }

  }

}
