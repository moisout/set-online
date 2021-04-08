import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { setCard } from 'src/app/interface/set-card';
import { PracticeService } from 'src/app/service/practice.service';

@Component({
  selector: 'app-practice',
  templateUrl: './practice.component.html',
  styleUrls: ['./practice.component.scss'],
})
export class PracticeComponent implements OnInit {
  cardArray: Array<setCard> = [];

  constructor(private practiceService: PracticeService, private toastr: ToastrService) {}

  cards: Array<setCard>;
  selectedCards: Array<number>;
  possibleSets: Array<Array<number>>;
  foundCombinations: Array<Array<number>>;

  ngOnInit(): void {
    this.resetGame();
  }

  isSelectedCard(cardId: number): boolean {
    return this.selectedCards.some((e) => e === cardId);
  }

  onCardClick(cardId: number): void {
    const selectedIndex = this.selectedCards.indexOf(cardId);
    if (selectedIndex !== -1) {
      this.selectedCards.splice(selectedIndex, 1);
    } else {
      this.selectedCards.push(cardId);

      if (this.selectedCards.length === 3) {
        this.checkSelection();
      }
    }
  }

  checkSelection(): void {
    const indexOfValidated = this.possibleSets.findIndex(
      (possible) =>
        possible.sort().toString() === this.selectedCards.sort().toString()
    );
    if (indexOfValidated !== -1) {
      this.foundCombinations.push(this.possibleSets[indexOfValidated]);
      this.possibleSets.splice(indexOfValidated, 1);

      if (!this.possibleSets.length) {
        this.toastr.success('Nice', 'Du hast alle Sets gefunden! Setze Spiel zurück', {timeOut: 2000});
        setTimeout(() => {
          this.resetGame();
        }, 5000);
        return;
      }

      this.selectedCards = [];
      this.toastr.success('Top', 'Set gefunden', {timeOut: 1000});
    } else {
      this.selectedCards = [];
      this.toastr.error('Nope', 'Kein Set gefunden', {timeOut: 1000});
    }
  }

  resetGame(): void {
    this.selectedCards = [];
    this.foundCombinations = [];
    this.practiceService.getPracticeTable().subscribe((result) => {
      this.possibleSets = result.possibleSets;
      this.cards = result.cards;
    });
  }
}
