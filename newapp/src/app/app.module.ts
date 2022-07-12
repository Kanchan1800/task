import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HeaderComponent } from './dashboard/header/header.component';
import { FooterComponent } from './dashboard/footer/footer.component';
import { CoreModule } from './core/core.module';
import { TabsComponent } from './dashboard/tabs/tabs.component';
import { FilterComponent } from './dashboard/filter/filter.component';
import { CardsmainComponent } from './dashboard/cardsmain/cardsmain.component';
import { CardfilterComponent } from './dashboard/cardsmain/cardfilter/cardfilter.component';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { LoginHeaderComponent } from './login/login-header/login-header.component';
import { LoginMainComponent } from './login/login-main/login-main.component';
import { DashboardRoutingModule } from './dashboard/dashboard-routing.module';
import { LoginRoutingModule } from './login/login-routing.module';
import { ContentComponent } from './content/content.component';
import { ContentRoutingModule } from './content/content-routing.module';
@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    HeaderComponent,
    FooterComponent,
    TabsComponent,
    FilterComponent,
    CardsmainComponent,
    CardfilterComponent,
    LoginComponent,
    LoginHeaderComponent,
    LoginMainComponent,
    ContentComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,CoreModule,FormsModule,LoginRoutingModule,DashboardRoutingModule,ContentRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
