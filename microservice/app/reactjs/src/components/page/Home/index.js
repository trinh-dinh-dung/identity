import { signoutRedirect } from "src/shared/oidc-client-base/userService";
import configApp from "src/shared/configApp/configApp";
import CommonBase from "src/shared/common/base";
import "src/shared/scss/page/home/Home.scss"

function Home(props) {

    const callApi = async () => {
        debugger
        let data = await CommonBase.getAsync(configApp.apiGateWay + '/api/api-service/home/call-data');
        debugger
        alert(5)
    };

    return (
        <div className="container home">
            <h1 className="title">Welcome</h1>
            <div style={{ background: '#dddddd', width: '200px', textAlign: 'center', cursor: 'pointer', margin: '20px 0' }} onClick={callApi}>Call api</div>

            <div style={{ background: 'red', width: '200px', textAlign: 'center', cursor: 'pointer' }} onClick={signoutRedirect}>Logout</div>
        </div>
    );
}

export default Home;