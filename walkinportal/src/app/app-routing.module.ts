import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { WalkinInitialComponent } from './walkin-initial/walkin-initial.component';
const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/login' },
  {path:'walkin', component: WalkinInitialComponent },
  {path:'login',component:LoginComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
