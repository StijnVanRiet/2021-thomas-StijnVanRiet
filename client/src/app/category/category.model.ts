interface CategoryJson {
  name: string;
  services: string[];
  dateAdded: string;
}
export class Category {
  constructor(
    private _name: string,
    private _services = new Array<string>(),
    private _dateAdded = new Date()
  ) {}

  static fromJSON(json: CategoryJson): Category {
    const cat = new Category(
      json.name,
      json.services,
      new Date(json.dateAdded)
    );
    return cat;
  }

  get services(): string[] {
    return this._services;
  }

  get dateAdded(): Date {
    return this._dateAdded;
  }

  get name(): string {
    return this._name;
  }

  addService(name: string, amount?: number, unit?: string) {
    this._services.push(`${amount || 1} ${unit || ''} ${name}`);
  }
}
