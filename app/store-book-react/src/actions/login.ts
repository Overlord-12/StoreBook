import Account from "../BusinessObjects/User";
import * as API from "../Helpers/apiCalls";
import fetchWrapper from "../Helpers/fetchWrapper";

export const login = async (user:Account)=>{
        await fetch(API.login,{
            method: 'POST',
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json"
            },
            body: JSON.stringify(
                user)
        }).then((response: any) => {
            if (response.status === 200) {
                let result = response.json();
            }
            if (response.status === 400) {
                return 400;
            }
            return response.status;
    });
}

export const onAuthentication = (user: any) => {
    return (dispatch: any) => {
        fetchWrapper.setDefaultHeaders({
            Accept: "application/json",
            "Content-Type": "application/json",
            Authorization: `Bearer ${user.token}`
        });
    };
};
