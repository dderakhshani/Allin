import { CreatePersonCommand } from "./create-Person-command";

export interface CreateEmployeeCommand {
    positionId: number;
    departmentId: number;

    person?: CreatePersonCommand;
    personId?: number;
}