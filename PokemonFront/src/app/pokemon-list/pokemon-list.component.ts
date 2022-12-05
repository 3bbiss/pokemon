import { Component, OnInit } from '@angular/core';
import { Pokemon } from '../pokemon';
import { PokemonService } from '../pokemon.service';
import { ImageLoader } from '@angular/common';
import { PokemonDetailComponent } from '../pokemon-detail/pokemon-detail.component';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-pokemon-list',
  templateUrl: './pokemon-list.component.html',
  styleUrls: ['./pokemon-list.component.css']
})
export class PokemonListComponent implements OnInit {

  pokemonList: Pokemon[] = [];

  constructor(private PokemonSrv: PokemonService) { 
    this.refresh();
  }

  ngOnInit(): void {
  }

  refresh(){
    this.PokemonSrv.getAllPokemon(
      (result: Pokemon[]) => {
        this.pokemonList = result;
      }
    )
  };

  getPoke(pokemon_id: number) {
    this.PokemonSrv.getOnePokemon (
      () => {},
      pokemon_id
    )
    alert(pokemon_id)
  }


}
