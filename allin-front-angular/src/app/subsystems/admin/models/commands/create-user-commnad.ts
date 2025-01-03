import { CreateEmployeeCommand } from "./create-employee-command";

export interface CreateUserCommand {
    userName: string;
    password: string;
    employee?: CreateEmployeeCommand;
    employeeId?: number;
    roles: number[];
    deniedPermission: number[];
}

