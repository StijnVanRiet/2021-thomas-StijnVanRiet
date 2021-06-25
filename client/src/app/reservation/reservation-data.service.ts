import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Reservation } from './reservation.model';

@Injectable({
  providedIn: 'root'
})
export class ReservationDataService {
  private _reservations$ = new BehaviorSubject<Reservation[]>([]);
  private _reservations: Reservation[];

  constructor(private http: HttpClient) {
    this.reservations$
      .pipe(
        catchError((err) => {
          console.log('error got here');
          this._reservations$.error(err);
          return throwError(err);
        })
      )
      .subscribe((reservations: Reservation[]) => {
        this._reservations = reservations;
        this._reservations$.next(this._reservations);
      });
   }

   get allReservations$(): Observable<Reservation[]> {
    return this._reservations$;
  }

  get reservations$(): Observable< Reservation[] > {
    return this.http.get(`${environment.apiUrl}/reservations/`).pipe(
      catchError(this.handleError),
      map((list: any[]): Reservation[] => list.map(Reservation.fromJSON))
    );
  }

  addNewReservation(reservation: Reservation) {
    return this.http
      .post(`${environment.apiUrl}/reservations/`, reservation.toJSON())
      .pipe(
        catchError(this.handleError),
        map(Reservation.fromJSON)
        )
      .subscribe((res: Reservation) => {
        this._reservations = [...this._reservations, res];
        this._reservations$.next(this._reservations);
      });
  }

  deleteReservation(reservation: Reservation) {
    return this.http
      .delete(`${environment.apiUrl}/reservations/${reservation.id}`)
      .pipe(catchError(this.handleError))
      .subscribe(() => {
        this._reservations = this._reservations.filter(res => res.id != reservation.id);
        this._reservations$.next(this._reservations);
      });
  }

  handleError(err: any): Observable<never> {
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else if (err instanceof HttpErrorResponse) {
      errorMessage = `'${err.status} ${err.statusText}' when accessing '${err.url}'`;
    } else {
      errorMessage = err;
    }
    return throwError(errorMessage);
  }
}
