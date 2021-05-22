class UserWebService {
    constructor(url) {
        this.Url = url 
        this.headers = new Headers();
        this.headers.append("Content-Type", "application/soap+xml");
    }

    register(user){
      let soapRegisterRequest = `<?xml version="1.0" encoding="utf-8"?>
      <soap12:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://www.w3.org/2003/05/soap-envelope">
      <soap12:Body>
          <AddUser xmlns="http://HDCETEST.org/">
          <username>${user.UserName}</username>
          <_password>${user.Password}</_password>
          <firstname>${user.FirstName}</firstname>
          <lastname>${user.LastName}</lastname>
          </AddUser>
      </soap12:Body>
      </soap12:Envelope>`
  return fetch("https://localhost:44353/UsersWebService.asmx", {
      mode: 'cors', 
      method: "POST", 
      body: soapRegisterRequest, 
      headers: this.headers
  }) 
  .then( (res) => { return res.text()} )
    }
    parser(string ){
      let domParser = new DOMParser();
      let doc = domParser.parseFromString(string, "text/xml");
      return doc;
  } 
    login(user){
      let soapRequest = `<?xml version="1.0" encoding="utf-8"?>
      <soap12:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://www.w3.org/2003/05/soap-envelope">
      <soap12:Body>
          <login xmlns="http://HDCETEST.org/">
          <username>${user.UserName}</username>
          <passwrod>${user.Password}</passwrod>
          </login>
      </soap12:Body>
      </soap12:Envelope>`; 
      return fetch (this.Url, {method:"POST", headers: this.headers, body: soapRequest})
      .then( (res) => res.text() )
    }
    getUsers(){
      let b = `<?xml version="1.0" encoding="utf-8"?>
      <soap12:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://www.w3.org/2003/05/soap-envelope">
        <soap12:Body>
          <getUsers xmlns="http://HDCETEST.org/" />
        </soap12:Body>
      </soap12:Envelope>`
         
          return fetch ("https://localhost:44353/UsersWebService.asmx", {method:"POST", headers: this.headers, body: b})
          .then( (res) => res.text() )
    }
}