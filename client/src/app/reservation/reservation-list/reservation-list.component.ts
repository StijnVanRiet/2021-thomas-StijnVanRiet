import { Component, OnInit } from '@angular/core';
import { Reservation } from '../reservation.model';
import { ReservationDataService } from '../reservation-data.service';

@Component({
  selector: 'app-reservation-list',
  templateUrl: './reservation-list.component.html',
  styleUrls: ['./reservation-list.component.css']
})
export class ReservationListComponent implements OnInit {
  constructor(private _reservationDataService: ReservationDataService) { }

  get reservations(): Reservation[]{
    return this._reservationDataService.reservations;
  }

  ngOnInit(): void {}

  addNewReservation(reservation) {
    this._reservationDataService.addNewReservation(reservation);
  }
}
