import { Table } from './table';

export interface PracticeTable extends Table {
  possibleSets: Array<Array<number>>;
}
