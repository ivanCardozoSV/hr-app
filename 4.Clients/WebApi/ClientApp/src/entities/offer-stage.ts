import { StageStatusEnum } from './enums/stage-status.enum';
import { SeniorityEnum } from './enums/seniority.enum';
import { Stage } from './stage';
import { Offer } from './offer';

export class OfferStage extends Stage {    
    hireDate: Date;
    seniority: SeniorityEnum;    
    backgroundCheckDone: boolean;
    backgroundCheckDoneDate: Date;
    preocupationalDone: boolean;
    preocupationalDoneDate: Date;
    offers : Offer[];
}
