import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { utiles } from 'environments/utiles';
import { ModalErrorComponent } from '@shared/modal/modal-error/modal-error.component';
//import { ModalLoginComponent } from '@shared/modal/modalLogin/modallogin.component';
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

    if (data.status !== 0 && data.status !== 401) {
      const dialogRef = this.matDialog.open(ModalErrorComponent, {
        data: { datainfo: datainfo },
        panelClass: 'modal-error',
      });
      setTimeout(() => dialogRef.close(), 3000);

    } else if (data.status == 0) {

      datainfo.textDescription = "Se ha perdido la conexión con el servidor.";
      utiles.clearCache();
      this.router.navigate(['login']);

      const dialogRef = this.matDialog.open(ModalErrorComponent, {
        data: { datainfo: datainfo },
        panelClass: 'modal-error',
      });

      setTimeout(() => this.matDialog.closeAll(), 3000);

    } else if (data.status == 401) {
      // //this._common._setLoading(false);
      // const dialogRef = this.matDialog.open(ModalLoginComponent, {
      //   minWidth: '680px', maxWidth: '680px', maxHeight: '350px', minHeight: '350px', disableClose: true
      // });
      // dialogRef.afterClosed().subscribe(result => {
      //   this.matDialog.closeAll();
      //});
      alert('no esta autorizado')

    }

  }
  
}
