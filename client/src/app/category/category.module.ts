import { MaterialModule } from './../material/material.module';
import { ServiceComponent } from './service/service.component';
import { CategoryComponent } from './category/category.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoryListComponent } from './category-list/category-list.component';

@NgModule({
  declarations: [CategoryComponent, ServiceComponent, CategoryListComponent],
  imports: [CommonModule, MaterialModule],
  exports: [CategoryListComponent],
})
export class CategoryModule {}
