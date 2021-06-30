import { Component, OnInit } from '@angular/core';
import { Appointment } from '../appointment.model';
import { AppointmentDataService } from '../appointment-data.service';
import { EMPTY, Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Component({
  selector: 'app-appointment-list',
  templateUrl: './appointment-list.component.html',
  styleUrls: ['./appointment-list.component.css'],
})
export class AppointmentListComponent implements OnInit {
  private _fetchAppointments$: Observable<Appointment[]>;
  public errorMessage: string = '';

  constructor(private _appointmentDataService: AppointmentDataService) {}

  ngOnInit(): void {
    this._fetchAppointments$ = this._appointmentDataService.allAppointments$.pipe(
      catchError(err => {
        this.errorMessage = err;
        return EMPTY;
      })
    );
  }

  get appointments$(): Observable<Appointment[]> {
    return this._fetchAppointments$;
  }

  addNewAppointment(appointment) {
    this._appointmentDataService.addNewAppointment(appointment);
  }
}
