import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CandidateComponent } from './candidate/candidate.component';
import { VoterComponent } from './voter/voter.component';
import { VoterDetailsComponent } from './voter-details/voter-details.component';

const routes: Routes = [
  { path: '', redirectTo: '/voter-details', pathMatch: 'full' },
  { path: 'candidates-register', component: CandidateComponent },
  { path: 'voter-register', component: VoterComponent },
  { path: 'voter-details', component: VoterDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
