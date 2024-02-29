
using SWD607_Assignment2;
using Android.Content;
using Person_DataAndriod;
using SWD607_Assignment2.Models;
using Org.Apache.Http.Authentication;
using static Android.Provider.ContactsContract.CommonDataKinds;
namespace Auckland_Rangers

{
    [Activity( MainLauncher = true)]
    //Sign in progress
    public class SignInActivity : Activity
    {
        EditText edtusername, edtpassword;       
        Button ButtonLogin;
        Button ButtonHome;
        DatabaseManager Obj_databaseManager;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.SignIn);
            edtusername = FindViewById<EditText>(Resource.Id.editTextUsername);
            edtpassword = FindViewById<EditText>(Resource.Id.editTextPassword);
            ButtonLogin = FindViewById<Button>(Resource.Id.buttonLogin);
            ButtonHome = FindViewById<Button>(Resource.Id.buttonHome);

            Obj_databaseManager = new DatabaseManager();

            ButtonLogin.Click += LoginPressed;
            ButtonHome.Click += SignUpPressed;
        }
        private void LoginPressed(object sender, EventArgs e)
        {
            SignUp signup = new SignUp();
            if (edtusername.Text != string.Empty || edtpassword.Text != string.Empty)
            {
                
            }
            else
            {
                Toast.MakeText(this, "Please enter value in all field.", ToastLength.Long).Show();
            }
            

            

        
            
        }
        private void SignUpPressed(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SignUpActivity));
            StartActivity(intent);
        }
    }


    //SignUp progress
    public class SignUpActivity : Activity
    {
        
        DatabaseManager _dbManager;
        EditText username, password, firstname, lastname, phonenumber, email; 
        Button buttonSubmit;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.SignUp);
                buttonSubmit = FindViewById<Button>(Resource.Id.buttonSubmit);
                username = FindViewById<EditText>(Resource.Id.editTextUsername);
                password = FindViewById<EditText>(Resource.Id.editTextPassword);
                firstname = FindViewById<EditText>(Resource.Id.editTextFirstName);
                lastname = FindViewById<EditText>(Resource.Id.editTextLastName);
                phonenumber = FindViewById<EditText>(Resource.Id.editTextMobileNumber);
                email = FindViewById<EditText>(Resource.Id.editTextEmailAddress);

                _dbManager = new DatabaseManager();
                buttonSubmit.Click += SignUpPressed;
            }

        }
        private void SignUpPressed(Object sender, EventArgs e)
        {
            SignUp UpdateUserData = new SignUp()
            {
                UserName = username.Text,
                Password = password.Text,
                FirstName = firstname.Text,
                LastName = lastname.Text,
                PhoneNumber = phonenumber.Text,
                Email = email.Text
            };

            _dbManager.UpdateUser(UpdateUserData);
            Toast.MakeText(this, "Person Data is inserted successfully", ToastLength.Long).Show();          
            Intent intent = new Intent(this,typeof(SignInActivity));
            StartActivity(intent);
        }        
    }


    //Menu progress
    public class MenuActivity : Activity
    {
        ImageButton Ibtnmaincart;
        TextView txtMoreoptions;
        TextView txtViewall;
        Button buttonReservation1;
        Button buttonMenulist;
        ImageButton btnHome;
        ImageButton btnSearch;
        ImageButton btnContact;
        ImageButton btnProfile;
        ImageButton Ibtncart1;
        ImageButton Ibtncart2;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Menu);
            Ibtnmaincart = FindViewById<ImageButton>(Resource.Id.buttonCart);
            txtMoreoptions = FindViewById<TextView>(Resource.Id.textViewMoreOptions);
            txtViewall = FindViewById<TextView>(Resource.Id.textViewAll);
            buttonReservation1 = FindViewById<Button>(Resource.Id.buttonReservations);
            buttonMenulist = FindViewById<Button>(Resource.Id.buttonMenuLists);
            Ibtncart1 = FindViewById<ImageButton>(Resource.Id.buttonCartFeature1);
            Ibtncart2 = FindViewById<ImageButton>(Resource.Id.buttonCartFeature2);
            btnHome = FindViewById<ImageButton>(Resource.Id.buttonHome);
            btnSearch = FindViewById<ImageButton>(Resource.Id.buttonSearch);
            btnContact = FindViewById<ImageButton>(Resource.Id.buttonContactUs);
            btnProfile = FindViewById<ImageButton>(Resource.Id.buttonProfile);

            Ibtnmaincart.Click += MainCartPressed;
            buttonReservation1.Click += ReservationPressed;
            btnHome.Click += HomePressed;
            btnContact.Click += ContactUsPressed;
            btnProfile.Click += ProfilePressed;

            

        }
        private void MainCartPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(OrderdetailActivity));
            StartActivity(intent);
        }
        private void ReservationPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ReservationActivity));
            StartActivity(intent);
        }
        private void HomePressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MenuActivity));
            StartActivity(intent);
        }
        private void ContactUsPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ContactActivity));
            StartActivity(intent);
        }
        private void ProfilePressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ProfileActivity));
            StartActivity(intent);
        }
    }

    
    //Reservation progress
    public class ReservationActivity : Activity
    {
        Button btnAddEdit;
        Button btnDelete;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.Reservation);
                btnAddEdit = FindViewById<Button>(Resource.Id.buttonAddEdit);
                btnDelete = FindViewById<Button>(Resource.Id.buttonDelete);
                btnAddEdit.Click += AddEditPressed;
            }

        }
        private void AddEditPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AddEditActivity));
            StartActivity(intent);
        }
    }


    //Orderdetail
    public class OrderdetailActivity : Activity
    {
        Button btnPayment;
        ImageButton btnHome;
        ImageButton btnSearch;
        ImageButton btnContact;
        ImageButton btnProfile;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.OrderDetail);
                btnPayment = FindViewById<Button>(Resource.Id.buttonProceedToPayment);
                btnHome = FindViewById<ImageButton>(Resource.Id.buttonHome);
                btnSearch = FindViewById<ImageButton>(Resource.Id.buttonSearch);
                btnContact = FindViewById<ImageButton>(Resource.Id.buttonContactUs);
                btnProfile = FindViewById<ImageButton>(Resource.Id.buttonProfile);

                btnPayment.Click += PaymentPressed;
                btnHome.Click += HomePressed;
                btnContact.Click += ContactUsPressed;
                btnProfile.Click += ProfilePressed;

            }

        }
        private void PaymentPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(PaymentOptionActivity));
            StartActivity(intent);
        }
        private void HomePressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MenuActivity));
            StartActivity(intent);
        }
        private void ContactUsPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ContactActivity));
            StartActivity(intent);
        }
        private void ProfilePressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ProfileActivity));
            StartActivity(intent);
        }
    }


    //Contact Us
    public class ContactActivity : Activity
    {
        Button btnSend;
        ImageButton btnHome;
        ImageButton btnSearch;
        ImageButton btnContact;
        ImageButton btnProfile;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.ContactUs);
                btnSend = FindViewById<Button>(Resource.Id.buttonSend);
                btnHome = FindViewById<ImageButton>(Resource.Id.buttonHome);
                btnSearch = FindViewById<ImageButton>(Resource.Id.buttonSearch);
                btnContact = FindViewById<ImageButton>(Resource.Id.buttonContactUs);
                btnProfile = FindViewById<ImageButton>(Resource.Id.buttonProfile);

                btnSend.Click += SendPressed;
                btnHome.Click += HomePressed;
                btnContact.Click += ContactUsPressed;
                btnProfile.Click += ProfilePressed;

            }

        }
        private void SendPressed(Object sender, EventArgs e)
        {
            
        }
        private void HomePressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MenuActivity));
            StartActivity(intent);
        }
        private void ContactUsPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ContactActivity));
            StartActivity(intent);
        }
        private void ProfilePressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ProfileActivity));
            StartActivity(intent);
        }
    }


    //Profile
    public class ProfileActivity : Activity
    {
        Button Updatebtn;
        Button Deletebtn;
        int _userId;
        DatabaseManager _dbManager;
        EditText username, password, firstname, lastname, phonenumber, email;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.Profile);
                Updatebtn = FindViewById<Button>(Resource.Id.btnUpdate);
                Deletebtn = FindViewById<Button>(Resource.Id.btnDeleteAccount);
                base.OnCreate(bundle);
                {
                    SetContentView(Resource.Layout.SignUp);
                    Updatebtn = FindViewById<Button>(Resource.Id.btnUpdate);
                    Deletebtn = FindViewById<Button>(Resource.Id.btnDeleteAccount);
                    username = FindViewById<EditText>(Resource.Id.editTextUsername);
                    password = FindViewById<EditText>(Resource.Id.editTextPassword);
                    firstname = FindViewById<EditText>(Resource.Id.editTextFirstName);
                    lastname = FindViewById<EditText>(Resource.Id.editTextLastName);
                    phonenumber = FindViewById<EditText>(Resource.Id.editTextMobileNumber);
                    email = FindViewById<EditText>(Resource.Id.editTextEmailAddress);

                    _dbManager = new DatabaseManager();
                    _userId = Intent.GetIntExtra("UserId", 0);
                    SignUp objsignup = _dbManager.GetUserId(_userId);
                    if (objsignup != null)
                    {
                        username.Text = objsignup.UserName;
                        password.Text = objsignup.Password;
                        firstname.Text = objsignup.FirstName;
                        lastname.Text = objsignup.LastName;
                        phonenumber.Text = objsignup.PhoneNumber;
                        email.Text = objsignup.Email;
                    }
                    Updatebtn.Click += Updatepressed;
                    Deletebtn.Click += Deletepressed;
                }
            }

        }
        private void Updatepressed(Object sender, EventArgs e)
        {
            SignUp UpdateUserData = new SignUp()
            {
                Id = _userId,
                UserName = username.Text,
                Password = password.Text,
                FirstName = firstname.Text,
                LastName = lastname.Text,
                PhoneNumber = phonenumber.Text,
                Email = email.Text
            };

            _dbManager.UpdateUser(UpdateUserData);
            Toast.MakeText(this, "Person Data is updated successfully", ToastLength.Long).Show();

            Finish();
        }
        private void Deletepressed(Object sender, EventArgs e)
        {
            DatabaseManager dbm = new DatabaseManager();
            dbm.DeleteUser(_userId);
            Toast.MakeText(this, "Person Data is deleted successfully", ToastLength.Long).Show();
            Intent intent = new Intent(this, typeof(SignInActivity));
            StartActivity(intent);
        }
    }


    //Payment
    public class PaymentOptionActivity : Activity
    {
        ImageButton back;
        Button btncash;
        Button btncredit;
        ImageButton btnHome;
        ImageButton btnSearch;
        ImageButton btnContact;
        ImageButton btnProfile;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.PaymentOption);
                back = FindViewById<ImageButton>(Resource.Id.buttonBack);
                btncash = FindViewById<Button>(Resource.Id.buttonCash);
                btncredit = FindViewById<Button>(Resource.Id.buttonCard);
                btnHome = FindViewById<ImageButton>(Resource.Id.buttonHome);
                btnSearch = FindViewById<ImageButton>(Resource.Id.buttonSearch);
                btnContact = FindViewById<ImageButton>(Resource.Id.buttonContactUs);
                btnProfile = FindViewById<ImageButton>(Resource.Id.buttonProfile);

                back.Click += BacktoOrder;
                btnHome.Click += HomePressed;
                btnContact.Click += ContactUsPressed;
                btnProfile.Click += ProfilePressed;

            }

        }
        private void BacktoOrder(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(OrderdetailActivity));
            StartActivity(intent);
        }
        private void HomePressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MenuActivity));
            StartActivity(intent);
        }
        private void ContactUsPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ContactActivity));
            StartActivity(intent);
        }
        private void ProfilePressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ProfileActivity));
            StartActivity(intent);
        }
    }
    public class AddEditActivity : Activity
    {
        Button addbutton;
        Button editbutton;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.AddEdit);
                addbutton = FindViewById<Button>(Resource.Id.buttonAdd);
                editbutton = FindViewById<Button>(Resource.Id.buttonEdit);

            }

        }
    }

}