let defaultHeaders = {};

const fetchWrapper:any=function (url:string,params:any={}){
 params.headers = Object.assign(
     {},
     defaultHeaders,
     params.headers
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

const headerDict = function(headers: any) {
 let dict: any = {};


 return dict;
};

fetchWrapper.setDefaultHeaders = function(headers: any) {
 defaultHeaders = headerDict(headers);
};


export  default  fetchWrapper