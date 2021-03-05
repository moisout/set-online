import { Component, Input, OnInit } from '@angular/core';
import { setCard } from 'src/app/interface/set-card';

@Component({
  selector: 'app-shared-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss'],
})

export class CardComponent implements OnInit {

  @Input() card: setCard;

  constructor() {}

  ngOnInit(): void {}
}
