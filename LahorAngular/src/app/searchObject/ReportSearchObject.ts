import { ReportType } from '../core/enumerations/reportType';
import { BaseSearchObject } from './BaseSearchObject';

export class ReportSearchObject extends BaseSearchObject {
  reportType: ReportType;
  dateFrom: string;
  dateTo: string;
}
