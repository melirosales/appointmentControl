import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonService } from '@shared/services/common-service.service';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { FormGroup, FormBuilder, Validators } from '@angular/forms'; 
import { MatDialog } from '@angular/material/dialog';
@Component({
  selector: 'app-add-appointment',
  templateUrl: './add-appointment.component.html',
  styleUrls: ['./add-appointment.component.scss']
})
export class AddAppointmentComponent implements OnInit {
  patientInfo: any;
  medicalService: [];
  appointmentForm: FormGroup;
  fk_medical_service: number = 0;
  fk_patient: number = 0;
  date: any;
  hour: any;
  private unsubscribe$ = new Subject<void>();
  constructor(private activated_router: ActivatedRoute, private fb: FormBuilder, private _commonService: CommonService, public dialog: MatDialog) { }

  ngOnInit(): void {

    this.appointmentForm = this.fb.group({
      Fk_Medical_Service: [0, [Validators.required]],
      Date: ['', [Validators.required]],
      Hour: ['', [Validators.required]]
    });
    this.activated_router.queryParams.subscribe(params => {
      this.patientInfo = JSON.parse(params["Patient"]);
      this.fk_patient = this.patientInfo.Pk_Patient;
      console.log(this.patientInfo)
    });
    this.getMedicalServiceList();
  }

  get form() { return this.appointmentForm.controls; }

  onSave() {

    var appointment = {
      "Fk_Medical_Service": Number(this.form.Fk_Medical_Service.value),
      "Fk_Patient": Number(this.fk_patient),
      "Date": this.form.Date.value,
      "Hour": this.form.Hour.value,
      "Option": 0
    }
    console.log(appointment);
    this._commonService._saveAppointment(appointment).pipe(takeUntil(this.unsubscribe$)).subscribe(
      data => {
        this.medicalService = data;
        alert('Appointment was saved successfully')
      },
      error => {
        //this._Model._setLoading(false);
      }
    )
  }


  selectMedicalService(fk_medical_service) {
    debugger
    this.fk_medical_service = fk_medical_service;
  }
  getMedicalServiceList() {

    this._commonService._listMedicalService(null).pipe(takeUntil(this.unsubscribe$)).subscribe(
      data => {
        this.medicalService = data;
      },
      error => {
        //this._Model._setLoading(false);
      }
    )
  }


}
