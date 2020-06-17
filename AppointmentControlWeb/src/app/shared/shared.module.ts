import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { MatDialogModule } from '@angular/material/dialog';
import { LayoutComponent } from './layout/layout.component';
import { SidebarLeftComponent } from './layout/sidebar-left/sidebar-left.component';
import { RouterModule, Routes } from '@angular/router';
const routes: Routes = [{ path: '', component: LayoutComponent }];
@NgModule({
  declarations: [LayoutComponent, SidebarLeftComponent],
  imports: [
    CommonModule,
    MatDialogModule,
    RouterModule.forChild(routes),
  ],
  entryComponents: [ 
    RouterModule
  ],
  exports: [
    LayoutComponent,
    SidebarLeftComponent, 
  ]
})
export class SharedModule { }
