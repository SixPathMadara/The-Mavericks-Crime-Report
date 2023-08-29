//get all the images in the list
const imageListItems=document.querySelectorAll('#image-list li');

function showNextImage(){
    const currImage=document.querySelector('#image-list li:not([style*="display: none"])');
    const currIndex=Array.from(imageListItems).indexOf(currImage);
    const nextIndex=(currIndex +1) % imageListItems.length;

    currImage.style.display='none';

    imageListItems[nextIndex].style.display='block';
}

setInterval(showNextImage,4000);