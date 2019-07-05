export class Note {
  id?: number;
  title: string;

  description: string;

  reminder?: Date | string;

  isDone?: boolean;


  timestamp?: string;
  createdBy: string;

  createdOn: Date;

  updatedBy?: string;

  updatedOn?: Date | string | null;
}
