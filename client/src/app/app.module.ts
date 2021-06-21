import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { CategoryModule } from './category/category.module';
import { MaterialModule } from './material/material.module';

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, CategoryModule, MaterialModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
