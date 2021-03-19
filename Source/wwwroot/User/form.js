// set variables 
let SubmitBtn = document.querySelector('#submit')
let errMessage = document.querySelector('.errMessage');
let errMessage = document.querySelector('.successMessage');

errMessage.style.textAlign = 'center'
successMessage.style.textAlign = 'center'

// remove error message 
const removeMessage = () =>{
    setTimeout(() => {
      errMessage.classList.add("d-none")
    },4000) 
   };

    //remove success message
    const removeSuccessMessage = () =>{
        setTimeout(() => {
          successMessage.classList.add("d-none")
        },5000) 
    };

   SubmitBtn.addEventListener('click', (e)=>{
    e.preventDefault();
   // validation
    let Name = document.querySelector('.name').value;
    let Email = document.querySelector('.email').value;
    let Account = document.querySelector('.acct-Num').value;
    let Category = document.querySelector('.category').value;
    let Date1 = document.querySelector('#Date1').value;
    let Date2 = document.querySelector('#Date2').value;
    let Description = document.querySelector('.textarea').value;
    let today = new Date().toISOString().split('T')[0];

       Date1.setAttribute('min', today);
       Date2.setAttribute('min', today);

    if(Name===""|| Name.length <= 2){
        errMessage.innerHTML ="Please enter a valid name";
        // console.log("Please enter a valid name");
        removeMessage();
        return false;
    }
    if(Account === "" || Account == null){
        let phoReg = /^\d{10}$/;
        if(!Account.match(phoReg)){
            errMessage.innerHTML = "Account Number is not valid"
            removeMessage();
            return false;
        }
    } 
    if(Email ===""){
        let emailReg =/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
        if(!Email.match(emailReg)){
            console.log('Email is invalid')
            // return true;
            errMessage.innerHTML ="Please enter a valid name";
            removeMessage();
            return false
        }     
    }
    if(Description.length <= 10){
        errMessage.innerHTML =  "Please enter more details";
        errMessage.classList.remove('d-none')
        removeMessage();
        return false;
      }

     if(Category === "Select"){
         errMessage.innerHTML="Please select a category";
         errMessage.classList.remove('d-none')
        removeMessage();
        return false;
     } 
});