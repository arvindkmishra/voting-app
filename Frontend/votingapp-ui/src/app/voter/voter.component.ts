import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { VotingService } from '../service/voting.service';
import { Router } from '@angular/router';
import { AddVoter } from '../model/add-voter';

@Component({
  selector: 'app-voter',
  templateUrl: './voter.component.html',
  styleUrls: ['./voter.component.css']
})

export class VoterComponent implements OnInit {
  registrationForm!: FormGroup;
  voterInput: AddVoter | undefined;

  constructor(private formBuilder: FormBuilder, private votingService: VotingService,
    private router: Router) { }

  ngOnInit(): void {
    this.registrationForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
    });
  }

  onSubmit(): void {
    if (this.registrationForm.valid) {
      this.voterInput = {
        firstName: this.registrationForm.get('firstName')?.value,
        lastName: this.registrationForm.get('lastName')?.value,
      };

      this.votingService.AddVoter(this.voterInput).subscribe(
        response => {
          alert('Record added successfully');
          this.registrationForm.reset();
          this.navigateToHome();
        },
        error => {
          alert(error.error);
        }
      );
    }
  } 

  navigateToHome(): void {
    this.router.navigate(['/']);
  }
}