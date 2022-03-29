import { UserManagerSettings } from "oidc-client";


export class AuthService {
  
}



export function getClientSettings(): UserManagerSettings {
  return {
    // the URL of our identity server
    authority:  "https://localhost:5001",
    // this ID maps to the client ID in the identity client configuration
    client_id: "wewantdoughnuts", 
    // URL to redirect to after login
    redirect_uri: "http://localhost:3000/signin-oidc", 
    response_type: "id_token token",
    // the scopes or resources we would like access to
    scope: "openid profile doughnutapi", 
    // URL to redirect to after logout
    post_logout_redirect_uri: "http://localhost:3000/signout-oidc",
  };
}


// const config = {
//     // the URL of our identity server
//     authority: "https://localhost:5001", 
//     // this ID maps to the client ID in the identity client configuration
//     client_id: "wewantdoughnuts", 
//     // URL to redirect to after login
//     redirect_uri: "http://localhost:3000/signin-oidc", 
//     response_type: "id_token token",
//     // the scopes or resources we would like access to
//     scope: "openid profile doughnutapi", 
//     // URL to redirect to after logout
//     post_logout_redirect_uri: "http://localhost:3000/signout-oidc", 
//   };
  
//   // initialise!
//   const userManager = new UserManager(config)