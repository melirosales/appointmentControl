import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModalConfirmComponent } from './modal/modal-confirm/modal-confirm.component';
import { ModalErrorComponent } from './modal/modal-error/modal-error.component';
import { ModalSuccessComponent } from './modal/modal-success/modal-success.component';
import { MatDialogModule } from '@angular/material/dialog';
import { LayoutComponent } from './layout/layout.component';
import { SidebarLeftComponent } from './layout/sidebar-left/sidebar-left.component';
import { RouterModule, Routes } from '@angular/router';
const routes: Routes = [{ path: '', component: LayoutComponent }];
@NgModule({
  declarations: [ModalConfirmComponent, ModalErrorComponent, ModalSuccessComponent, LayoutComponent, SidebarLeftComponent],
  imports: [
    CommonModule,
    MatDialogModule,
    RouterModule.forChild(routes),
  ],
  entryComponents: [
    ModalConfirmComponent,
    ModalErrorComponent,
    ModalSuccessComponent,
    RouterModule
  ],
  exports: [
    LayoutComponent,
    SidebarLeftComponent,
    ModalConfirmComponent,
    ModalSuccessComponent,
    ModalErrorComponent
  ]
})
export class SharedModule { }
