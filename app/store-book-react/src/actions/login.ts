import Account from "../BusinessObjects/User";
import * as API from "../Helpers/apiCalls";
import * as statuses from "../Helpers/StatusConstants"
import fetchWrapper from "../Helpers/fetchWrapper";

export const login = async (user:Account)=>{
        fetchWrapper(API.login, {
            method: 'POST',
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json"
            },
            body: JSON.stringify(
                user)
        })
            .then((response: any) => {
                if (response.status === 200) {
                    return response.json();
                }
                if (response.status === 400) {
                    return statuses.ERROR;
                }
                return statuses.ERROR;
            })
            .then((data: any) => {
                switch (data) {
                    default:
                        onAuthentication(data);
                        break;
                }
            });
}

export const onAuthentication =  (user: any) => {
        fetchWrapper.setDefaultHeaders({
            Accept: "application/json",
            "Content-Type": "application/json",
            Authorization: `Bearer ${user.access_token}`
        });
};
