import { CandidateSkill } from "./candidateSkill";
import { CandidateStatusEnum } from "./enums/candidate-status.enum";
import { EnglishLevelEnum } from './enums/english-level.enum';
import { Office } from "./office";
import { Consultant } from "./consultant";
import { Community } from "./community";

export class Candidate {
  id: number;
  name: string;
  lastName: string;
  dni: number;
  emailAddress: string;
  phoneNumber: string;
  linkedInProfile: string;
  additionalInformation: string;
  englishLevel: EnglishLevelEnum;
  status: CandidateStatusEnum;
  candidateSkills: CandidateSkill[];
  recruiter: Consultant;
  preferredOfficeId?: number;
  contactDay: Date;
  profile: number;
  community: Community;
  isReferred: boolean;
}