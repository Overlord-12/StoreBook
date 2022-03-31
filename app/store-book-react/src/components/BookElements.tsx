import Book from "../BusinessObjects/Book";

interface IProps{
    book:Book
}

const BookElements =(props:IProps)=>{
    const book = props;
    return(

            <p>book.</p>

    )
}
export default BookElements