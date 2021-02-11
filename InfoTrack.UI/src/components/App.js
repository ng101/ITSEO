import React from "react";
import SearchBar from "./SearchBar";
import infoTrackClient from "../api/InfoTrackClient";
import ClipLoader from "react-spinners/ClipLoader";

class App extends React.Component {
  state = { ranking: "", loading: false };

  onSearchSubmit = async (keywords, searchProvider, url) => {
    this.setState({ loading: true });
    this.setState({ ranking: "" });

    try {
      const response = await infoTrackClient.post("/api/Seo", {
        keywords: keywords,
        searchProvider: searchProvider,
        url: url,
      });
      this.setState({ ranking: response.data.searchPosition });
    } catch (err) {
      console.log(err);
    } finally {
      this.setState({ loading: false });
    }
  };

  render() {
    return (
      <div className="ui container">
        <h1>InfoTrack Search Ranking Finder</h1>
        <SearchBar onSubmit={this.onSearchSubmit} />
        <div>
          <h3>Search Rankings</h3>
          <ClipLoader loading={this.state.loading} size={10} />
          {this.state.ranking}
        </div>
      </div>
    );
  }
}

export default App;
