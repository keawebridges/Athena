import React, { Component } from "react";
import axios from "axios";
import http from "../services/httpService";
import config from "../config.json";
import Pagination from "../common/pagination";
class Events extends Component {
  state = {
    events: [],
    pageSize: 4
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

  handlePageChange = page => {
    console.log(page);
  };

  render() {
    const { length: count } = this.state.events;

    return (
      <React.Fragment>
        <table className="table">
          <thead>
            <tr>
              <th>Event Name</th>
            </tr>
          </thead>
          <tbody>
            {this.state.events.map(event => (
              <tr key={event.id}>
                <td>{event.username}</td>
              </tr>
            ))}
          </tbody>
        </table>
        <Pagination
          itemsCount={count}
          pageSize={this.state.pageSize}
          onPageChange={this.handlePageChange}
        />
      </React.Fragment>
    );
  }
}

export default Events;
