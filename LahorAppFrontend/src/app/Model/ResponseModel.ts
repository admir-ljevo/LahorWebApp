import {ResponseCode} from "../enum/ResponseCode";

export class ResponseModel{
  public responseCode:ResponseCode=ResponseCode.NotSet;
  public ResponseMessage:string="";
  public DataSet:any;
}
