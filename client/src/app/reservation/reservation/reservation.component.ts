import { Component, OnInit, Input } from '@angular/core';
import { ReservationDataService } from '../reservation-data.service';
import { Reservation } from '../reservation.model';

@Component({
	selector: 'app-reservation',
	templateUrl: './reservation.component.html',
	styleUrls: ['./reservation.component.css']
})
export class ReservationComponent implements OnInit {
	@Input() public reservation: Reservation;

	constructor(private _reservationDataService: ReservationDataService) {}

	ngOnInit() {}

	deleteReservation() {
		this._reservationDataService.deleteReservation(this.reservation);
	  }
}