import { StageStatusEnum } from './enums/stage-status.enum';
import { EnglishLevelEnum } from './enums/english-level.enum';
import { Stage } from 'src/entities/stage';

export class HrStage extends Stage{
    actualSalary: number;
    wantedSalary: number;
    englishLevel: EnglishLevelEnum;
}