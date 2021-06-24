import { MaterialModule } from '../material/material.module';
import { ReservationComponent } from './reservation/reservation.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReservationListComponent } from './reservation-list/reservation-list.component';
import { AddReservationComponent } from './add-reservation/add-reservation.component';
import { ServiceComponent } from './service/service.component';

@NgModule({
  declarations: [ReservationComponent, ReservationListComponent, AddReservationComponent, ServiceComponent],
  imports: [CommonModule, MaterialModule],
  exports: [ReservationListComponent],
})
export class ReservationModule {}
