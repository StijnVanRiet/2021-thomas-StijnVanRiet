import { Component, OnInit } from '@angular/core';
import { Reservation } from '../reservation.model';
import { ReservationDataService } from '../reservation-data.service';
import { EMPTY, Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Component({
  selector: 'app-reservation-list',
  templateUrl: './reservation-list.component.html',
  styleUrls: ['./reservation-list.component.css'],
})
export class ReservationListComponent implements OnInit {
  private _fetchReservations$: Observable<Reservation[]>;
  public errorMessage: string = '';

  constructor(private _reservationDataService: ReservationDataService) {}

  ngOnInit(): void {
    this._fetchReservations$ = this._reservationDataService.allReservations$.pipe(
      catchError(err => {
        this.errorMessage = err;
        return EMPTY;
      })
    );
  }

  get reservations$(): Observable<Reservation[]> {
    return this._fetchReservations$;
  }

  addNewReservation(reservation) {
    this._reservationDataService.addNewReservation(reservation);
  }
}
