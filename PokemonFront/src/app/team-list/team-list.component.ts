import { Component, OnInit } from '@angular/core';
import { Team } from '../team';
import { TeamService } from '../team.service';

@Component({
  selector: 'app-team-list',
  templateUrl: './team-list.component.html',
  styleUrls: ['./team-list.component.css']
})
export class TeamListComponent implements OnInit {

  teamList: Team[] = [];
  
  constructor(private TeamSrv: TeamService) { 
    this.refresh();
  }

  refresh(){
    this.TeamSrv.getAllTeams(
      (result: Team[]) => {
        this.teamList = result;
      }
    )
  }

  ngOnInit(): void {
  }

  save(team: Team){
    this.TeamSrv.addTeam(
      (result: Team) => {
        this.refresh();
      },
      team
    );
  }
}
