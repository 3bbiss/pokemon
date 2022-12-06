import { Component, OnInit } from '@angular/core';
import { Pokemon } from '../pokemon';
import { PokemonService } from '../pokemon.service';
import { ImageLoader } from '@angular/common';

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
  }

}
