import { Component, OnInit } from '@angular/core';
import { AppointmentDataService } from '../appointment-data.service';
import { EMPTY, Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Service } from '../service.model';

@Component({
  selector: 'app-pricelist',
  templateUrl: './pricelist.component.html',
  styleUrls: ['./pricelist.component.css'],
})
export class PricelistComponent implements OnInit {
  private _fetchList$: Observable<Service[]>;
  public errorMessage: string = '';

  constructor(
    private _appointmentDataService: AppointmentDataService
  ) {}

  ngOnInit(): void {
    this._fetchList$ = this._appointmentDataService
      .getServices$('Womenpricelist')
      .pipe(
        catchError((err) => {
          this.errorMessage = err;
          return EMPTY;
        })
      );
  }

  get list$(): Observable<Service[]> {
    return this._fetchList$;
  }

  onValChange(value) {
    this._fetchList$ = this._appointmentDataService
      .getServices$(value)
      .pipe(
        catchError((err) => {
          this.errorMessage = err;
          return EMPTY;
        })
      );
  }
}
