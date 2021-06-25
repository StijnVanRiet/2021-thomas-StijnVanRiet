import { Service, ServiceJson } from './service.model';

interface ReservationJson {
  id: number;
  firstName: string;
  lastName: string;
  phoneNumber: string;
  email: string;
  remarks: string;
  services: ServiceJson[];
  date: string;
}
export class Reservation {
  private _id: number;
  constructor(
    private _firstName: string,
    private _services = new Array<Service>(),
    private _lastName = '',
    private _phoneNumber = '',
    private _email = '',
    private _remarks = '',
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
      new Date(json.date)
    );
    res._id = json.id;
    return res;
  }

  toJSON(): ReservationJson {
    return <ReservationJson>{
      firstName: this.firstName,
      services: this.services.map((ser) => ser.toJSON()),
      lastName: this.lastName,
      phoneNumber: this.phoneNumber,
      email: this.email,
      remarks: this.remarks,
      date: new Date(this.date).toISOString(),
    };
  }

  addService(name: string, price: number) {
    this._services.push(new Service(name, price));
  }

  get id(): number {
    return this._id;
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
  get date(): Date {
    return this._date;
  }
}
