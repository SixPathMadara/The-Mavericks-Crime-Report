// Define the number of posts per page
const POSTS_PER_PAGE = 6;

// Get the post container and pagination elements
const postContainer = document.querySelector('.sidebar');
const prevButton = document.querySelector('#prev-page');
const nextButton = document.querySelector('#next-page');
const pageNumber = document.querySelector('#page-number');

// Load the initial page of posts
let currentPage = 1;
loadPosts(currentPage);

// Add event listeners to the pagination buttons
prevButton.addEventListener('click', () => {
  if (currentPage > 1) {
    currentPage--;
    loadPosts(currentPage);
  }
});

nextButton.addEventListener('click', () => {
  currentPage++;
  loadPosts(currentPage);
});

// Function to load the posts for the given page number
function loadPosts(page) {
  // Calculate the index of the first and last posts to display
  const startIndex = (page - 1) * POSTS_PER_PAGE;
  const endIndex = startIndex + POSTS_PER_PAGE;

  // Get all the posts and convert them to an array
  const posts = Array.from(postContainer.querySelectorAll('.post'));

  // Hide all posts that are not in the current page range
  posts.forEach((post, index) => {
    if (index >= startIndex && index < endIndex) {
      post.style.display = 'block';
    } else {
      post.style.display = 'none';
    }
  });

  // Update the page number indicator
  pageNumber.textContent = `Page ${currentPage}`;
}