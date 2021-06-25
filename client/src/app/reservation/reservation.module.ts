import { MaterialModule } from '../material/material.module';
import { ReservationComponent } from './reservation/reservation.component';
import { ServiceComponent } from './service/service.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReservationListComponent } from './reservation-list/reservation-list.component';
import { AddReservationComponent } from './add-reservation/add-reservation.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    ReservationComponent,
    ServiceComponent,
    ReservationListComponent,
    AddReservationComponent,
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialModule,
    ReactiveFormsModule,
  ],
  exports: [ReservationListComponent],
})
export class ReservationModule {}
