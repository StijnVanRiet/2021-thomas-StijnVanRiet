import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Appointment } from './appointment.model';
import { Service } from './service.model';

@Injectable({
  providedIn: 'root',
})
export class AppointmentDataService {
  private _appointments$ = new BehaviorSubject<Appointment[]>([]);
  private _appointments: Appointment[];

  constructor(private http: HttpClient) {
    this.appointments$
      .pipe(
        catchError((err) => {
          console.log('error got here');
          this._appointments$.error(err);
          return throwError(err);
        })
      )
      .subscribe((appointments: Appointment[]) => {
        this._appointments = appointments;
        this._appointments$.next(this._appointments);
      });
  }
  get categories$(): Observable<String[]> {
    return this.http.get(`${environment.apiUrl}/categories/`).pipe(
      catchError(this.handleError),
      map((list: any[]): String[] => list.map((c) => c))
    );
  }

  getServices$(categorie: String): Observable<Service[]> {
    return this.http.get(`${environment.apiUrl}/standardservices/${categorie}`).pipe(
      catchError(this.handleError),
      map((list: any[]): Service[] => list.map(Service.fromJSON))
    );
  }

  get dates$(): Observable<Date[]> {
    return this.http.get(`${environment.apiUrl}/dates/`).pipe(
      catchError(this.handleError),
      map((list: any[]): Date[] => list.map((dat) => new Date(dat)))
    );
  }

  getTimeSlots$(s: String): Observable<String[]> {
    return this.http.get(`${environment.apiUrl}/dates/${s}`).pipe(
      catchError(this.handleError),
      map((list: any[]): String[] => list.map((ts) => ts))
    );
  }

  get allAppointments$(): Observable<Appointment[]> {
    return this._appointments$;
  }

  get appointments$(): Observable<Appointment[]> {
    return this.http.get(`${environment.apiUrl}/appointments/`).pipe(
      catchError(this.handleError),
      map((list: any[]): Appointment[] => list.map(Appointment.fromJSON))
    );
  }

  addNewAppointment(appointment: Appointment) {
    return this.http
      .post(`${environment.apiUrl}/appointments/`, appointment.toJSON())
      .pipe(catchError(this.handleError), map(Appointment.fromJSON))
      .subscribe((res: Appointment) => {
        this._appointments = [...this._appointments, res];
        this._appointments$.next(this._appointments);
        window.location.reload(); // refresh page
      });
  }

  deleteAppointment(appointment: Appointment) {
    return this.http
      .delete(`${environment.apiUrl}/appointments/${appointment.id}`)
      .pipe(catchError(this.handleError))
      .subscribe(() => {
        this._appointments = this._appointments.filter(
          (app) => app.id != appointment.id
        );
        this._appointments$.next(this._appointments);
        //window.location.reload(); // refresh page
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
