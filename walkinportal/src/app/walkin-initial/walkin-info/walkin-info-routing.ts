import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WalkinInfoComponent } from './walkin-info.component';
const routes: Routes = [
    { path: 'walkin/:id', component: WalkinInfoComponent }
];

@NgModule({
    imports: [ RouterModule.forChild(routes) ],
    exports: [ RouterModule ]
})
export class WalkinInfoRoutingModule {

}
