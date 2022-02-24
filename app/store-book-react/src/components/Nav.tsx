import React from 'react';
import '../styles/Nav.css';
import {NavLink} from "react-router-dom";
import Login from '../pages/Login'

function Nav() {
    return (
        <nav className="navbar navbar-expand-md navbar-dark fixed-top bg-dark">
            <div className="container-fluid">
                <NavLink to="/index" className="nav-link active">StoreBook</NavLink>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse"
                        data-bs-target="#navbarCollapse" aria-controls="navbarCollapse" aria-expanded="false"
                        aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarCollapse">
                    <ul className="navbar-nav me-auto mb-2 mb-md-0">
                        <NavLink to="/Login" className="nav-link active">Login</NavLink>
                        <NavLink to="/Register" className="nav-link active">Register</NavLink>
                    </ul>
                </div>
            </div>
        </nav>
    );
}

export default Nav;