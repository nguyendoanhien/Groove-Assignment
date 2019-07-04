export interface INote {
  id: number;

  title: string;

  description: string;

  finished: boolean;

  notebookId: number;

  createdBy: string;

  createdOn: Date | string;

  updatedBy: string;

  updatedOn: Date | string | null;

  deleted: boolean;

  timestamp: string;
}

export class Note implements INote {
  title: string;
  id: number; 
  description: string;
  finished: boolean;
  notebookId: number;
  createdBy: string;
  createdOn: string | Date;
  updatedBy: string;
  updatedOn: string | Date;
  deleted: boolean;
  timestamp: string;
}
