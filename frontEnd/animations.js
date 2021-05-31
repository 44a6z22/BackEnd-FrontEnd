function reveseFlex(e) {
  
  let element = document.getElementById('mainContainer');

  if (element.classList.contains('sm:flex-row')) {
    element.classList.add('sm:flex-row-reverse');
    element.classList.remove('sm:flex-row');
    e.target.classList.add('rotate');
    e.target.classList.remove('unrotate');
  } else if (element.classList.contains('sm:flex-row-reverse')) {
    element.classList.remove('sm:flex-row-reverse');
    element.classList.add('sm:flex-row');
    e.target.classList.add('unrotate');
    e.target.classList.remove('rotate');
  }

  if (element.classList.contains('flex-col')) {
    element.classList.add('flex-col-reverse');
    element.classList.remove('flex-col');
    e.target.classList.add('rotate');
    e.target.classList.remove('unrotate');
  } else if (element.classList.contains('flex-col-reverse')) {
    element.classList.remove('flex-col-reverse');
    element.classList.add('flex-col');
    e.target.classList.add('unrotate');
    e.target.classList.remove('rotate');
  }
}
