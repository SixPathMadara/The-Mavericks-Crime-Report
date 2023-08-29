// Function to show the loader
function showLoader() {
    document.querySelector('.loader').style.display = 'block';
  }
  
  // Function to hide the loader
  function hideLoader() {
    document.querySelector('.loader').style.display = 'none';
  }
  
  // Example usage when making API calls or performing actions
  function fetchDataFromAPI() {
    showLoader();
  
    // Perform the API call or action
    // ...
  
    // After the API call or action is completed, hide the loader
    hideLoader();
  }
  