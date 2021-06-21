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
      const rec = new Category(json.name, json.services, new Date(json.dateAdded));
      return rec;
    }
    get name(): string {
      return this._name;
    }
}