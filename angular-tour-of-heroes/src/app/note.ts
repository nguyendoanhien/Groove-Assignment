import { AuditBase } from "./auditbase";


export class Note extends AuditBase{
    title: string;

    description: string;

    reminder: Date | string;

    isDone: boolean;
}
