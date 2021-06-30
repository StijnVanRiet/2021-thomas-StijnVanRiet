import { Component, OnInit, Input } from '@angular/core';
import { AppointmentDataService } from '../appointment-data.service';
import { Appointment } from '../appointment.model';

@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.css'],
})
export class AppointmentComponent implements OnInit {
  @Input() public appointment: Appointment;

  constructor(private _appointmentDataService: AppointmentDataService) {}

  ngOnInit() {}

  deleteAppointment() {
    this._appointmentDataService.deleteAppointment(this.appointment);
  }
}