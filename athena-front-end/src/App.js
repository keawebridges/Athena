import React, { Component } from "react";
import logo from "./logo.svg";
import NavBar from "./components/navBar";
import Events from "./components/events";
import { Route, Switch } from "react-router-dom";

import "./App.css";
import Announcements from "./components/announcements";
import MyTeam from "./components/myTeam";
import LoginForm from "./components/loginForm";

class App extends Component {
  render() {
    return (
      <React.Fragment>
        <div className="content">
          <NavBar />
          <Switch>
            <Route path="/login" component={LoginForm} />
            <Route path="/announcements" component={Announcements} />
            <Route path="/myTeam" component={MyTeam} />
            <Route path="/" component={Events} />
          </Switch>
        </div>
      </React.Fragment>
    );
  }
}

export default App;
