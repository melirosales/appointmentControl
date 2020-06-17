import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonService } from '@shared/services/common-service.service';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';  
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-view-patient',
  templateUrl: './view-patient.component.html',
  styleUrls: ['./view-patient.component.scss']
})
export class ViewPatientComponent implements OnInit {
  patientInfo: any; 
  appointmentList:[];
  fk_patient: number = 0;
  private unsubscribe$ = new Subject<void>();
  constructor(private activated_router: ActivatedRoute , private _commonService: CommonService,public dialog: MatDialog) { }

  ngOnInit(): void {
 
    this.activated_router.queryParams.subscribe(params => {
      this.patientInfo = JSON.parse(params["Patient"]);
      this.fk_patient = this.patientInfo.Pk_Patient;
    });
    this.getAppointmentList();
  }
 

  onCancel(param) { 
    var appointment = {
      "Pk_Appointment_History": Number(param.Pk_Appointment_History),
      "Fk_Patient": Number(this.fk_patient), 
      "Option":1
    }
    console.log(appointment);
    this._commonService._saveAppointment(appointment).pipe(takeUntil(this.unsubscribe$)).subscribe(
      data => {
        alert('Appointment was cancel successfully') 
        this.getAppointmentList()
      },
      error => {
        //this._Model._setLoading(false);
      }
    )
  }

 
  getAppointmentList() {

    var param = { 
      "Fk_Patient": Number(this.fk_patient), 
    }
    this._commonService._listAppointment(param).pipe(takeUntil(this.unsubscribe$)).subscribe(
      data => {
         
        this.appointmentList = data;
        console.log(data)
       
      },
      error => {
        //this._Model._setLoading(false);
      }
    )
  }


}

