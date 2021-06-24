import { Component, OnInit } from '@angular/core';
import { RESERVATIONS } from '../mock-reservationss';

@Component({
  selector: 'app-reservation-list',
  templateUrl: './reservation-list.component.html',
  styleUrls: ['./reservation-list.component.css']
})
export class ReservationListComponent implements OnInit {
  private _reservations = RESERVATIONS;

  constructor() { }

  get reservations() {
    return this._reservations;
  }

  ngOnInit(): void {}

}
