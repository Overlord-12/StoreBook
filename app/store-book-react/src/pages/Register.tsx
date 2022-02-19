import React, {useState} from 'react';
import Account from "../BusinessObjects/User";
import '../styles/Login.css';
import {register} from "../actions/register";
import {Navigate} from "react-router-dom"

function Register() {

    const [name,setName] = useState('');
    const[password, setPassword] = useState('');
    const [repeatPassword,setRepeatPassword ] = useState('');
    const [redirect,setRedirect] = useState(false);

    const submit = async ()=>{
        if(repeatPassword !== password)
            return <h1>Пароли не совпадают</h1>;
        let user:Account = {Name:name,Password:password}
        await register(user);
        setRedirect(true);
    }

    if(redirect){
        return <Navigate to="/Login" replace={true}/>
    }

    return (
        <div className="Register">
            <form className="form-signin" onSubmit={submit}>
                    <h1 className="h3 mb-3 fw-normal">Register</h1>

                    <div className="form-floating">
                        <input type="email" className="form-control"  placeholder="name@example.com"
                               value = {name}
                               onChange={e=>setName(e.target.value)}
                        />
                            <label htmlFor="floatingInput">Email address</label>
                    </div>
                    <div className="form-floating">
                        <input type="password" className="form-control" placeholder="Password"
                               value = {password}
                               onChange={e=>setPassword(e.target.value)}
                               />
                            <label htmlFor="floatingPassword">Password</label>
                    </div>
                    <div className="form-floating">
                        <input type="password" className="form-control" placeholder="Repeat password"
                               value = {repeatPassword}
                               onChange={e=>setRepeatPassword(e.target.value)}
                        />
                        <label htmlFor="floatingPassword">Repeat password</label>
                    </div>
                    <button className="w-100 btn btn-lg btn-primary" type="submit">Create a new account</button>
            </form>
        </div>
    );
}

export default Register;