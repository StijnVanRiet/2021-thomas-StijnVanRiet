import { MaterialModule } from '../material/material.module';
import { ReservationComponent } from './reservation/reservation.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReservationListComponent } from './reservation-list/reservation-list.component';
import { AddReservationComponent } from './add-reservation/add-reservation.component';

@NgModule({
  declarations: [ReservationComponent, ReservationListComponent, AddReservationComponent],
  imports: [CommonModule, MaterialModule],
  exports: [ReservationListComponent],
})
export class ReservationModule {}
