import { Layout } from 'antd';
import React, { Component } from "react";
import { connect } from "react-redux";
import { withRouter } from "react-router-dom";
const { Header, Content, Footer, Sider } = Layout;

class LayoutMain extends Component {
  constructor(props) {
    super(props);
    this.state = {
      toggled: false,
      isLoading: false,
      sidebarOpen: false,
    };
  }

  componentDidMount() {
    this.unlisten = this.props.history.listen((location, action) => {
      localStorage.setItem("sidebarOpen", false);
      this.setState({ sidebarOpen: false });
    });
  }
  render() {
    let { history, listMenu } = this.props;
    let { sidebarOpen } = this.state;
    return this.state.isLoading ? (
      null
    ) : (
      <div className="evomes-wrapper">
        <Layout >
          <Layout>
            <Content>
              <div id="page-display">
                {this.props.children}
              </div>
            </Content>
          </Layout>
        </Layout>
        
      </div>
    );
  }

}


const mapDispatchToProps = (dispatch) => ({
});
const mapStateToProps = (state) => {
  return {
    // listMenu: state.PermissionReducer.listMenu
  };
};
export default connect(
  mapStateToProps,
  mapDispatchToProps
)(withRouter(LayoutMain));




// export default withRouter(LayoutMain);
