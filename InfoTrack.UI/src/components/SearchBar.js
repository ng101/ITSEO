import React from "react";

class SearchBar extends React.Component {
  state = {
    keywords: "land registry searches",
    searchProvider: "0",
    url: "www.infotrack.co.uk",
  };

  onFormSubmit = (event) => {
    event.preventDefault();
    this.props.onSubmit(
      this.state.keywords,
      this.state.searchProvider,
      this.state.url
    );
  };

  render() {
    return (
      <div className="ui segment">
        <form onSubmit={this.onFormSubmit} className="ui form">
          <div className="field">
            <label>Keywords</label>
            <input
              type="text"
              value={this.state.keywords}
              onChange={(e) => this.setState({ keywords: e.target.value })}
            />
            <label>Search Provider</label>
            <select
              value={this.state.searchProvider}
              onChange={(e) =>
                this.setState({ searchProvider: e.target.value })
              }
            >
              <option value="0">Google</option>
              <option value="1">Bing</option>
            </select>
            <label>Url</label>
            <input
              pattern="[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)"
              value={this.state.url}
              onChange={(e) => this.setState({ url: e.target.value })}
            />
          </div>
          <input type="submit" value="Submit" />
        </form>
      </div>
    );
  }
}

export default SearchBar;
