import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { PersonComponent } from './person/person.component';
import { AddEditPerComponent } from './person/add-edit-per/add-edit-per.component';
import {HttpClientModule} from '@angular/common/http';
import{SharedService} from './shared.service';
import { ShowPerComponent } from './person/show-per/show-per.component';
import { RouterModule } from '@angular/router';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

@NgModule({
  declarations: [
    AppComponent,
    PersonComponent,
    ShowPerComponent,
    AddEditPerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: '', component: PersonComponent},
      { path: 'person/:id/edit', component: AddEditPerComponent},
      { path: 'person/:id', component: ShowPerComponent},
      { path: 'person', component: ShowPerComponent},
      { path: '**', component: PageNotFoundComponent},
    ]),
  ],
 
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
