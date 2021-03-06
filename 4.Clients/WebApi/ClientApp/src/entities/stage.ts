import { StageItem } from "./stageItem";
import { Consultant } from "./consultant";
import { Process } from "./process";
import { StageStatusEnum } from './enums/stage-status.enum';

export class Stage {
    id: number;
    date: Date;
    feedback: string;
    status: StageStatusEnum;
    consultantOwnerId: number;
    consultantDelegateId: number;
    processId: number;
    rejectionReason?: string;
}