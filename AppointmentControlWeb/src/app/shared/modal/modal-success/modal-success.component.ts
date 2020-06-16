import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-modal-success',
  templateUrl: './modal-success.component.html',
  styleUrls: ['./modal-success.component.scss']
})
export class ModalSuccessComponent implements OnInit {
 
  //#region variables 
 lbltitle: any;
  lblcontent: any;
  private unsubscribe$ = new Subject<void>();

//#endregion variables 

  constructor(@Inject(MAT_DIALOG_DATA) public dataMessage: any, public dialog: MatDialogRef<ModalSuccessComponent>) {
    if (this.dataMessage !== null && this.dataMessage !== undefined) {
      this.lbltitle = this.dataMessage.datainfo.labelTitle;
      this.lblcontent = this.dataMessage.datainfo.textDescription;
    }
  }

  ngOnInit(): void {
  }

  
//#region Methods 
   /******************************************************
  * Author: lbolanos
  * Creation date: 29/7/2019
  * Description: Method that close the modal
  *******************************************************/
  closeModal() {
    this.dialog.close();
  }
   /******************************************************
  * Author: lbolanos
  * Creation date: 29/7/2019
  * Description: Method that cancels subscriptions
  *******************************************************/
  ngOnDestroy() {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

//#endregion Methods 

}
