import React, {useState} from 'react';
import Account from "../BusinessObjects/User";
import * as API from "../Helpers/apiCalls";
import '../styles/Login.css';
import {METHODS} from "http";
import {register} from "../actions/register";

function Register() {

    const [name,setName] = useState('');
    const[password, setPassword] = useState('');

    const submit = async ()=>{
        let user:Account = {Name:name,Password:password}
        await register(user);
    }

    return (
        <div className="Login">
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
                        <input type="password" className="form-control" placeholder="Password"
                               value = {password}
                               onChange={e=>setPassword(e.target.value)}
                        />
                        <label htmlFor="floatingPassword">Password</label>
                    </div>
                    <button className="w-100 btn btn-lg btn-primary" type="submit">Create a new account</button>
            </form>
        </div>
    );
}

export default Register;