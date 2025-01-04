export interface CreatePersonCommand {
  firstName?: string; // nvarchar(150)
  lastName?: string;  // nvarchar(150)
  ssn?: string;       // nvarchar(50)
  mobiles: Mobile[]; // nvarchar(500)
  email?: string;      // nvarchar(50)
  photoUrl?: string;   // nvarchar(500)
  signatureImageUrl?: string; // nvarchar(500)
  birthDate?: Date;    // date
  genderBaseId?: number; // bigint
  maritalStatus?: number; // smallint
  isLegal : boolean;
  addresses: Address[];
}

export interface Mobile {
    type: number;
    phoneNumber: string;
  }

  export interface Address {
    type: number;
    address: string;
  }