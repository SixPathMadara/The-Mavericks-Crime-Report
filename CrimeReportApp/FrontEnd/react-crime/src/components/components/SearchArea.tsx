// src/components/SearchArea.tsx
import React from "react";

const SearchArea: React.FC = () => {
  return (
    <div className="search-area">
      <div className="search-box">
        <button className="btn-search">
          <i className="fa fa-search"></i>
        </button>
        <input
          type="text"
          className="input-search"
          placeholder="Type to Search..."
        />
      </div>
    </div>
  );
};

export default SearchArea;
