import { Service, ServiceJson } from './service.model';

interface ReservationJson {
  firstName: string;
  lastName: string;
  phoneNumber: string;
  email: string;
  remarks: string;
  services: ServiceJson[];
  barber: string;
  date: string;
}
export class Reservation {
  constructor(
    private _firstName: string,
    private _services = new Array<Service>(),
    private _lastName = '',
    private _phoneNumber = '',
    private _email = '',
    private _remarks = '',
    private _barber = '',
    private _date = new Date()
  ) {}

  static fromJSON(json: ReservationJson): Reservation {
    const res = new Reservation(
      json.firstName,
      json.services.map(Service.fromJSON),
      json.lastName,
      json.phoneNumber,
      json.email,
      json.remarks,
      json.barber,
      new Date(json.date)
    );
    return res;
  }

  toJSON(): ReservationJson {
    return <ReservationJson>{
      firstName: this.firstName,
      lastName: this.lastName,
      phoneNumber: this.phoneNumber,
      email: this.email,
      remarks: this.remarks,
      services: this.services.map(ser => ser.toJSON()),
      barber: this.barber,
      date: this.date.toString()
    };
  }

  addService(name: string, price: number) {
    this._services.push(new Service(name, price));
  }

  changeBarber(name: string) {
    this._barber = name;
  }

  get firstName(): string {
    return this._firstName;
  }
  get lastName(): string {
    return this._lastName;
  }
  get phoneNumber(): string {
    return this._phoneNumber;
  }
  get email(): string {
    return this._email;
  }
  get remarks(): string {
    return this._remarks;
  }
  get services(): Service[] {
    return this._services;
  }
  get barber(): string {
    return this._barber;
  }
  get date(): Date {
    return this._date;
  }

}
