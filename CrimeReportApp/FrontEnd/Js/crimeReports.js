// Fetch crime reports from the API
function getAllCrimeReports() {
    fetch('https:localhost:7116/api/CrimeReport')
      .then(response => response.json())
      .then(data => {
        // Display crime reports in HTML
        const reportsContainer = document.getElementById('crime-reports');
        reportsContainer.innerHTML = '';
  
        data.forEach(report => {
          const reportElement = document.createElement('div');
          reportElement.classList.add('report');
  
          const descriptionElement = document.createElement('p');
          descriptionElement.textContent = report.description;
  
          // Fetch user information using the userID
          fetch(`https:localhost:7116/api/User/${report.userID}`)
            .then(response => response.json())
            .then(user => {
              const username = user.username;
  
              const usernameElement = document.createElement('p');
              usernameElement.textContent = `Reported by: ${username}`;
  
              reportElement.appendChild(usernameElement);
            })
            .catch(error => {
              console.error('Error:', error);
            });
  
          reportElement.appendChild(descriptionElement);
          reportsContainer.appendChild(reportElement);
        });
      })
      .catch(error => {
        console.error('Error:', error);
      });
  }
  
  // Call the function to get all crime reports on page load
  document.addEventListener('DOMContentLoaded', getAllCrimeReports);
  