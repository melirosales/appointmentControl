import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog'; 
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { AuthenticationService } from '@core/service/authentication.service';
import { Router } from '@angular/router';
import { LoginModel } from '@app/model/login.Model';
import { CommonService } from '@shared/services/common-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  //#region variables
  private unsubscribe$ = new Subject<void>();
  loginForm: FormGroup;
  submitted = false;
  hide = true;
  //#endregion variables

  constructor(private form: FormBuilder,
    private matDialog: MatDialog,
    private _authService: AuthenticationService,
    private _router: Router,
    private _commonService: CommonService
  ) { }

  ngOnInit(): void {
    this.loginForm = this.form.group({
      password: ["", Validators.compose([Validators.required])],
      username: ["", Validators.compose([Validators.required])]
    });
  }

  //#region methods
 
  get formVal() { return this.loginForm.controls; }
  login() {
    if (this.loginForm.invalid) {
      this.submitted = true;
    } else {
      this.submitted = false;
      debugger;
      var dataLogin={
        autentication_Password:"o99aRlb5ZXcuR6mfXyrD1g==",
        autentication_User:"MeliTecnicalTest",
        user_Name:"MeliRosales"
      }

      this._authService.loginLocalApi(dataLogin).pipe(takeUntil(this.unsubscribe$)).subscribe(
        data => {
          debugger
          var user={
            "User_Name":this.formVal.username.value,
            "Password":this.formVal.password.value,
          }

          this._commonService._loginUser(user).pipe(takeUntil(this.unsubscribe$)).subscribe(
            data => {
              debugger
              if(data.Pk_User>0){
                this._router.navigate(["dashboard"])
              }else{
                alert('Verify your password and user name.')
              }
            },
            error => {
              //this._Model._setLoading(false);
            }
          )
 
        },
        error => {
          //this._Model._setLoading(false);
        }
      )
    }
  }  
  //#endregion methods
}
