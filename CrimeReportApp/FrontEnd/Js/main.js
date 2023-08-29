var prevScrollPos = window.pageYOffset;
window.onscroll = function () {
    var currentScrollPos = window.pageYOffset;
    var navBar = document.querySelector('.nav-bar');

    if (prevScrollPos > currentScrollPos) {
        navBar.classList.remove("scroll-down");
        navBar.classList.add("scroll-up");
    } else {
        navBar.classList.remove("scroll-up");
        navBar.classList.add("scroll-down");
    }

    if (currentScrollPos === 0) {
        navBar.classList.remove("transparent");
    } else {
        navBar.classList.add("transparent");
    }

    prevScrollPos = currentScrollPos;
};


/*
const prevBtn = document.querySelector('.prev-btn');
const nextBtn = document.querySelector('.next-btn');
const crimeCardsScroll = document.querySelector('.crime-cards-scroll');
const cards = document.querySelectorAll('.crime-card');

let currentIndex = 1;

prevBtn.addEventListener('click', () => {
  currentIndex = Math.max(currentIndex - 1, 0);
  updateCardSizes();
  scrollToCurrentCard();
});

nextBtn.addEventListener('click', () => {
  currentIndex = Math.min(currentIndex + 1, cards.length - 1);
  updateCardSizes();
  scrollToCurrentCard();
});

function updateCardSizes() {
  for (let i = 0; i < cards.length; i++) {
    if (i === currentIndex - 1) {
      cards[i].classList.add('side-card-left');
      cards[i].classList.remove('center-card', 'side-card-right');
    } else if (i === currentIndex) {
      cards[i].classList.add('center-card');
      cards[i].classList.remove('side-card-left', 'side-card-right');
    } else if (i === currentIndex + 1) {
      cards[i].classList.add('side-card-right');
      cards[i].classList.remove('center-card', 'side-card-left');
    } else {
      cards[i].classList.remove('center-card', 'side-card-left', 'side-card-right');
    }
  }
}

function scrollToCurrentCard() {
  const scrollLeft = cards[currentIndex].offsetLeft - (crimeCardsScroll.offsetWidth - cards[currentIndex].offsetWidth) / 2;
  crimeCardsScroll.scrollTo({ left: scrollLeft, behavior: 'smooth' });
}

window.addEventListener('resize', () => {
  currentIndex = 1;
  updateCardSizes();
  scrollToCurrentCard();
});

// Initially set the current (middle) card to be larger
updateCardSizes();
scrollToCurrentCard();
*/
const prevBtn = document.querySelector('.prev-btn');
const nextBtn = document.querySelector('.next-btn');
const crimeCardsScroll = document.querySelector('.crime-cards-scroll');
const cards = document.querySelectorAll('.crime-card');

let currentIndex = 1;

prevBtn.addEventListener('click', () => {
  currentIndex = Math.max(currentIndex - 1, 0);
  updateCardSizes();
  scrollToCurrentCard();
});

nextBtn.addEventListener('click', () => {
  currentIndex = Math.min(currentIndex + 1, cards.length - 1);
  updateCardSizes();
  scrollToCurrentCard();
});

function updateCardSizes() {
  for (let i = 0; i < cards.length; i++) {
    if (i === currentIndex - 1) {
      cards[i].classList.add('side-card-left');
      cards[i].classList.remove('center-card', 'side-card-right');
    } else if (i === currentIndex) {
      cards[i].classList.add('center-card');
      cards[i].classList.remove('side-card-left', 'side-card-right');
    } else if (i === currentIndex + 1) {
      cards[i].classList.add('side-card-right');
      cards[i].classList.remove('center-card', 'side-card-left');
    } else {
      cards[i].classList.remove('center-card', 'side-card-left', 'side-card-right');
    }
  }
}

function scrollToCurrentCard() {
  const scrollLeft = cards[currentIndex].offsetLeft - (crimeCardsScroll.offsetWidth - cards[currentIndex].offsetWidth) / 2;
  crimeCardsScroll.scrollTo({ left: scrollLeft, behavior: 'smooth' });
}

window.addEventListener('resize', () => {
  currentIndex = 1;
  updateCardSizes();
  scrollToCurrentCard();
});

// Initially set the current (middle) card to be larger
updateCardSizes();
scrollToCurrentCard();


