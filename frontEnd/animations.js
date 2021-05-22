function reveseFlex(e) {
  let element = document.getElementById('mainContainer');

  if (element.classList.contains('flex-row')) {
    element.classList.add('flex-row-reverse');
    element.classList.remove('flex-row');
    e.target.classList.add('rotate');
    e.target.classList.remove('unrotate');
  } else if (element.classList.contains('flex-row-reverse')) {
    element.classList.remove('flex-row-reverse');
    element.classList.add('flex-row');
    e.target.classList.add('unrotate');
    e.target.classList.remove('rotate');
  }
}
