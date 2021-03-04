import { Component, OnInit, Input } from '@angular/core';
import { setCard } from 'src/app/interface/set-card';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss'],
})
export class CardComponent implements OnInit {
  constructor() {}

  @Input() card: setCard = {
    id: 1,
    properties: {
      color: 'round',
      shape: 'red',
      amount: 1,
      filling: 'striped',
    },
  };

  ngOnInit(): void {}
}
