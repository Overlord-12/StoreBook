import * as API from "../Helpers/apiCalls";
import fetchWrapper from "../Helpers/fetchWrapper";
import {Container} from "react-dom";


export const booksLibrary = ()=> {
    return new Promise<Container[]>((resolve)=> {
        fetchWrapper(API.getBooks, {
            method: 'GET',
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json"
            },
        }).then((response: any) => {
            if (response.status === 200) {
                resolve(response.json());
            }
            if (response.status === 400) {
                resolve([]);
            }
            return response.status;
        })
    });
}

