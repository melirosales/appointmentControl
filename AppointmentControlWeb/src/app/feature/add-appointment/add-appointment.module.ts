import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDatepickerModule } from '@angular/material/datepicker';  
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { MatFormFieldModule } from '@angular/material/form-field'; 
import { MatInputModule } from '@angular/material/input';
import {MatButtonToggleModule} from '@angular/material/button-toggle'; 
import { MatNativeDateModule } from '@angular/material/core'; 
import { AddAppointmentComponent } from './add-appointment.component';
import { MatSelectModule } from '@angular/material/select';

const routes: Routes = [{ path: '', component: AddAppointmentComponent }];


@NgModule({
  declarations: [AddAppointmentComponent],
  imports: [
    RouterModule.forChild(routes),
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatButtonToggleModule,
    NgxMaterialTimepickerModule,
    MatInputModule,
    MatNativeDateModule,
    MatDatepickerModule ,
    MatSelectModule, 
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [MatDatepickerModule]
})
export class AddAppointmentModule { }
