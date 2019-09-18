import { ValidatorFn, FormControl } from "@angular/forms";

export const trimValidator: ValidatorFn = (control: FormControl) => {
    if (control.value != null) {
        if (control.value.toString().startsWith(' ')) {
            return {
                'trimBeginError': true
            };
        }
        if (control.value.toString().endsWith(' ')) {
            return {
                'trimEndError': true
            };
        }
    }
    return null;
};