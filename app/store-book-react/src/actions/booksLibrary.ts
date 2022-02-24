import * as API from "../Helpers/apiCalls";
import fetchWrapper from "../Helpers/fetchWrapper";


export const booksLibrary = async ()=> {
    await fetchWrapper(API.getBooks,{
        method: 'GET',
        headers: {
            Accept: "application/json",
            "Content-Type": "application/json"
        },
    }).then((response: any) => {
        if (response.status === 200) {
            return response.json();
        }
        if (response.status === 400) {
            return 400;
        }
        return response.status;
    });
}
