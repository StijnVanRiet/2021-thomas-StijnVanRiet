import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { SelectivePreloadStrategy } from './SelectivePreloadStrategy';

const appRoutes: Routes = [
  {
    path: 'appointment',
    loadChildren: () =>
      import('./appointment/appointment.module').then(
        (mod) => mod.AppointmentModule
      ),
    data: { preload: true },
  },
  { path: '', redirectTo: 'appointment/list', pathMatch: 'full' },
  { path: '**', component: PageNotFoundComponent },
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(appRoutes, {
      preloadingStrategy: SelectivePreloadStrategy,
    }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
