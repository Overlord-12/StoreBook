let defaultHeaders = {};

const fecthWrapper:any=function (url:string,params:any={}){
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
  Object.entries(params.body).forEach(([k, v]) => body.append(k, v));

  params.body = body;
 }
 return fetch(url,params)
}


export  default  fecthWrapper