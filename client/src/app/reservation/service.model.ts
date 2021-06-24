export interface ServiceJson {
  name: string;
  price: number;
}
export class Service {
  constructor(
    private _name: string,
    private _price: number,
  ) {}

  static fromJSON(json: ServiceJson): Service {
    // const price =
    //   typeof json.price === 'string' ? parseInt(json.price) : json.price;
    const ser = new Service(json.name, json.price);
    return ser;
  }

  toJSON(): ServiceJson {
    return { name: this.name, price: this.price };
  }

  get name() {
    return this._name;
  }
  get price() {
    return this._price;
  }
  
}
