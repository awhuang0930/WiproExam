import { Injectable } from '@angular/core';
//import 'rxjs/add/operator/toPromise';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import Config from '../assets/config';

@Injectable()
export class HttpRestService {
    //    private c_Url = 'http://localhost:9004';  // URL to web API
    //private c_Url = 'http://localhost:55403/api';  // URL to web API
    private c_Url;

    constructor(private http: HttpClient) 
        { 
            this.c_Url = Config.RestUrl;
        }

    // send a PUT request to the API to Add/Update/Delete a data object
    AddDataRecord(resourceName: string, obj: any) {
        let body = JSON.stringify(obj);
        console.log("allan in post:" + `${this.c_Url}/${resourceName}`);
        console.log("body in post:" + `${body}`);
        return this.http.post<Number>(`${this.c_Url}/${resourceName}`, body, {
            headers: new HttpHeaders({ 'Content-Type': 'application/json'}),
        });
    }

    GetDataRecord(resourceName: string) {
        console.log("allan in post:" + `${this.c_Url}/${resourceName}`);
        return this.http.get(`${this.c_Url}/${resourceName}`).toPromise();

    }
}