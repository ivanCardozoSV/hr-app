import { CandidateSkill } from "./candidateSkill";
import { CandidateStatusEnum } from "./enums/candidate-status.enum";
import { EnglishLevelEnum } from './enums/english-level.enum';
import { Office } from "./office";

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
  recruiter: number;
  preferredOfficeId?: number;
  contactDay: Date;
}