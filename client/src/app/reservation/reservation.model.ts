interface ReservationJson {
  firstName: string;
  lastName: string;
  phoneNumber: string;
  email: string;
  remarks: string;
  services: string[];
  barber: string;
  date: string;
}
export class Reservation {
  constructor(
    private _firstName: string,
    private _lastName: string,
    private _phoneNumber: string,
    private _email: string,
    private _remarks: string,
    private _services = new Array<string>(),
    private _barber: string,
    private _date = new Date()
  ) {}

  static fromJSON(json: ReservationJson): Reservation {
    const res = new Reservation(
      json.firstName,
      json.lastName,
      json.phoneNumber,
      json.email,
      json.remarks,
      json.services,
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
      services: this.services,
      barber: this.barber,
      date: this.date.toString()
    };
  }

  addService(name: string) {
    this._services.push(name);
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
  get services(): string[] {
    return this._services;
  }
  get barber(): string {
    return this._barber;
  }
  get date(): Date {
    return this._date;
  }

}
