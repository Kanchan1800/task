import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CustomersModule } from './customers/customers.modules';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { CoreModule } from './core/core.module';
import { AppRoutingModule } from './app-routing.module';
import { OrdersModule } from './orders/orders.modules';
import { OrdersRoutingModule } from './orders/orders-routing.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,CustomersModule,SharedModule,CoreModule,AppRoutingModule,OrdersModule,OrdersRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
