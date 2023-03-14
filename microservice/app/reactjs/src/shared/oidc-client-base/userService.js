import { UserManager } from 'oidc-client';
import configApp from '../configApp/configApp'

// let env = process.env.REACT_APP_ENV;

let config = {
  authority: configApp.authority,
  client_id: configApp.client_id,
  redirect_uri: configApp.redirect_uri,
  response_type: configApp.response_type,
  client_secret: configApp.client_secret,
  scope: configApp.scope,
  post_logout_redirect_uri: configApp.post_logout_redirect_uri,
  automaticSilentRenew: true
};

const userManager = new UserManager(config)

export async function loadUserFromStorage() {
  try {
    let user = await userManager.getUser();
    if (user.expired == true) {
      user = await userManager.signinSilent();
    }
    return user;
  } catch (e) {
    console.error(`User not found: ${e}`)
  }
}

export async function signinSilent401() {
  try {
    let user = await userManager.signinSilent();
    return user;
  } catch (e) {
    console.error(`User not found: ${e}`)
  }
}

export function signinRedirect() {
  let urlCurrent = window.location.href;
  return userManager.signinRedirect({ state: urlCurrent })
}

export function signinRedirectCallback() {
  return userManager.signinRedirectCallback()
}

export function signoutRedirect() {
  userManager.clearStaleState()
  userManager.removeUser()
  return userManager.signoutRedirect()
}

export function signoutRedirectCallback() {
  userManager.clearStaleState()
  userManager.removeUser()
  return userManager.signoutRedirectCallback()
}

export default userManager