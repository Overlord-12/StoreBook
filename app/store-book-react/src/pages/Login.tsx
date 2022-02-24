import React, {useState} from 'react';
import Account from "../BusinessObjects/User";
import '../styles/Login.css'
import {login} from "../actions/login";

function Login() {
    const [name,setName] = useState('');
    const[password, setPassword] = useState('');

    const submit = async (e:any)=>{
        e.preventDefault();
        let user:Account = {Email:name,Password:password}
        await login(user);
    }

    return (
        <div className="Login">
                <form className="form-signin" onSubmit={submit}>
                    <h1 className="h3 mb-3 fw-normal">Login</h1>

                    <div className="form-floating">
                        <input type="string" className="form-control"  placeholder="name@example.com"
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
                    <button className="w-100 btn btn-lg btn-primary" type="submit">Login</button>
                </form>
        </div>
    );
}

export default Login;