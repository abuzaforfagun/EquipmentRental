import { CartService } from './services/cart.service';
import { AuthService } from './services/auth.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NavBarComponent } from './shared/nav-bar/nav-bar.component';
import { HttpService } from './services/http.service';
import { EquipmentService } from './services/equipment.service';
import { HttpClientModule } from '@angular/common/http';
import { EquipmentTableComponent } from './shared/equipment-table/equipment-table.component';
import { EquipmentAddCartComponent } from './shared/equipment-add-cart/equipment-add-cart.component';
import { NoopAnimationsModule, BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CheckoutComponent } from './checkout/checkout.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DashboardComponent,
    NavBarComponent,
    EquipmentTableComponent,
    EquipmentAddCartComponent,
    CheckoutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NoopAnimationsModule
  ],
  providers: [
    AuthService,
    HttpService,
    EquipmentService,
    CartService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
