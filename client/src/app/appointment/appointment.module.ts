import { MaterialModule } from '../material/material.module';
import { AppointmentComponent } from './appointment/appointment.component';
import { ServiceComponent } from './service/service.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppointmentListComponent } from './appointment-list/appointment-list.component';
import { AddAppointmentComponent } from './add-appointment/add-appointment.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppointmentComponent,
    ServiceComponent,
    AppointmentListComponent,
    AddAppointmentComponent,
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialModule,
    ReactiveFormsModule,
  ],
  exports: [AppointmentListComponent],
})
export class AppointmentModule {}
