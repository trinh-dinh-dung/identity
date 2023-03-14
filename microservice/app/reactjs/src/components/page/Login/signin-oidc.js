import { useEffect } from 'react'
import { useHistory } from 'react-router-dom'
import { signinRedirectCallback } from '../../../shared/oidc-client-base/userService'

function SigninOidc() {
  const history = useHistory()
  useEffect(() => {

    try {
      async function signinAsync() {
        let callback = await signinRedirectCallback()
        window.location.href = callback.state ? callback.state : "/";
      }
      signinAsync()
    } catch (error) {
      window.location.href = "/";
    }
  }, [history])

  return (
    <div>
      Redirecting...
    </div>
  )
}

export default SigninOidc
