import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Candidate } from '../model/candidate'
import { AddCandidate } from '../model/add-candidate';
import { environment } from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class CandidateService {
    private apiUrl = environment.apiUrl;

    constructor(private http: HttpClient) { }

    AddCandidate(candidateInput: AddCandidate): Observable<Candidate> {
        return this.http.post<Candidate>(this.apiUrl + 'Candidates', candidateInput);
    }

    GetCandidates(): Observable<Candidate[]> {
        return this.http.get<Candidate[]>(this.apiUrl + 'Candidates');
    }
}