import { StageStatusEnum } from './enums/stage-status.enum';
import { SeniorityEnum } from './enums/seniority.enum';
import { Stage } from './stage';

export class OfferStage extends Stage {
    offerDate: Date;
    hireDate: Date;
    seniority: SeniorityEnum;
    agreedSalary: number;
    backgroundCheckDone: boolean;
    backgroundCheckDoneDate: Date;
    preocupationalDone: boolean;
    preocupationalDoneDate: Date;
}