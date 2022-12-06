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

  // not currently working? But want it to refresh list of trainers automatically when returned to trainer
  // route after adding a trainer. Not currently happening I don't think.

  
  // AA 12/5/2022 8:22 PM -- added so that the list of trainers automatically refreshed when routed back to
  // the trainer route after user adds a trainer.  Can't tell if it's working because it seems to sometimes, and
  // not others? Working as of now tho it seems.
  refresh(){
    this.TrainerSrv.getAllTrainers(
      (result: Trainer[]) => {
        this.TheTrainers = result;
      }
    )
  }

  save(trainer: Trainer){
    this.TrainerSrv.addTrainer(
      () => {},
      trainer
      );
      // this.refresh(); Moved this line to the constructor.
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
    this.refresh();
   }

  ngOnInit(): void {
  }

}
