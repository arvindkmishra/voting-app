# VotingApp Backend

VotingApp is a sample application built with Clean Architecture principles using **.NET 8** for the backend and **Angular** for the frontend. The application allows users to add candidates and voters, and to cast votes for candidates. This structure ensures separation of concerns, maintainability, and scalability.

## Project Structure

The solution is organized into several projects, each representing a different layer of the Clean Architecture:

1. **VotingApp.Domain:** Contains the core entities and domain logic.
2. **VotingApp.Core:** Contains the business logic and application-specific logic.
3. **VotingApp.Infrastructure:** Contains implementations for external resources such as database context.
4. **VotingApp.API:** Contains the  controllers.


## Usages
1. **Adding Candidates** : Use the CandidatesController to add candidates.
2. **Adding Voters** : Use the VotersController to add voters.
3. **Casting Votes**: Use the VotesController to cast votes by selecting a candidate and a voter.

## API Endpoints
1. GET /api/candidates: Retrieve all candidates.
2. POST /api/candidates: Add a new candidate.
3. GET /api/voters: Retrieve all voters.
4. POST /api/voters: Add a new voter.
5. POST /api/votes?voterId={voterId}&candidateId={candidateId}: Cast a vote.


# VotingApp Frontend

This is the frontend application for the VotingApp, built using Angular. It provides a user interface to manage candidates and voters, and to cast votes. The application interacts with the backend API to perform CRUD operations and updates the UI in real-time.

## Project Structure

The project is structured as follows:

- **src/app/components:** Contains Angular components for candidates, voters, and voting.
- **src/app/services:** Contains Angular services for interacting with the backend API.
- **src/app/models:** Contains TypeScript models for Candidate and Voter entities.

### Key Components

- **CandidateComponent:** Manages the display and addition of candidates.
- **VoterComponent:** Manages the display and addition of voters.
- **VoterDetailsComponent:** Handles the voting process.

### Key Services

- **CandidateService:** Provides methods to interact with the candidates API endpoints.
- **VoterService:** Provides methods to interact with the voters API endpoints.

### Usage
1. **Add Candidates:** Use the form to add new candidates. The list of candidates will be displayed with the number of votes each candidate has received.
2. **Add Voters:** Use the form to add new voters. The list of voters will be displayed with their voting status.
3. **Cast Votes:** Select a candidate and a voter from the dropdowns and cast a vote. The candidate's vote count and the voter's status will be updated accordingly.

### Project Structure

![image](https://github.com/arvindkmishra/voting-app/assets/170667140/79720e2e-1903-49d3-bc4c-78378f4e25c0)


## License

[MIT](https://choosealicense.com/licenses/mit/)
