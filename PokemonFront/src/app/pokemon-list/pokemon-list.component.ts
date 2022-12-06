import { Component, OnInit } from '@angular/core';
import { Pokemon } from '../pokemon';
import { PokemonService } from '../pokemon.service';
import { Move } from "../move";
import { PokemonSprites } from "../pokemon-sprites";
import { SpeciesName } from "../species-name";
import { Stats } from "../stats";
import { Type } from "../type";

@Component({
  selector: 'app-pokemon-list',
  templateUrl: './pokemon-list.component.html',
  styleUrls: ['./pokemon-list.component.css']
})
export class PokemonListComponent implements OnInit {

  showdetails: boolean = false;
  
  movelist: Move[] = [];
  statlist: Stats[] = [];
  typelist: Type[] = [];
  sprites: PokemonSprites = {front_default: "", front_shiny: "", front_female: "", front_shiny_female: ""};
  species: SpeciesName = {name: "", url: ""}

  pokemon: Pokemon = {
    id: 0,
      name: "",
      height: 0,
      is_default: true,
      order: 0,
      weight: 0,
      moves: this.movelist,
      sprites: this.sprites,
      species: this.species,
      stats: this.statlist, 
      types: this.typelist
   }

  

  pokemonList: Pokemon[] = [];
  closeResult: string = '';

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


 showPoke(pokemon_id: number) {
    this.PokemonSrv.getOnePokemon (
      (result: Pokemon) => {
        this.pokemon = result;
      },
      pokemon_id
    )
    this.showdetails = true;
  };

  previous(pokemon_id: number) {
    this.PokemonSrv.getOnePokemon (
      (result: Pokemon) => {
        this.pokemon = result;
      },
      pokemon_id -1
    )
  };

  next(pokemon_id: number) {
    this.PokemonSrv.getOnePokemon (
      (result: Pokemon) => {
        this.pokemon = result;
      },
      pokemon_id +1
    )
  };

  cancel() {
    this.showdetails = false;
  };

  getTypes(pokemon: Pokemon) {
    return 
  };
}
