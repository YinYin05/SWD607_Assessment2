
using SWD607_Assignment2;
using Android.Content;
namespace Auckland_Rangers

{
    [Activity( MainLauncher = true)]
    //Sign in progress
    public class SignInActivity : Activity
    {
        Button ButtonLogin;
        Button ButtonHome;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.SignIn);

            ButtonLogin = FindViewById<Button>(Resource.Id.buttonLogin);
            ButtonHome = FindViewById<Button>(Resource.Id.buttonHome);

            ButtonLogin.Click += LoginPressed;
            ButtonHome.Click += SignUpPressed;
        }
        private void LoginPressed(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MenuActivity));
            StartActivity(intent);
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
        Button buttonSubmit;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.SignUp);
                buttonSubmit = FindViewById<Button>(Resource.Id.buttonSubmit);
                buttonSubmit.Click += SignUpPressed;
            }

        }
        private void SignUpPressed(Object sender, EventArgs e)
        {
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

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.Profile);
                Updatebtn = FindViewById<Button>(Resource.Id.btnUpdate);
                Deletebtn = FindViewById<Button>(Resource.Id.btnDeleteAccount);

                Updatebtn.Click += Updatepressed;
                Deletebtn.Click += Deletepressed;

            }

        }
        private void Updatepressed(Object sender, EventArgs e)
        {

        }
        private void Deletepressed(Object sender, EventArgs e)
        {

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
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.AddEdit);

            }

        }
    }

}