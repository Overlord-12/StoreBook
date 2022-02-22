import {booksLibrary} from "../actions/booksLibrary";

function BookLibrary(){
const books = booksLibrary();

    return(
        <div>
            <h1>Hi is's books library</h1>
        </div>
    );
}

export default BookLibrary