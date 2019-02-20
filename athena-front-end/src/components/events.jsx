import React, { Component } from "react";
import axios from "axios";
import http from "../services/httpService";
import config from "../config.json";
class Events extends Component {
  state = {
    events: []
  };

  async componentDidMount() {
    const { data: events } = await http.get(config.apiEndPoint);
    this.setState({ events });
  }

  handleAdd = () => {
    console.log("Add");
  };

  handleUpdate = event => {
    console.log("Updating");
  };

  handleDelete = event => {};

  render() {
    return (
      <div>
        <h1>Events!</h1>
        <table className="table">
          <thead>
            <tr>
              <th>Event Name</th>
            </tr>
          </thead>
          <tbody>
            {this.state.events.map(event => (
              <tr key={event.id}>
                <td>{event.tE_Name}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    );
  }
}

export default Events;
