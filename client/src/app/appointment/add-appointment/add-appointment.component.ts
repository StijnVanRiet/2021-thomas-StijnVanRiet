import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EMPTY, Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AppointmentDataService } from '../appointment-data.service';
import { Appointment } from '../appointment.model';
import { Service } from '../service.model';

@Component({
  selector: 'app-add-appointment',
  templateUrl: './add-appointment.component.html',
  styleUrls: ['./add-appointment.component.css'],
})
export class AddAppointmentComponent implements OnInit {
  private _fetchServices$: Observable<Service[]>;
  private services: Service[];
  public errorMessage: string = '';
  public appointment: FormGroup;
  @Output() public newAppointment = new EventEmitter<Appointment>();

  constructor(
    private _appointmentDataService: AppointmentDataService,
    private fb: FormBuilder
  ) {}

  get services$(): Observable<Service[]> {
    return this._fetchServices$;
  }

  ngOnInit() {
    this._fetchServices$ = this._appointmentDataService.services$.pipe(
      catchError((err) => {
        this.errorMessage = err;
        return EMPTY;
      }));
    this._appointmentDataService.services$.subscribe((services: Service[]) => {
      this.services = services;
    });

    this.appointment = this.fb.group({
      firstName: [
        '',
        [Validators.required, Validators.pattern(/^[a-z ,.'-]+$/i)],
      ],
      lastName: [
        '',
        [Validators.required, Validators.pattern(/^[a-z ,.'-]+$/i)],
      ],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: [
        '',
        [Validators.required, Validators.pattern(/^[0-9]{10}$/)],
      ],
      services: this.fb.array([this.createServices()]),
      remarks: [''],
      date: ['', [Validators.required]],
    });
  }

  createServices(): FormGroup {
    return this.fb.group({
      name: ['', [Validators.required]],
      price: [''],
    });
  }

  onSubmit() {
    let services = this.appointment.value.services.map(Service.fromJSON);
    let array: Service[];
    array = [];
    services.forEach((s: Service) => {
      s = this.services.find((element) => element.name === s.name);
        array.push(s);
    });
    this.newAppointment.emit(
      new Appointment(
        this.appointment.value.firstName,
        array,
        this.appointment.value.lastName,
        this.appointment.value.phoneNumber,
        this.appointment.value.email,
        this.appointment.value.remarks,
        this.appointment.value.date
      )
    );
  }

  getErrorMessage(errors: any): string {
    if (errors.required) {
      return 'is required';
    } else if (errors.minlength) {
      return `needs at least ${errors.minlength.requiredLength} 
        characters (got ${errors.minlength.actualLength})`;
    } else if (errors.pattern) {
      return 'invalid input';
    } else if (errors.email) {
      return 'invalid email address';
    }
  }
}
