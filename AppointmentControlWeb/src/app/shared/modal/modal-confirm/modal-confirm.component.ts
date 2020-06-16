import { Component, OnInit, Inject, EventEmitter } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-modal-confirm',
  templateUrl: './modal-confirm.component.html',
  styleUrls: ['./modal-confirm.component.scss']
})
export class ModalConfirmComponent implements OnInit {

  //#region variables 
  lbltitle: any;
  lblcontent: any;
  private unsubscribe$ = new Subject<void>();
  refreshAccount = new EventEmitter();
  //#endregion variables 

  constructor(@Inject(MAT_DIALOG_DATA) public dataMessage: any, public dialog: MatDialogRef<ModalConfirmComponent>) {
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


  accept(){
    this.refreshAccount.emit(true);
    this.dialog.close(); 
  }

  /******************************************************
 * Author: lbolanos
 * Creation date: 29/7/2020
 * Description: Method that cancels subscriptions
 *******************************************************/
  ngOnDestroy() {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

  //#endregion Methods 


}
