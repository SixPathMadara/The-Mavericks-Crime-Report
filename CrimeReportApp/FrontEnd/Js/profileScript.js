//script for notification
document.getElementById('notified').addEventListener('click',function()
{
var notificationWrapper=document.querySelector('.notification_wrapper');
notificationWrapper.classList.toggle('visible');
});

//script for report display
const stats=document.querySelector(".stats");
const statsList=document.querySelector(".stats_list");
const firstStatWidth=stats.querySelector(".stats_list").offsetWidth;
const arrowBtns= document.querySelectorAll(".stats i");
const listChildren=[...stats.children];

let isDragging = false, isAutoPlay = true, startX, startScrollLeft, timeoutId;

let cardPerView = Math.round(stats.offsetWidth / firstStatWidth);
// Insert copies of the last few cards to beginning of carousel for infinite scrolling
listChildren.slice(-cardPerView).reverse().forEach(card => {
    stats.insertAdjacentHTML("afterbegin", stats.outerHTML);
});
// Insert copies of the first few cards to end of carousel for infinite scrollin
listChildren.slice(0, cardPerView).forEach(card => {
    stats.insertAdjacentHTML("beforeend", stats.outerHTML);
});
// Scroll the carousel at appropriate postition to hide first few duplicate cards on Firefox
stats.classList.add("no-transition");
stats.scrollLeft = stats.offsetWidth;
stats.classList.remove("no-transition");
// Add event listeners for the arrow buttons to scroll the carousel left and right
arrowBtns.forEach(btn => {
    btn.addEventListener("click", () => {
        stats.scrollLeft += btn.id == "left" ? -firstStatWidth : firstStatWidth;
    });
});
const dragStart = (e) => {
    isDragging = true;
    stats.classList.add("dragging");
    // Records the initial cursor and scroll position of the carousel
    startX = e.type === "mousedown" ? e.pageX : e.touches[0].pageX;
    startY = e.type === "mousedown" ? e.pageY : e.touches[0].pageY;

    startScrollLeft = stats.scrollLeft;
}
const dragging = (e) => {
    if(!isDragging) return; // if isDragging is false return from here
    // Updates the scroll position of the carousel based on the cursor movement
    const deltaX = (e.type === "mousemove" ? e.pageX : e.touches[0].pageX) - startX;
    const deltaY = (e.type === "mousemove" ? e.pageY : e.touches[0].pageY) - startY;
    // Only consider horizontal scroll if the user is not scrolling vertically
    if (Math.abs(deltaX) > Math.abs(deltaY)) {
        // Updates the scroll position of the carousel based on the cursor movement
        stats.scrollLeft = startScrollLeft - deltaX;
        e.preventDefault(); // Prevent accidental vertical scroll on touch devices
}
}
const dragStop = () => {
    isDragging = false;
    stats.classList.remove("dragging");
}
const infiniteScroll = () => {
    // If the carousel is at the beginning, scroll to the end
    if(stats.scrollLeft === 0) {
        stats.classList.add("no-transition");
        stats.scrollLeft = stats.scrollWidth - (1 * stats.offsetWidth);
        stats.classList.remove("no-transition");
    }
    // If the carousel is at the end, scroll to the beginning
    else if(Math.ceil(stats.scrollLeft) === stats.scrollWidth - stats.offsetWidth) {
        stats.classList.add("no-transition");
        stats.scrollLeft = stats.offsetWidth;
        stats.classList.remove("no-transition");
    }
    // Clear existing timeout & start autoplay if mouse is not hovering over carousel
    clearTimeout(timeoutId);
    if(!stats.matches(":hover")) autoPlay();
}
const autoPlay = () => {
    if(window.innerWidth < 800 || !isAutoPlay) return;
    timeoutId = setTimeout(() => stats.scrollLeft += firstStatWidth, 2500);
}
autoPlay();
statsList.addEventListener("mousedown", dragStart);
statsList.addEventListener("mousemove", dragging);
document.addEventListener("mouseup", dragStop);
statsList.addEventListener("touchstart", dragStart);
statsList.addEventListener("touchmove", dragging);
statsList.addEventListener("touchend", dragStop);
statsList.addEventListener("scroll", infiniteScroll);
stats.addEventListener("mouseenter", () => clearTimeout(timeoutId));
stats.addEventListener("mouseleave",autoPlay);