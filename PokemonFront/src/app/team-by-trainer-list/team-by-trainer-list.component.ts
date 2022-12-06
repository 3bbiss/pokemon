import { Component, OnInit } from '@angular/core';
import { Trainer } from '../trainer';
import { TrainerService } from '../trainer.service';
import { Team } from '../team';
import { TeamService } from '../team.service';
import { Pokemon } from '../pokemon';
import { TrainerPokemon } from '../trainer-pokemon';

@Component({
  selector: 'app-team-by-trainer-list',
  templateUrl: './team-by-trainer-list.component.html',
  styleUrls: ['./team-by-trainer-list.component.css']
})
export class TeamByTrainerListComponent implements OnInit {

  trainerList: Trainer[] = []; 
  teamList: Team[] = [];

  team: Team = {
    team_id: 0, team_name: '', trainer_id: 0,
    trainer_name: '', pokemon: []
  };

  viewTeamOn: boolean = false;
  editMode: boolean = false;


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

  update(team: Team){
    this.TeamSrv.updateTeam(
      (result: Team) => {
        this.GetTrainerTeams(team.trainer_id.toString());
      },
      team
    )
    this.viewTeamOn = false;
    this.editMode = false;
  }

  delete(team: Team){
    this.TeamSrv.deleteTeam(
      () => {
        this.GetTrainerTeams(team.trainer_id.toString());
      },
      team.team_id
    )
    this.viewTeamOn = false;
    this.editMode = false;
  }

  cancel(){
    this.viewTeamOn = false;
    this.editMode = false;
  }

  updateTeamOn(id: number) {
    this.TeamSrv.getOneTeam(
      (result: Team) => {
        this.team = result;
      },

      id
    )
    this.editMode = true;
  }

  viewTeam(id: number) {
    this.TeamSrv.getOneTeam(
      (result: Team) => {
        this.team = result;
      },

      id
    )
    this.viewTeamOn = true;
  }

  getType(pokemon: TrainerPokemon){
    return 'trainerTeamPokemon ' + pokemon.type[0] + '1';
  }

  getTypeCard(pokemon: TrainerPokemon){
    return 'cardType ' + pokemon.type[0]  + '2';
  }

}
