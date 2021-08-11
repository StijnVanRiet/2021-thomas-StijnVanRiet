import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import {
  FormGroup,
  Validators,
  FormBuilder,
} from '@angular/forms';
import { EMPTY, Observable } from 'rxjs';
import { distinctUntilChanged, catchError } from 'rxjs/operators';
import { AppointmentDataService } from '../appointment-data.service';
import { Appointment } from '../appointment.model';
import { Service } from '../service.model';

@Component({
  selector: 'app-add-appointment',
  templateUrl: './add-appointment.component.html',
  styleUrls: ['./add-appointment.component.css'],
})
export class AddAppointmentComponent implements OnInit {
  private _fetchCategories$: Observable<String[]>;
  private categories = String[''];
  public services: Service[];
  private _fetchDates$: Observable<Date[]>;
  private dates: Date[];
  public timeSlots = String[''];
  public errorMessage: string = '';
  public appointment: FormGroup;
  @Output() public newAppointment = new EventEmitter<Appointment>();
  public show1: boolean = false;
  public show2: boolean = false;
  public show3: boolean = false;
  public show4: boolean = false;

  constructor(
    private _appointmentDataService: AppointmentDataService,
    private fb: FormBuilder
  ) {}

  get categories$(): Observable<String[]> {
    return this._fetchCategories$;
  }

  get dates$(): Observable<Date[]> {
    return this._fetchDates$;
  }

  ngOnInit() {
    this._fetchCategories$ = this._appointmentDataService.categories$.pipe(
      catchError((err) => {
        this.errorMessage = err;
        return EMPTY;
      })
    );
    this._appointmentDataService.categories$.subscribe(
      (categories: String[]) => {
        this.categories = categories;
      }
    );

    this._fetchDates$ = this._appointmentDataService.dates$.pipe(
      catchError((err) => {
        this.errorMessage = err;
        return EMPTY;
      })
    );
    this._appointmentDataService.dates$.subscribe((dates: Date[]) => {
      this.dates = dates;
    });

    this.appointment = this.fb.group({
      firstName: [
        '',
        [Validators.required, Validators.pattern(/^[a-z ,.'-]+$/i)],
      ],
      lastName: [
        '',
        [Validators.required, Validators.pattern(/^[a-z ,.'-]+$/i)],
      ],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: [
        '',
        [Validators.required, Validators.pattern(/^[0-9]{10}$/)],
      ],
      categories: ['', [Validators.required]],
      service1: ['', [Validators.required]],
      service2: [''],
      service3: [''],
      remarks: [''],
      date: ['', [Validators.required]],
      time: ['', [Validators.required]],
    });

    this.appointment
      .get('categories')
      .valueChanges.pipe(distinctUntilChanged())
      .subscribe((list) => {
        this.show1 = true;
        this.appointment.controls['service1'].reset()
        this.appointment.controls['service2'].reset()
        this.appointment.controls['service3'].reset()
        this.show2 = false;
        this.show3 = false;
        this._appointmentDataService
          .getServices$(this.appointment.get('categories').value)
          .subscribe((s: Service[]) => {
            this.services = s;
          });
      });

    this.appointment
      .get('service1')
      .valueChanges.pipe(distinctUntilChanged())
      .subscribe((list) => {
        this.show2 = true;
      });
    this.appointment
      .get('service2')
      .valueChanges.pipe(distinctUntilChanged())
      .subscribe((list) => {
        this.show3 = true;
      });

    // change available time slots depending on date
    this.appointment
      .get('date')
      .valueChanges.pipe(distinctUntilChanged())
      .subscribe((list) => {
        var date = this.appointment.get('date').value;
        var month = date.getMonth() + 1;
        var day = date.getDate();
        var year = date.getFullYear();
        let s = year + '-' + month + '-' + day + 'T00:00:00.000Z';
        this._appointmentDataService
          .getTimeSlots$(s)
          .subscribe((slots: String[]) => {
            this.timeSlots = slots;
          });
        this.show4 = true;
      });
  }

  // call api for available dates
  myFilter = (d: Date | null): boolean => {
    const date = d || new Date();
    // geen dates in verleden + max 6 maand later dan vandaag + geen volgeboekte dates
    return (
      date.getTime() > Date.now() &&
      date.getTime() <
        new Date(new Date().setMonth(new Date().getMonth() + 6)).getTime() &&
      !this.dates.find((x) => x.getTime() == date.getTime())
    );
  };

  onSubmit() {
    let services = [this.appointment.value.service1];
    if (this.appointment.value.service2 != null) {
      services.push(this.appointment.value.service2);
    }

    if (this.appointment.value.service3 != null) {
      services.push(this.appointment.value.service3);
    }

    let array: Service[];
    array = [];
    services.forEach((s: string) => {
      let x = this.services.find((element) => element.name === s);
      array.push(x);
    });

    const date = this.appointment.value.date.toDateString();
    const time = this.appointment.value.time;
    const completeDate = date + ' ' + time + ':00';

    this.newAppointment.emit(
      new Appointment(
        this.appointment.value.firstName,
        array,
        this.appointment.value.lastName,
        this.appointment.value.phoneNumber,
        this.appointment.value.email,
        this.appointment.value.remarks,
        new Date(completeDate)
      )
    );
  }

  getErrorMessage(errors: any): string {
    if (errors.required) {
      return 'is required';
    } else if (errors.minlength) {
      return `needs at least ${errors.minlength.requiredLength} 
        characters (got ${errors.minlength.actualLength})`;
    } else if (errors.pattern) {
      return 'invalid input';
    } else if (errors.email) {
      return 'invalid email address';
    }
  }
}
