import { ExtendedFieldValueModel } from "../../../shared/models/extended-field-value-model";

export interface CreatePersonCommand {
  firstName?: string; // nvarchar(150)
  lastName?: string;  // nvarchar(150)
  ssn?: string;       // nvarchar(50)
  mobiles?: Mobile[]; // nvarchar(500)
  email?: string;      // nvarchar(50)
  photoUrl?: string;   // nvarchar(500)
  signatureImageUrl?: string; // nvarchar(500)
  birthDate?: Date;    // date
  genderEnum?: number; // bigint
  maritalEnum?: number; // smallint
  isLegal?: boolean;
  personAddresses?: Address[];


  extendedFieldValues?: ExtendedFieldValueModel[];
}

export interface Mobile {
  type: string;
  phoneNumber: string;
}

export interface Address {
  type: number;
  addressLine: string;
}