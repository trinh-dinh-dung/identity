import { HubConnectionBuilder } from '@microsoft/signalr';
import { useEffect, useRef, useState } from 'react';
import { withTranslation } from "react-i18next";
import { connect } from "react-redux";
import { withRouter } from "react-router-dom";
import { toast } from 'react-toastify';
import { bindActionCreators } from "redux";
import loginAction from 'src/redux-saga/action/Login/loginAction';
// import NotificationAction from "src/redux-saga/action/Notification/NotificationAction";
import configApp from '../../shared/configApp/configApp';
const ObjectMes = {
    Name: '',
    EntityId: '',
    Type: '',
    UserID: '',
    Url: '',
}
const typeApproval = {
    SOP: 'SOP',
    BOM: 'BOM',
    PROCESS: 'PROCESS',
}
const Chat = (props) => {
    const [connection, setConnection] = useState(null);
    const [chat, setChat] = useState([]);
    const latestChat = useRef(null);
    const convertURLApproval = (type) => {
        let url = '';
        switch (type) {
            case typeApproval.SOP:
                url = '/thong-tin-phe-duyet/:id';
                break;
            case typeApproval.BOM:
                url = '';
                break;
            //doing
            case typeApproval.PROCESS:
                url = '';
                break;
            default:
                break;
        }
        return url;
    }
    latestChat.current = chat;

    useEffect(() => {
        const newConnection = new HubConnectionBuilder()
            .withUrl(configApp.apiSocket + '/mesSignalr')
            .withAutomaticReconnect()
            .build();

        setConnection(newConnection);
    }, []);
    useEffect(() => {
        if (connection) {
            connection.start()
                .then(result => {
                    console.log('Connected!');
                    connection.on('ReceiveMessage', message => {
                        let idLogin = props.redecersLogin.userInfo.profile.sub;
                        let list = JSON.parse(message.message);
                        let obj = list.Info.find(m => m.UserID == idLogin);
                        console.log(obj);
                        //let obj = JSON.parse(message.message);
                        if (obj) {
                            obj.url = convertURLApproval(obj.Type)
                            props.notificationAction.addRecord(obj);
                            const updatedChat = [...latestChat.current];
                            updatedChat.push(message);
                            setChat(updatedChat);
                            let mes = '';
                            if (obj.Type == typeApproval.SOP) {
                                mes = 'Bạn có một phê duyệt SOP ' + obj.Name + " cần được xử lý";
                            }
                            else if (obj.Type == typeApproval.BOM) {
                                mes = "Bạn có một phê duyệt BOM " + obj.Name + " cần được xử lý";
                            }
                            toast.success(mes, {
                                position: "top-right",
                                autoClose: 1500,
                                hideProgressBar: false,
                                closeOnClick: true,
                                pauseOnHover: true,
                                draggable: true,
                                progress: undefined,
                            });
                        }
                    });
                })
                .catch(e => console.log('Connection failed: ', e));
        }
        // eslint-disable-next-line 
    }, [connection]);

    // const sendMessage = async (user, message) => { // mes call serve hub
    //     const chatMessage = {
    //         user: user,
    //         message: message
    //     };

    //     if (connection._connectionStarted) {
    //         try {
    //             await connection.send('SendMessage', chatMessage);
    //         }
    //         catch (e) {
    //             console.log(e);
    //         }
    //     }
    //     else {
    //         alert('No connection to server yet.');
    //     }
    // }

    return (
        null
    );
};
const mapDispatchToProps = (dispatch) => ({
    loginAction: bindActionCreators(loginAction, dispatch),
    notificationAction: bindActionCreators({}, dispatch),
});

const mapStateToProps = (state) => {
    return {
        redecersLogin: {
            userInfo: state.loginReducer.userInfo,
        },
    };
};
export default connect(
    mapStateToProps,
    mapDispatchToProps
)(withRouter(withTranslation()(Chat)));