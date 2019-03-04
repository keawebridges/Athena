import React, { Component } from "react";
import NavBar from "./components/navBar";
import Events from "./components/events";
import { Route, Switch, Redirect } from "react-router-dom";

import "./App.css";
import Announcements from "./components/announcements";
import MyTeam from "./components/myTeam";
import LoginForm from "./components/loginForm";
import NotFound from "./components/notfound";

class App extends Component {
  render() {
    return (
      <React.Fragment>
        <div className="container">
          <NavBar />
          <Switch>
            <Route path="/login" component={LoginForm} />
            <Route path="/events" component={Events} />
            <Route path="/announcements" component={Announcements} />
            <Route path="/myTeam" component={MyTeam} />
            <Route path="/notFound" component={NotFound} />
            <Redirect path="/" exact to="/login" />
            <Redirect to="/notFound" />
          </Switch>
        </div>
      </React.Fragment>
    );
  }
}

export default App;
