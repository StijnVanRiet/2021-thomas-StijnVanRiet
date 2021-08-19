import { MaterialModule } from '../material/material.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppointmentListComponent } from './appointment-list/appointment-list.component';
import { AddAppointmentComponent } from './add-appointment/add-appointment.component';
import { AppointmentComponent } from './appointment/appointment.component';
import { PricelistComponent } from './pricelist/pricelist.component';
import { ServiceComponent } from './service/service.component';
import { ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'list', component: AppointmentListComponent },
  { path: 'add', component: AddAppointmentComponent },
  { path: 'pricelist', component: PricelistComponent },
];

@NgModule({
  declarations: [
    AppointmentComponent,
    ServiceComponent,
    AppointmentListComponent,
    AddAppointmentComponent,
    PricelistComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes),
  ],
  exports: [AddAppointmentComponent, AppointmentListComponent],
})
export class AppointmentModule {}
