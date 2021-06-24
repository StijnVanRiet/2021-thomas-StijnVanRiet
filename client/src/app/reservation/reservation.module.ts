import { MaterialModule } from '../material/material.module';
import { ReservationComponent } from './reservation/reservation.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReservationListComponent } from './reservation-list/reservation-list.component';

@NgModule({
  declarations: [ReservationComponent, ReservationListComponent],
  imports: [CommonModule, MaterialModule],
  exports: [ReservationListComponent],
})
export class ReservationModule {}
