let defaultHeaders = {};

const fetchWrapper:any=function (url:string,params:any={}){
 params.headers = Object.assign(
     {},
     params.headers,
     defaultHeaders,
 );
 if (
     params.body &&
     typeof params.body !== "string" &&
     !(params.body instanceof FormData)
 ){
  const body = new FormData();

  params.body = body;
 }

 return fetch(url,params)
}



fetchWrapper.setDefaultHeaders = function(headers: Headers) {
 defaultHeaders = headers;
};


export  default  fetchWrapper