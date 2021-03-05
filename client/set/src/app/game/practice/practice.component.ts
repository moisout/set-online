import { Component, OnInit } from '@angular/core';
import { setCard } from 'src/app/interface/set-card';

@Component({
  selector: 'app-practice',
  templateUrl: './practice.component.html',
  styleUrls: ['./practice.component.scss']
})
export class PracticeComponent implements OnInit {

  cardArray: Array<setCard> = [
    {
      id: 1,
      color: 'Red',
      symbol: 'Squiggle',
      shading: 'Striped',
      number: 1,
    },
    {
      id: 2,
      color: 'Blue',
      symbol: 'Squiggle',
      shading: 'Solid',
      number: 2,
    },
    {
      id: 3,
      color: 'Green',
      symbol: 'Diamond',
      shading: 'Open',
      number: 3,
    },
    {
      id: 4,
      color: 'Blue',
      symbol: 'Diamond',
      shading: 'Solid',
      number: 1,
    },
  ];

  constructor() { }

  Cards: Array<setCard>;
  SelectedCards: Array<number>;
  PossibleCombinations: Array<Array<number>>;
  FoundCombinations: Array<Array<number>>;

  ngOnInit(): void {
    // this.resetGame();
  }


  onCardClick(cardId: number): void {
    this.SelectedCards.push(cardId);

    if (this.SelectedCards.length === 3) {
      this.checkSelection();
    }
  }

  checkSelection(): void {
    const indexOfValidated = this.PossibleCombinations.findIndex(possible =>
      possible.sort().toString() === this.SelectedCards.sort().toString()
    );
    if (indexOfValidated !== -1) {
      this.FoundCombinations.push(this.PossibleCombinations[indexOfValidated]);
      this.PossibleCombinations.splice(indexOfValidated, 1);

      if (!this.PossibleCombinations.length) {
        // Win-Message
        setTimeout(() => {
          this.resetGame();
        }, 5000);
        return;
      }

      this.SelectedCards = [];
      // Set found!
    }
    else {
      this.SelectedCards = [];
      // Set not found!
    }
  }

  resetGame(): void {
    this.SelectedCards = [];
    this.FoundCombinations = [];
    this.PossibleCombinations = []; // ServiceToCall for possible
    this.Cards = []; // ServiceToCall for Cards
  }
}
