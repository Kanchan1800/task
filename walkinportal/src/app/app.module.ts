import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { LoginHeaderComponent } from './login/login-header/login-header.component';
import { LoginMainComponent } from './login/login-main/login-main.component';
import { WalkinInitialComponent } from './walkin-initial/walkin-initial.component';
import { HttpClientModule } from '@angular/common/http';
import { WalkinInfoComponent } from './walkin-initial/walkin-info/walkin-info.component';
import { WalkinInfoRoutingModule } from './walkin-initial/walkin-info/walkin-info-routing';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    LoginHeaderComponent,
    LoginMainComponent,
    WalkinInitialComponent,
    WalkinInfoComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,HttpClientModule,WalkinInfoRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
