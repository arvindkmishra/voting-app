import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CandidateService } from '../service/candidate-service';
import { Router } from '@angular/router';
import { AddCandidate } from '../model/add-candidate';

@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.css']
})

export class CandidateComponent implements OnInit {
  registrationForm!: FormGroup;
  addCandidate: AddCandidate | undefined;

  constructor(private formBuilder: FormBuilder, private candidateService: CandidateService,
    private router: Router) { }

  ngOnInit(): void {
    this.registrationForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
    });
  }

  onSubmit(): void {
    if (this.registrationForm.valid) {
      this.addCandidate = {
        firstName: this.registrationForm.get('firstName')?.value,
        lastName: this.registrationForm.get('lastName')?.value,
      };
      this.candidateService.AddCandidate(this.addCandidate).subscribe(
        response => {
          this.registrationForm.reset();
          alert('Record added successfully');
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