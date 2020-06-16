import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ModalSuccessComponent } from '@shared/modal/modal-success/modal-success.component';

@Injectable({
  providedIn: 'root'
})
export class SuccessDialogService {

  constructor(public matDialog: MatDialog, private router: Router) { }

  _openDialogSuccess(data): void {

    const datainfo = {
      labelTitle: data.title,
      textDescription: data.description
    };

    const dialogRef = this.matDialog.open(ModalSuccessComponent, {
      data: { datainfo },
      panelClass: 'modal-success',
    });
    setTimeout(() => dialogRef.close(), 3000);

  }

}
