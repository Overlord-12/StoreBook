import {booksLibrary} from "../actions/booksLibrary";
import Book from "../BusinessObjects/Book"
import {useEffect, useState} from "react";
import {useDispatch} from "react-redux";



function BookLibrary(){
const [Book,setBooks] = useState<Book[]>([]);
const [firstLoad, setLoad] = useState<Boolean>(true)

useEffect(()=>{


},[Book])

const loadBooks=()=>{
    if(firstLoad){
        booksLibrary(setBooks);
        setLoad(false);
    }
}

    loadBooks();
    return(
        <div>
            <h1>Hi is's books library</h1>
            <div>
                Book.
            </div>
        </div>

    );
}

export default BookLibrary