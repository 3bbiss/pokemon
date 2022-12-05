import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Trainer } from '../trainer';
import { TrainerService } from '../trainer.service';

@Component({
  selector: 'app-add-trainer',
  templateUrl: './add-trainer.component.html',
  styleUrls: ['./add-trainer.component.css']
})
export class AddTrainerComponent implements OnInit {
  
  TheTrainers: Trainer[] = [];

  newTrainer: Trainer = {id: 0, name: '', email: ''};

  //@Output() save: EventEmitter<Trainer> = new EventEmitter<Trainer>();

  save(trainer: Trainer){
    this.TrainerSrv.addTrainer(
      () => {},
      trainer
      );
  }

  /*saveTrainer(){
    this.save.emit(this.newTrainer);
    this.newTrainer.name = ''; // to clear out name field after saving
    this.newTrainer.email = ''; // to clear out email field after saving
  }*/

  constructor(private TrainerSrv: TrainerService) {
    TrainerSrv.getAllTrainers(
      (result: Trainer[]) => {
        this.TheTrainers = result;
      }
    );
   }

  ngOnInit(): void {
  }

}
