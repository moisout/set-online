import { Component, OnInit, Input } from '@angular/core';
import { setCard } from 'src/app/interface/set-card';

@Component({
  selector: 'shared-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss'],
})

export class CardComponent implements OnInit {

  @Input() card: setCard;

  constructor() {}

  ngOnInit(): void {}

  public cardClicked() {
    console.warn('cko:', this.card.id);
  }
}
