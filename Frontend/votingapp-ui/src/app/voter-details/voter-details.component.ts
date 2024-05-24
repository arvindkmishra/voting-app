import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { VotingService } from '../service/voting.service';
import { CandidateService } from '../service/candidate-service';
import { Candidate } from '../model/candidate';
import { Voter } from '../model/voter';
import { VoteInput } from '../model/vote-input';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-voter-details',
  templateUrl: './voter-details.component.html',
  styleUrls: ['./voter-details.component.css']
})
export class VoterDetailsComponent {
  showSuccess = false;
  votingForm!: FormGroup;
  voteInput: VoteInput | undefined;
  candidates: Candidate[] = [];
  voters: Voter[] = [];



  constructor(private votingService: VotingService, private candidateService: CandidateService,
    private router: Router, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.getVotersAndCandidates();

    this.votingForm = this.formBuilder.group({
      candidateId: ['', Validators.required],
      voterId: ['', Validators.required],
    });

  }

  getVotersAndCandidates() {
    this.votingService.GetVoters().subscribe(_voters => {
      this.voters = _voters;
    });
    this.candidateService.GetCandidates().subscribe(_candidates => {
      this.candidates = _candidates;
    });
  }

  showSuccessMessage() {
    this.showSuccess = true;

    setTimeout(() => {
      this.showSuccess = false;
    }, 3000);
  }

  navigateToVoter(): void {
    this.router.navigate(['/voter-register']);
  }

  navigateToCandidates(): void {
    this.router.navigate(['/candidates-register']);
  }


  onSubmit(): void {
    if (this.votingForm.valid) {
      this.voteInput = {
        candidateId: this.votingForm.get('candidateId')?.value,
        voterId: this.votingForm.get('voterId')?.value,
      };
      this.votingService.CastVote(this.voteInput).subscribe(
        response => {
          alert("Kudos, you have voted for right candidate!");
          this.getVotersAndCandidates();
          this.votingForm.reset();
        },
        error => {
          alert(error.error);
        }
      );

    }
  }
}