
import { Base } from './base';
export  class AuditBase extends Base {
    CreatedBy: string;

    CreatedOn: Date | string | null;

    UpdatedBy: string;

    UpdatedOn: Date | string | null;
}

