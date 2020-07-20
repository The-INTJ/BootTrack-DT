function toggleShow(a) {
    a.parentNode.getElementsByClassName('dropdown-content')[0].classList.toggle("show");
}

/* Change main selector text to option clicked */
function changeText(option) {
    if (option.innerText === 'Submit for Review') {
        option.parentNode.parentNode.querySelector('.dropbtn').innerText = 'Under Review';
    } else if (option.innerText === 'Approve') {
        option.parentNode.parentNode.querySelector('.dropbtn').innerText = 'Completed';
    } else {
        option.parentNode.parentNode.querySelector('.dropbtn').innerText = option.innerText;
    }

    if (option.innerText === 'In Progress') {
        option.parentNode.parentNode.querySelector('.dropbtn').style.backgroundColor = '#F0E8A0';
    } else if (option.innerText === 'Submit for Review') {
        option.parentNode.parentNode.querySelector('.dropbtn').style.backgroundColor = '#FFA7A7';
        option.parentNode.parentNode.querySelector('.dropbtn').style.fontSize = "9px";
    } else if (option.innerText === 'Reject') {
        option.parentNode.parentNode.querySelector('.dropbtn').style.backgroundColor = '#FFA7A7';
    } else if (option.innerText === 'Approve') {
        option.parentNode.parentNode.querySelector('.dropbtn').style.backgroundColor = '#99EAB9';
    } else {
        option.parentNode.parentNode.querySelector('.dropbtn').style.backgroundColor = '#E5E5E5';
    }
}

// Close the dropdown menu if the user clicks outside of it
window.onclick = function (event) {
    if (!event.target.matches('.dropbtn')) {
        var dropdowns = document.getElementsByClassName("dropdown-content");
        var i;
        for (i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('show')) {
                openDropdown.classList.remove('show');
            }
        }
    }
}