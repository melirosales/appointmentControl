import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subject } from 'rxjs';


@Component({
  selector: 'app-modal-error',
  templateUrl: './modal-error.component.html',
  styleUrls: ['./modal-error.component.scss']
})
export class ModalErrorComponent implements OnInit {

  //#region variables 
  lbltitle: any;
  lblcontent: any;
  private unsubscribe$ = new Subject<void>();

  //#endregion variables 

  constructor(@Inject(MAT_DIALOG_DATA) public dataMessage: any, public dialog: MatDialogRef<ModalErrorComponent>) {
    if (this.dataMessage !== null && this.dataMessage !== undefined) {
      this.lbltitle = this.dataMessage.datainfo.labelTitile;
      this.lblcontent = this.dataMessage.datainfo.textDescription;
    }
  }

  ngOnInit(): void {
  }
  //#region Methods 
  /******************************************************
* Author: lbolanos
* Creation date: 29/7/2020
* Description: Method that close the modal
*******************************************************/
  closeModal() {
    this.dialog.close();
  }
  /******************************************************
 * Author: lbolanos
 * Creation date: 29/7/220
 * Description: Method that cancels subscriptions
 *******************************************************/
  ngOnDestroy() {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

  //#endregion Methods 


}
