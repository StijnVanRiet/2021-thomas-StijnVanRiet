import { MaterialModule } from './../material/material.module';
import { ServiceComponent } from './service/service.component';
import { CategoryComponent } from './category/category.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [CategoryComponent, ServiceComponent],
  imports: [CommonModule, MaterialModule],
  exports: [CategoryComponent],
})
export class CategoryModule {}
