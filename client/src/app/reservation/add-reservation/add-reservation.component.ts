import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Reservation } from '../reservation.model';

@Component({
  selector: 'app-add-reservation',
  templateUrl: './add-reservation.component.html',
  styleUrls: ['./add-reservation.component.css']
})
export class AddReservationComponent implements OnInit {
  @Output() public newReservation = new EventEmitter<Reservation>();
  constructor() {}
  
  ngOnInit(): void {
  }

  addReservation(reservationFirstName: HTMLInputElement): boolean {
    const reservation = new Reservation(reservationFirstName.value, []);
    this.newReservation.emit(reservation);
    return false;
  }
}
