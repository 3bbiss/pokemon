import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Team } from '../team';
import { TeamService } from '../team.service';

@Component({
  selector: 'app-add-team',
  templateUrl: './add-team.component.html',
  styleUrls: ['./add-team.component.css']
})
export class AddTeamComponent implements OnInit {
  
  newTeam: Team = {
    team_id: 0, team_name: '', trainer_id: 0,
    trainer_name: '', pokemon: []
  }

  @Output() save:EventEmitter<Team> = new EventEmitter<Team>();

  constructor() { }

  ngOnInit(): void {
  }

}
