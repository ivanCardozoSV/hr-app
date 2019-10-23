import { StageStatusEnum } from './enums/stage-status.enum';
import { EnglishLevelEnum } from './enums/english-level.enum';
import { Stage } from 'src/entities/stage';
import { RejectionReasonsHrEnum } from './enums/rejection-reasons-hr.enum';

export class HrStage extends Stage{
    actualSalary: number;
    wantedSalary: number;
    englishLevel: EnglishLevelEnum;
    rejectionReasonHR?: RejectionReasonsHrEnum;
}