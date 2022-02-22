import * as API from "../Helpers/apiCalls";


export const booksLibrary = async ()=> {
    await fetch(API.getBooks,{
        method: 'GET',
        credentials: 'include',
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
