import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  name: string;
  services: string[];
  dateAdded: Date;

  constructor() { 
    this.name = 'Barbershape Women';
    this.services =  ["only cut", "only brushing", "cut and brushing", "coloring", "makeup"];
    this.dateAdded = new Date();
  }

  ngOnInit(): void {
  }

}
