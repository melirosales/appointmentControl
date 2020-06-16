import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonService } from '@shared/services/common-service.service';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-view-patient',
  templateUrl: './view-patient.component.html',
  styleUrls: ['./view-patient.component.scss']
})
export class ViewPatientComponent implements OnInit {
patientInfo:any;
medicalService:any;
private unsubscribe$ = new Subject<void>();
  constructor(private activated_router: ActivatedRoute, private _commonService: CommonService) { }

  ngOnInit(): void {
    
    this.activated_router.queryParams.subscribe(params => {
      this.patientInfo =JSON.parse(params["Patient"]); 
      console.log( this.patientInfo)
    });
    this.getMedicalServiceList();
  }

  onSave(filterSearch: string) {
 
      var patient = {
        "Name": filterSearch,
      }
      this._commonService._listPatient(patient).pipe(takeUntil(this.unsubscribe$)).subscribe(
        data => { 
          this.medicalService=data;
        },
        error => {
          //this._Model._setLoading(false);
        }
      ) 
  }

  
  getMedicalServiceList() {
  
      this._commonService._listMedicalService(null).pipe(takeUntil(this.unsubscribe$)).subscribe(
        data => { 
         this.medicalService=data;
        },
        error => {
          //this._Model._setLoading(false);
        }
      ) 
  }


}
