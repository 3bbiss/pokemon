import { Component, OnInit } from '@angular/core';
import { Trainer } from '../trainer';
import { TrainerService } from '../trainer.service';
import { Team } from '../team';
import { TeamService } from '../team.service';
import { Pokemon } from '../pokemon';

@Component({
  selector: 'app-team-by-trainer-list',
  templateUrl: './team-by-trainer-list.component.html',
  styleUrls: ['./team-by-trainer-list.component.css']
})
export class TeamByTrainerListComponent implements OnInit {

  trainerList: Trainer[] = []; 
  teamList: Team[] = [];


  constructor(private TrainerSrv: TrainerService, private TeamSrv: TeamService) { 
    TrainerSrv.getAllTrainers(
      (result: Trainer[]) => {
        this.trainerList = result;
        this.GetTrainerTeams(this.trainerList[0].id.toString());
      }
    );
  }

  GetTrainerTeams(id: string){
    this.TeamSrv.getAllTeamsbyTrainer(
      (result: Team[]) => {
        this.teamList = result;
      },
      parseInt(id)
    )
  }

  ngOnInit(): void {
  }

}
