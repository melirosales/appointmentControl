import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './shared/layout/layout.component';

const routes: Routes = [

  {
    path: '',
    loadChildren: () => import('./feature/login/login.module').then(m => m.LoginModule)
  },
  {

    path: '',
    component: LayoutComponent,
    children: [
      {
        path: 'dashboard',
        loadChildren: () => import('./feature/dashboard/dashboard.module').then(m => m.DashboardComponentModule)
      },
      {
        path: 'view-patient',
        loadChildren: () => import('./feature/view-patient/view-patient.module').then(m => m.ViewPatientModule)
      }
    ]
  },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
