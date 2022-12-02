import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TeamListComponent } from './team-list/team-list.component';
import { AddTeamComponent } from './add-team/add-team.component';

import { TrainerDetailComponent } from './trainer-detail/trainer-detail.component';
import { TrainerListComponent } from './trainer-list/trainer-list.component';
import { PokemonListComponent } from './pokemon-list/pokemon-list.component'; 

@NgModule({
  declarations: [
    AppComponent,
    TrainerDetailComponent,
    TrainerListComponent,
    TeamListComponent,
    AddTeamComponent,
    PokemonListComponent

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
