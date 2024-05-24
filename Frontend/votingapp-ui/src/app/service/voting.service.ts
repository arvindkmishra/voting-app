import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Candidate } from '../model/candidate'
import { Voter } from '../model/voter';
import { VotersAndCandidates } from '../model/voters-candidates';
import { VoteInput } from '../model/vote-input';
import { AddCandidate } from '../model/add-candidate';
import { VoteSaveResponse } from '../model/vote-save-response';
import { environment } from '../../environments/environment';
import { AddVoter } from '../model/add-voter';

@Injectable({
  providedIn: 'root'
})
export class VotingService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  AddVoter(voterInput: AddVoter): Observable<Voter> {
    return this.http.post<Voter>(this.apiUrl + 'Voters', voterInput);
  }

  CastVote(voteInput: VoteInput): Observable<VoteSaveResponse> {
    return this.http.post<VoteSaveResponse>(this.apiUrl + 'Votes', voteInput);
  }

  GetVoters(): Observable<Voter[]> {
    return this.http.get<Voter[]>(this.apiUrl + 'Voters');
  }
}