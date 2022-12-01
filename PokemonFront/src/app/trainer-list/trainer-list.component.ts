import { Component, OnInit } from '@angular/core';
import { Trainer } from '../trainer';
import { TrainerService } from '../trainer.service';

@Component({
  selector: 'app-trainer-list',
  templateUrl: './trainer-list.component.html',
  styleUrls: ['./trainer-list.component.css']
})
export class TrainerListComponent implements OnInit {

  trainerList: Trainer[] = [];

  constructor(private TrainerSrv: TrainerService) { 
    this.refresh();
  }

  refresh(){
    this.TrainerSrv.getAllTrainers(
      (result: Trainer[]) => {
        this.trainerList = result;
      }
    )
  }

  ngOnInit(): void {
  }

}