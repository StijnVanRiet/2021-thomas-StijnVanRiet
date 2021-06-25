import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Reservation } from '../reservation.model';
import { Service } from '../service.model';

@Component({
  selector: 'app-add-reservation',
  templateUrl: './add-reservation.component.html',
  styleUrls: ['./add-reservation.component.css'],
})
export class AddReservationComponent implements OnInit {
  public readonly serviceNames = ['test1', 'test2', 'test3'];
  public reservation: FormGroup;
  @Output() public newReservation = new EventEmitter<Reservation>();

  constructor(private fb: FormBuilder) {}

  ngOnInit() {
    this.reservation = this.fb.group({
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
      price: 5
    });
  }

  onSubmit() {
    let services = this.reservation.value.services.map(Service.fromJSON);
    this.newReservation.emit(
      new Reservation(
        this.reservation.value.firstName,
        services,
        this.reservation.value.lastName,
        this.reservation.value.phoneNumber,
        this.reservation.value.email,
        this.reservation.value.remarks,
        this.reservation.value.date,
        ));
  }

  getErrorMessage(errors: any): string {
    if (errors.required) {
      return 'is required';
    } else if (errors.minlength) {
      return `needs at least ${errors.minlength.requiredLength} 
        characters (got ${errors.minlength.actualLength})`;
    } else if (errors.pattern) {
      return 'invalid input';
    }  else if (errors.email) {
      return 'invalid email address';
    }
  }
}
