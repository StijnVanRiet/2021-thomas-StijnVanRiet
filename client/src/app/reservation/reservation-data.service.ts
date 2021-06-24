import { Injectable } from '@angular/core';
import { RESERVATIONS } from './mock-reservationss';
import { Reservation } from './reservation.model';

@Injectable({
  providedIn: 'root'
})
export class ReservationDataService {
  private _reservations = RESERVATIONS;
  constructor() { }

  get reservations(): Reservation[] {
    return this._reservations;
  }

  addNewReservation(reservation: Reservation) {
    this._reservations.push(reservation);
  }
}
