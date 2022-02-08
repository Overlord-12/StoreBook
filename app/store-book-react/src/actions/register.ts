import Account from "../BusinessObjects/User";
import * as API from "../Helpers/apiCalls";

export const register = async (user:Account)=>{
    const response = await fetch(API.register,{
        method: 'POST',
        headers: {
            Accept: "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify(
            user)
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
