import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Trainer } from '../trainer';
import { TrainerService } from '../trainer.service';

@Component({
  selector: 'app-trainer-detail',
  templateUrl: './trainer-detail.component.html',
  styleUrls: ['./trainer-detail.component.css']
})
export class TrainerDetailComponent implements OnInit {

  @Input() trainer: Trainer = {id: 0, name: '', email: ''};

  @Output() delete: EventEmitter<number> = new EventEmitter<number>();

  deleteMe(){
    this.delete.emit(this.trainer.id);
  }

  constructor() { }

  ngOnInit(): void {
  }

}
