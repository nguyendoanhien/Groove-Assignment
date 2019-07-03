export interface INote
{
    Id: number;

    Title: string;

    Description: string;

    Finished: boolean;

    NotebookId: number;

    CreatedBy: string;

    CreatedOn: Date | string;

    UpdatedBy: string;

    UpdatedOn: Date | string | null;

    Deleted: boolean;

    Timestamp: string;
}

export class Note implements INote {
  Id: number;  Title: string;
  Description: string;
  Finished: boolean;
  NotebookId: number;
  CreatedBy: string;
  CreatedOn: string | Date;
  UpdatedBy: string;
  UpdatedOn: string | Date;
  Deleted: boolean;
  Timestamp: string;
}
