import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';
import { TrainerDetailComponent } from './trainer-detail/trainer-detail.component';
import { TrainerListComponent } from './trainer-list/trainer-list.component'; 

@NgModule({
  declarations: [
    AppComponent,
    TrainerDetailComponent,
    TrainerListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
