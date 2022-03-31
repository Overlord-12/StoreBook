import * as API from "../Helpers/apiCalls";
import fetchWrapper from "../Helpers/fetchWrapper";
import {Container} from "react-dom";


export const booksLibrary = (setResult :any)=> {
        fetch(API.getBooks, {
            method: 'GET',
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json"
            },
        }).then(response  => response.json())
            .then(async result=>{
                await setResult(result)
            })
            .catch(error=>{
                console.error(error);
                setResult([]);
            });
}

