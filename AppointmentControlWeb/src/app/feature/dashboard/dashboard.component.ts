import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Subject } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { Router, NavigationExtras } from '@angular/router';
import { CommonService } from '@shared/services/common-service.service';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  //#region variables
  private unsubscribe$ = new Subject<void>();
  loginForm: FormGroup;
  submitted = false;
  listPatient: [any];
  hide = true;
  searchPatient: string = "";
  //#endregion variables
  constructor(
    private matDialog: MatDialog,
    private _router: Router, private _commonService: CommonService) { }

  ngOnInit(): void {
 
  }

  onSearchPatient(filterSearch: string) {

    if (filterSearch.length >= 1) {
      var patient = {
        "Name": filterSearch,
      }
      this._commonService._listPatient(patient).pipe(takeUntil(this.unsubscribe$)).subscribe(
        data => {
          debugger
          this.listPatient = data;
        },
        error => {
          //this._Model._setLoading(false);
        }
      )
    }
  }


  goToViewPatient(patient:any){
    
    let navigationExtras: NavigationExtras = {
      queryParams: {
        "Patient": JSON.stringify(patient)
      },
      skipLocationChange: true
    };
    this._router.navigate(['view-patient'], navigationExtras);
  }



}
