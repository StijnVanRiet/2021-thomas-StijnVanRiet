import { Service, ServiceJson } from './service.model';

interface AppointmentJson {
  id: number;
  firstName: string;
  lastName: string;
  phoneNumber: string;
  email: string;
  remarks: string;
  services: ServiceJson[];
  date: string;
}
export class Appointment {
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

  static fromJSON(json: AppointmentJson): Appointment {
    const app = new Appointment(
      json.firstName,
      json.services.map(Service.fromJSON),
      json.lastName,
      json.phoneNumber,
      json.email,
      json.remarks,
      new Date(json.date)
    );
    app._id = json.id;
    return app;
  }

  toJSON(): AppointmentJson {
    var isoDateTime = new Date(
      this.date.getTime() - this.date.getTimezoneOffset() * 60000
    ).toISOString(); // solution to timezone problem + page needs reload (see data-service)
    return <AppointmentJson>{
      firstName: this.firstName,
      services: this.services.map((ser) => ser.toJSON()),
      lastName: this.lastName,
      phoneNumber: this.phoneNumber,
      email: this.email,
      remarks: this.remarks,
      date: isoDateTime,
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
