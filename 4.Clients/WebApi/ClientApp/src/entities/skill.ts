import { CandidateSkill } from "./candidateSkill";
import { SkillType } from "./skillType";

export class Skill {
    id:number;
    name: string;
    description: string;
    type: number;

    candidateSkills: CandidateSkill[];
}