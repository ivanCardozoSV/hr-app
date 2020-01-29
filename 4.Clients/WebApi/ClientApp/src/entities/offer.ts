import { OfferStatusEnum } from "./enums/offer-status.enum";


export class Offer {
    constructor(id?: number) {
        this.id = id;
      }
    id : number;
    offerDate : Date
    salary : number;
    rejectionReason: string;
    status : OfferStatusEnum
}
