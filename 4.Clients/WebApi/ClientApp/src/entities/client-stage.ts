import { StageStatusEnum } from './enums/stage-status.enum';
import { Stage } from './stage';

export class ClientStage extends Stage {
    interviewer: string;
    delegateName : string;
}
