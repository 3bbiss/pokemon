import { Component, OnInit } from '@angular/core';
import { Team } from '../team';
import { TeamService } from '../team.service';

@Component({
  selector: 'app-team-test',
  templateUrl: './team-test.component.html',
  styleUrls: ['./team-test.component.css']
})
export class TeamTestComponent implements OnInit {

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

}
