function reveseFlex() {
  var element = document.getElementById('mainContainer');
  if (element.classList.contains('flex-row')) {
    element.classList.add('flex-row-reverse');
    element.classList.remove('flex-row');
  } else if (element.classList.contains('flex-row-reverse')) {
    element.classList.remove('flex-row-reverse');
    element.classList.add('flex-row');
  }
}
