import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WalkinInitialComponent } from './walkin-initial.component';

const routes: Routes = [
  { path: 'walkin', component: WalkinInitialComponent }
];

@NgModule({
    imports: [ RouterModule.forChild(routes) ],
    exports: [ RouterModule ]
})
export class DashboardRoutingModule {

}
