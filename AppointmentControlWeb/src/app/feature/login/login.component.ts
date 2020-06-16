import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ModalConfirmComponent } from '@shared/modal/modal-confirm/modal-confirm.component';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { AuthenticationService } from '@core/service/authentication.service';
import { Router } from '@angular/router';
import { LoginModel } from '@app/model/login.Model';

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
    private _router: Router
  ) { }

  ngOnInit(): void {
    this.loginForm = this.form.group({
      password: ["", Validators.compose([Validators.required])],
      username: ["", Validators.compose([Validators.required])]
    });
  }

  //#region methods
 
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
          this._router.navigate(["dashboard"])
        },
        error => {
          //this._Model._setLoading(false);
        }
      )
    }
  } 
  openDialogConfirm() {
    const datainfo = {
      labelTitile: 'Información',
      textDescription: "Revisa tu correo electrónico para continuar con el proceso de recuperación de la contraseña?",
    };
    const dialogRef = this.matDialog.open(ModalConfirmComponent, {
      data: { datainfo },
      panelClass: 'modal-confirm',

    });
    const refresh = dialogRef.componentInstance.refreshAccount.subscribe((data) => {

      if (data) {
      }
      else {
      }
    });
    dialogRef.afterClosed().subscribe(
      () => {
        refresh.unsubscribe();
      }
    );
  }
  //#endregion methods
}
