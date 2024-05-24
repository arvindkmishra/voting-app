import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { VoterComponent } from './voter/voter.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { VoterDetailsComponent } from './voter-details/voter-details.component';
import { CandidateComponent } from './candidate/candidate.component';

@NgModule({
  declarations: [
    AppComponent,
    CandidateComponent,
    VoterComponent,
    VoterDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

