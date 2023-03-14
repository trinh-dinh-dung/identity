import React from "react";
import "./index.scss";
import configApp from "src/shared/configApp/configApp";
import { withRouter } from "react-router-dom";
const Index = (props) => {
    return (
        <div className="container">
            <div className="col-12 row">
                <div className="col-6 px-5" style={{ paddingTop: '20%' }}>
                    <div className="text-content">
                        <div className="title col-12">
                            Không tìm thấy trang
                        </div>
                        <div className="content col-12 pt-3">
                            Rất tiếc, không thể tìm thấy trang bạn yêu cầu Kiểm tra đường dẫn hoặc quay lại trang chủ.
                        </div>
                        <div className="button-back-home pt-5">
                            <button
                                className="home" onClick={(e) => {
                                    e.preventDefault();
                                    props.history.push("/");
                                }}>Về trang chủ</button>
                        </div>
                    </div>
                </div>
                <div className="col-6" style={{ paddingTop: '10%' }}>
                    <img className="img-fluid" src={configApp.urlCdn + "/assets/img/404-error/not-found.svg"} alt={configApp.urlCdn + "/assets/img/404-error/not-found.svg"} />
                </div>
            </div>
        </div>
    )
}

export default withRouter(Index);