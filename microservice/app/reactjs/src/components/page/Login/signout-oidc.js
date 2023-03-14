import { useEffect } from 'react'
import { useHistory } from 'react-router-dom'
import { signoutRedirectCallback } from '../../../shared/oidc-client-base/userService'

function SignoutOidc() {
  const history = useHistory()
  useEffect(() => {
    async function signoutAsync() {
      await signoutRedirectCallback()
      history.push('/')
    }
    signoutAsync()
  }, [history])

  return (
    <div>
      Redirecting...
    </div>
  )
}

export default SignoutOidc
