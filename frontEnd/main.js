let userWebService = new UserWebService(
  'https://localhost:44353/UsersWebService.asmx',
);

document.getElementById('loginButton').addEventListener('click', login);
document.getElementById('registerButton').addEventListener('click', register);

const loginUserName = document.getElementById('userName');
const loginPassword = document.getElementById('password');
const registerFirstName = document.getElementById('registerFirstName');
const registerLastName = document.getElementById('registerLastName');
const registerUsername = document.getElementById('RegisterUserName');
const registerPassword = document.getElementById('registerPassword');
const tableBody = document.getElementById('body');

function login() {
  let user = new User(loginUserName.value, loginPassword.value);
  userWebService.login(user).then((data) => {
    let doc = userWebService.parser(data);
    let elements = doc.getElementsByTagName('loginResult');
    if (elements.length === 0) {
      alert('username or password are wrong');
    } else {
      localStorage.setItem('useron', 'username');
      window.location.href = './usersList.html';
    }
  });
}

function register() {
  let user = new User(
    registerUsername.value,
    registerPassword.value,
    registerFirstName.value,
    registerLastName.value,
  );

  userWebService
    .register(user)
    .then((data) => {
      let doc = userWebService.parser(data);
      if (
        doc.getElementsByTagName('AddUserResponse')[0].textContent == 'true'
      ) {
        alert('success');
      }
    })
    .catch((err) => console.log(err));
}

userWebService.getUsers().then((data) => {
  let doc = userWebService.parser(data);
  let elements = doc.getElementsByTagName('User');

  for (let i = 0; i < elements.length; i++) {
    let tr = document.createElement('tr');
    let tdFirstName = document.createElement('td');
    let tdLastName = document.createElement('td');
    let tdCreates = document.createElement('td');
    tdFirstName.textContent =
      elements[i].getElementsByTagName('FirstName')[0].textContent;
    tdLastName.textContent =
      elements[i].getElementsByTagName('LastName')[0].textContent;
    tdCreates.textContent =
      elements[i].getElementsByTagName('Created')[0].textContent;
    tr.appendChild(tdFirstName);
    tr.appendChild(tdLastName);
    tr.appendChild(tdCreates);
    tableBody.appendChild(tr);
  }
});

function logout() {
  localStorage.clear();
}
