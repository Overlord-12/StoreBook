import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import Login from './pages/Login';
import reportWebVitals from './reportWebVitals';
import Nav from "./components/Nav";
import Register from "./pages/Register";
import {Route, BrowserRouter,Routes} from "react-router-dom";
import BookLibrary from "./pages/BookLibrary";

ReactDOM.render(
      <BrowserRouter>
          <div>
              <Nav/>
          </div>
          <div>
              <Routes>
                  <Route path ="/index" element={<BookLibrary/>}/>
                  <Route path="/Login" element={<Login/>}/>
                  <Route path="/Register" element={<Register/>}/>
              </Routes>
          </div>
      </BrowserRouter>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
