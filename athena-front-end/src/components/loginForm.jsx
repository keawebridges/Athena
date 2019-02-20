import React, { Component } from "react";
import Joi from "joi-browser";
import Input from "../common/input";
class LoginForm extends Component {
  state = {
    account: { username: "", password: "" },
    errors: {}
  };
  //To prevent full page reload
  handleSubmit = e => {
    e.preventDefault();
    console.log("submitted");
  };

  handleChange = ({ currentTarget: input }) => {
    const account = { ...this.state.account };
    account[input.name] = input.value;
    this.setState({ account });
  };

  schema = {
    username: Joi.string().required(),
    password: Joi.string().required()
  };

  validate = () => {
    const result = Joi.validate(this.state.account, this.schema, {
      abortEarly: false
    });

    console.log(result);
  };

  render() {
    const { account } = this.state;
    return (
      <div className="d-flex justify-content-center h-100">
        <form onSubmit={this.handleSubmit}>
          <Input
            name="username"
            value={account.username}
            label="Username"
            onChange={this.handleChange}
          />
          <Input
            name="password"
            value={account.password}
            label="Password"
            onChange={this.handleChange}
          />
          <button onClick={this.validate} className="btn btn-primary">
            Log In
          </button>
        </form>
      </div>
    );
  }
}

export default LoginForm;
