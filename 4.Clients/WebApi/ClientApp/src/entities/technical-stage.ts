import { StageStatusEnum } from './enums/stage-status.enum';
import { SeniorityEnum } from './enums/seniority.enum';
import { Stage } from './stage';

export class TechnicalStage extends Stage{
    seniority: SeniorityEnum;
    client: string;
}
