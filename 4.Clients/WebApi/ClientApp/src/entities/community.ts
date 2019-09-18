import { CandidateProfile } from "./Candidate-Profile";

export class Community {
    id: number;
    name: string;
    description: string;
    profileId: number;
    profile: CandidateProfile;
  }