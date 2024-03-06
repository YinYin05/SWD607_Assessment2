
using SWD607_Assignment2;
using Android.Content;
using Person_DataAndriod;
using SWD607_Assignment2.Models;
using Newtonsoft.Json;
using System.Text;
using System.Runtime.InteropServices;
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
            
            string username = edtusername.Text;
            string password = edtpassword.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Toast.MakeText(this, "Please enter both username and password", ToastLength.Short).Show();
                return;
            }
            else
            {
                SignUp signup = Obj_databaseManager.GetUserName(username);

                if (signup != null && signup.Password == password)
                {
                    Intent Login_intent = new Intent(this, typeof(MenuActivity));            
                    StartActivity(Login_intent);
                }
                else
                {
                    Toast.MakeText(this, "Please enter correct one", ToastLength.Short).Show();
                    return;
                }
            }            
        }
        private void SignUpPressed(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SignUpActivity));
            StartActivity(intent);
            //'Unable to find explicit activity class {com.companyname.SWD607_Assignment2/crc64b8371ed0b9bbb922.SignUpActivity};
            //have you declared this activity in your AndroidManifest.xml, or does your intent not match its declared <intent-filter>?'
        }
    }

    [Activity(Label ="SignUp")]
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

            _dbManager.InsertUser(UpdateUserData);
            Toast.MakeText(this, "Person Data is inserted successfully", ToastLength.Long).Show();          
            Intent intent = new Intent(this,typeof(SignInActivity));
            StartActivity(intent);
        }        
    }


    //Menu progress
    [Activity(Label = "Menu")]
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
            Ibtncart1.Click += MainCartPressed;
            Ibtncart2.Click += MainCartPressed;
            txtMoreoptions.Click += MainCartPressed;
            txtViewall.Click += MainCartPressed;
            buttonMenulist.Click += MainCartPressed;
            buttonReservation1.Click += ReservationPressed;
            btnHome.Click += HomePressed;
            btnContact.Click += ContactUsPressed;
            btnProfile.Click += ProfilePressed;
            btnSearch.Click += SearchPressed;

            

        }
        private void SearchPressed(Object sender, EventArgs e)
        {
            SearchActivity search = new SearchActivity();
            Intent intent = new Intent(this, typeof(SearchActivity));
            StartActivity(intent);
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
    [Activity(Label = "reservation")]
    public class ReservationActivity : Activity
    {
        ImageButton backbtn;
        Button btnAddEdit;
        Button btnDelete;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.Reservation);
                btnAddEdit = FindViewById<Button>(Resource.Id.buttonAddEdit);
                backbtn = FindViewById<ImageButton>(Resource.Id.buttonBack);
                btnDelete = FindViewById<Button>(Resource.Id.buttonDelete);


                backbtn.Click += BackPressed;
                btnAddEdit.Click += AddEditPressed;
            }

        }
        private void BackPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MenuActivity));
            StartActivity(intent);
        }
        private void AddEditPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AddEditActivity));
            StartActivity(intent);
        }
    }


    //Orderdetail
    [Activity(Label = "Orderdetail")]
    public class OrderdetailActivity : Activity
    {
        EditText CheeseRoll, Pavlova, OnionDip, HokeyPokey, Fritter;
        ImageButton backbtn;
        ImageView food1, food2, food3, food4, food5;
        Button deletebtn1, deletebtn2, deletebtn3, deletebtn4, deletebtn5, btnPayment;
        ImageButton btnHome, btnSearch, btnContact, btnProfile;
        TextView cost1, cost2, cost3, cost4, cost5, orderdate, subtotal,totalGST,totalCost;
        int Quan1, Quan2, Quan3, Quan4, Quan5, result1, result2, result3, result4, result5;
        float TotalPrice;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.OrderDetail);
                orderdate = FindViewById<TextView>(Resource.Id.textViewCurrentDate);
                subtotal = FindViewById<TextView>(Resource.Id.textViewSubTotalAmount);
                totalGST = FindViewById<TextView>(Resource.Id.textViewTotalGST);
                totalCost = FindViewById<TextView>(Resource.Id.textViewTotalAmount);
                btnPayment = FindViewById<Button>(Resource.Id.buttonProceedToPayment);
                btnHome = FindViewById<ImageButton>(Resource.Id.buttonHome);
                btnSearch = FindViewById<ImageButton>(Resource.Id.buttonSearch);
                btnContact = FindViewById<ImageButton>(Resource.Id.buttonContactUs);
                btnProfile = FindViewById<ImageButton>(Resource.Id.buttonProfile);
                CheeseRoll = FindViewById<EditText>(Resource.Id.foodQuantity1);
                Pavlova = FindViewById<EditText>(Resource.Id.foodQuantity2);
                OnionDip = FindViewById<EditText>(Resource.Id.foodQuantity3);
                HokeyPokey = FindViewById<EditText>(Resource.Id.foodQuantity4);
                Fritter = FindViewById<EditText>(Resource.Id.foodQuantity5);
                food1 = FindViewById<ImageView>(Resource.Id.imageSouthlandCheeseRolls);
                food2 = FindViewById<ImageView>(Resource.Id.imageKiwiPavlova);
                food3 = FindViewById<ImageView>(Resource.Id.imageOnionDip);
                food4 = FindViewById<ImageView>(Resource.Id.imageHokeyPokey);
                food5 = FindViewById<ImageView>(Resource.Id.imageWhitebaitFritters);
                backbtn = FindViewById<ImageButton>(Resource.Id.buttonBack);
                deletebtn1 = FindViewById<Button>(Resource.Id.deleteButton);
                deletebtn2 = FindViewById<Button>(Resource.Id.deleteButton2);
                deletebtn3 = FindViewById<Button>(Resource.Id.deleteButton3);
                deletebtn4 = FindViewById<Button>(Resource.Id.deleteButton4);
                deletebtn5 = FindViewById<Button>(Resource.Id.deleteButton5);
                cost1 = FindViewById<TextView>(Resource.Id.foodCost1);
                cost2 = FindViewById<TextView>(Resource.Id.foodCost2);
                cost3 = FindViewById<TextView>(Resource.Id.foodCost3);
                cost4 = FindViewById<TextView>(Resource.Id.foodCost4);
                cost5 = FindViewById<TextView>(Resource.Id.foodCost5);

                backbtn.Click += HomePressed;
                food1.Click += Food1description;
                food2.Click += Food2description;
                food3.Click += Food3description;
                food4.Click += Food4description;
                food5.Click += Food5description;
                btnPayment.Click += PaymentPressed;
                btnHome.Click += HomePressed;
                btnContact.Click += ContactUsPressed;
                btnProfile.Click += ProfilePressed;
                btnSearch.Click += SearchPressed;
                deletebtn1.Click += delete1Pressed;
                deletebtn2.Click += delete2Pressed;
                deletebtn3.Click += delete3Pressed;
                deletebtn4.Click += delete4Pressed;
                deletebtn5.Click += delete5Pressed;

                orderdate.Text = DateTime.Now.ToString();

            }

        }
        private void SearchPressed(Object sender, EventArgs e)
        {
            SearchActivity search = new SearchActivity();
            Intent intent = new Intent(this, typeof(SearchActivity));
            StartActivity(intent);
        }
        private void delete1Pressed(object sender, EventArgs e)
        {
            Quan1 = 0;
            if (Int32.TryParse(CheeseRoll.Text, out Quan1))
            {
                Quan1 = Convert.ToInt32(CheeseRoll.Text);
            }
            result1 = Quan1 * 16;
            cost1.Text = "$ " + result1.ToString() + ".00";
            int Subtotal = result1 + result2 + result3 + result4 + result5;
            subtotal.Text = "$ " + Subtotal + ".00";
            float gst = (float)(Subtotal * 0.15);
            totalGST.Text = "$ " + gst;
            TotalPrice = Subtotal + gst;
            totalCost.Text = "$ " + TotalPrice;


        }
        private void delete2Pressed(object sender, EventArgs e)
        {
            Quan2 = 0;
            if (Int32.TryParse(Pavlova.Text, out Quan2))
            {
                Quan2 = Convert.ToInt32(Pavlova.Text);
            }
            result2 = Quan2 * 25;
            cost2.Text = "$ " + result2.ToString() + ".00";
            int Subtotal = result1 + result2 + result3 + result4 + result5;
            subtotal.Text = "$ " + Subtotal + ".00";
            float gst = (float)(Subtotal * 0.15);
            totalGST.Text = "$ " + gst;
            TotalPrice = Subtotal + gst;
            totalCost.Text = "$ " + TotalPrice;
        }
        private void delete3Pressed(object sender, EventArgs e)
        {
            Quan3 = 0; if (Int32.TryParse(OnionDip.Text, out Quan3))
            {
                Quan3 = Convert.ToInt32(OnionDip.Text);
            }
            result3 = Quan3 * 11;
            cost3.Text = "$ " + result3.ToString() + ".00";
            int Subtotal = result1 + result2 + result3 + result4 + result5;
            subtotal.Text = "$ " + Subtotal + ".00";
            float gst = (float)(Subtotal * 0.15);
            totalGST.Text = "$ " + gst;
            TotalPrice = Subtotal + gst;
            totalCost.Text = "$ " + TotalPrice;
        }
        private void delete4Pressed(object sender, EventArgs e)
        {
            Quan4 = 0;
            if (Int32.TryParse(HokeyPokey.Text, out Quan4))
            {
                Quan4 = Convert.ToInt32(HokeyPokey.Text);
            }
            result4 = Quan4 * 20;
            cost4.Text = "$ " + result4.ToString() + ".00";
            int Subtotal = result1 + result2 + result3 + result4 + result5;
            subtotal.Text = "$ " + Subtotal + ".00";
            float gst = (float)(Subtotal * 0.15);
            totalGST.Text = "$ " + gst;
            TotalPrice = Subtotal + gst;
            totalCost.Text = "$ " + TotalPrice;
        }
        private void delete5Pressed(object sender, EventArgs e)
        {
            Quan5 = 0;
            if (Int32.TryParse(Fritter.Text, out Quan5))
            {
                Quan5 = Convert.ToInt32(Fritter.Text);
            }
            result5 = Quan5 * 23;
            cost5.Text = "$ " + result5.ToString() + ".00";
            int Subtotal = result1 + result2 + result3 + result4 + result5;
            subtotal.Text = "$ " + Subtotal + ".00";
            float gst = (float)(Subtotal * 0.15);
            totalGST.Text = "$ " + gst;
            TotalPrice = Subtotal + gst;
            totalCost.Text = "$ " + TotalPrice;
        }

        private void Food1description(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(FoodDescriptionActivity));
            StartActivity(intent);
        }
        private void Food2description(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(FoodDescription2Activity));
            StartActivity(intent);
        }
        private void Food3description(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(FoodDescription3Activity));
            StartActivity(intent);
        }
        private void Food4description(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(FoodDescription4Activity));
            StartActivity(intent);
        }
        private void Food5description(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(FoodDescription5Activity));
            StartActivity(intent);
        }
        private void PaymentPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(PaymentOptionActivity));
            intent.PutExtra("totalcost", TotalPrice);
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
    [Activity(Label = "Food1")]
    public class FoodDescriptionActivity : Activity
    {
        ImageButton Nextbtn;
        ImageButton Closebtn;
        Button Orderbtn;
        ImageButton btnHome;
        ImageButton btnSearch;
        ImageButton btnContact;
        ImageButton btnProfile;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.FoodDescription);
                Nextbtn = FindViewById<ImageButton>(Resource.Id.buttonNext);
                Closebtn = FindViewById<ImageButton>(Resource.Id.buttonClose);
                Orderbtn = FindViewById<Button>(Resource.Id.buttonOrderNow);
                btnHome = FindViewById<ImageButton>(Resource.Id.buttonHome);
                btnSearch = FindViewById<ImageButton>(Resource.Id.buttonSearch);
                btnContact = FindViewById<ImageButton>(Resource.Id.buttonContactUs);
                btnProfile = FindViewById<ImageButton>(Resource.Id.buttonProfile);

                Nextbtn.Click += NextPressed;
                Closebtn.Click += BackToOrderdetail;
                Orderbtn.Click += BackToOrderdetail;
                btnHome.Click += HomePressed;
                btnContact.Click += ContactUsPressed;
                btnProfile.Click += ProfilePressed;
                btnSearch.Click += SearchPressed;
            }

        }
        private void SearchPressed(Object sender, EventArgs e)
        {
            SearchActivity search = new SearchActivity();
            Intent intent = new Intent(this, typeof(SearchActivity));
            StartActivity(intent);
        }
        private void NextPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(FoodDescription2Activity));
            StartActivity(intent);
        }
        private void BackToOrderdetail(Object sender, EventArgs e)
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
    [Activity(Label = "Food2")]
    public class FoodDescription2Activity : Activity
    {
        ImageButton Nextbtn;
        ImageButton Closebtn;
        Button Orderbtn;
        ImageButton btnHome;
        ImageButton btnSearch;
        ImageButton btnContact;
        ImageButton btnProfile;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.FoodDescription2);
                Nextbtn = FindViewById<ImageButton>(Resource.Id.buttonNext);
                Closebtn = FindViewById<ImageButton>(Resource.Id.buttonClose);
                Orderbtn = FindViewById<Button>(Resource.Id.buttonOrderNow);
                btnHome = FindViewById<ImageButton>(Resource.Id.buttonHome);
                btnSearch = FindViewById<ImageButton>(Resource.Id.buttonSearch);
                btnContact = FindViewById<ImageButton>(Resource.Id.buttonContactUs);
                btnProfile = FindViewById<ImageButton>(Resource.Id.buttonProfile);

                Nextbtn.Click += NextPressed;
                btnSearch.Click += SearchPressed;
                Closebtn.Click += BackToOrderdetail;
                Orderbtn.Click += BackToOrderdetail;
                btnHome.Click += HomePressed;
                btnContact.Click += ContactUsPressed;
                btnProfile.Click += ProfilePressed;
            }

        }
        private void SearchPressed(Object sender, EventArgs e)
        {
            SearchActivity search = new SearchActivity();
            Intent intent = new Intent(this, typeof(SearchActivity));
            StartActivity(intent);
        }
        private void NextPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(FoodDescription3Activity));
            StartActivity(intent);
        }
        private void BackToOrderdetail(Object sender, EventArgs e)
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
    [Activity(Label = "Food3")]
    public class FoodDescription3Activity : Activity
    {
        ImageButton Nextbtn;
        ImageButton Closebtn;
        Button Orderbtn;
        ImageButton btnHome;
        ImageButton btnSearch;
        ImageButton btnContact;
        ImageButton btnProfile;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.FoodDescription3);
                Nextbtn = FindViewById<ImageButton>(Resource.Id.buttonNext);
                Closebtn = FindViewById<ImageButton>(Resource.Id.buttonClose);
                Orderbtn = FindViewById<Button>(Resource.Id.buttonOrderNow);
                btnHome = FindViewById<ImageButton>(Resource.Id.buttonHome);
                btnSearch = FindViewById<ImageButton>(Resource.Id.buttonSearch);
                btnContact = FindViewById<ImageButton>(Resource.Id.buttonContactUs);
                btnProfile = FindViewById<ImageButton>(Resource.Id.buttonProfile);

                Nextbtn.Click += NextPressed;
                Closebtn.Click += BackToOrderdetail;
                Orderbtn.Click += BackToOrderdetail;
                btnHome.Click += HomePressed;
                btnContact.Click += ContactUsPressed;
                btnProfile.Click += ProfilePressed;
                btnSearch.Click += SearchPressed;
            }

        }
        private void SearchPressed(Object sender, EventArgs e)
        {
            SearchActivity search = new SearchActivity();
            Intent intent = new Intent(this, typeof(SearchActivity));
            StartActivity(intent);
        }
        private void NextPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(FoodDescription4Activity));
            StartActivity(intent);
        }
        private void BackToOrderdetail(Object sender, EventArgs e)
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
    [Activity(Label = "Food4")]
    public class FoodDescription4Activity : Activity
    {
        ImageButton Nextbtn;
        ImageButton Closebtn;
        Button Orderbtn;
        ImageButton btnHome;
        ImageButton btnSearch;
        ImageButton btnContact;
        ImageButton btnProfile;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.FoodDescription4);
                Nextbtn = FindViewById<ImageButton>(Resource.Id.buttonNext);
                Closebtn = FindViewById<ImageButton>(Resource.Id.buttonClose);
                Orderbtn = FindViewById<Button>(Resource.Id.buttonOrderNow);
                btnHome = FindViewById<ImageButton>(Resource.Id.buttonHome);
                btnSearch = FindViewById<ImageButton>(Resource.Id.buttonSearch);
                btnContact = FindViewById<ImageButton>(Resource.Id.buttonContactUs);
                btnProfile = FindViewById<ImageButton>(Resource.Id.buttonProfile);

                Nextbtn.Click += NextPressed;
                Closebtn.Click += BackToOrderdetail;
                Orderbtn.Click += BackToOrderdetail;
                btnHome.Click += HomePressed;
                btnContact.Click += ContactUsPressed;
                btnProfile.Click += ProfilePressed;
                btnSearch.Click += SearchPressed;
            }

        }
        private void SearchPressed(Object sender, EventArgs e)
        {
            SearchActivity search = new SearchActivity();
            Intent intent = new Intent(this, typeof(SearchActivity));
            StartActivity(intent);
        }
        private void NextPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(FoodDescription5Activity));
            StartActivity(intent);
        }
        private void BackToOrderdetail(Object sender, EventArgs e)
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
    [Activity(Label = "Food5")]
    public class FoodDescription5Activity : Activity
    {
        ImageButton Nextbtn;
        ImageButton Closebtn;
        Button Orderbtn;
        ImageButton btnHome;
        ImageButton btnSearch;
        ImageButton btnContact;
        ImageButton btnProfile;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.FoodDescription5);
                Nextbtn = FindViewById<ImageButton>(Resource.Id.buttonNext);
                Closebtn = FindViewById<ImageButton>(Resource.Id.buttonClose);
                Orderbtn = FindViewById<Button>(Resource.Id.buttonOrderNow);
                btnHome = FindViewById<ImageButton>(Resource.Id.buttonHome);
                btnSearch = FindViewById<ImageButton>(Resource.Id.buttonSearch);
                btnContact = FindViewById<ImageButton>(Resource.Id.buttonContactUs);
                btnProfile = FindViewById<ImageButton>(Resource.Id.buttonProfile);

                Nextbtn.Click += NextPressed;
                Closebtn.Click += BackToOrderdetail;
                Orderbtn.Click += BackToOrderdetail;
                btnHome.Click += HomePressed;
                btnContact.Click += ContactUsPressed;
                btnProfile.Click += ProfilePressed;
                btnSearch.Click += SearchPressed;
            }

        }
        private void SearchPressed(Object sender, EventArgs e)
        {
            SearchActivity search = new SearchActivity();
            Intent intent = new Intent(this, typeof(SearchActivity));
            StartActivity(intent);
        }
        private void NextPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(FoodDescriptionActivity));
            StartActivity(intent);
        }
        private void BackToOrderdetail(Object sender, EventArgs e)
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

    //Contact Us
    [Activity(Label = "Contact")]
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
                btnSearch.Click += SearchPressed;

            }

        }
        private void SearchPressed(Object sender, EventArgs e)
        {
            SearchActivity search = new SearchActivity();
            Intent intent = new Intent(this, typeof(SearchActivity));
            StartActivity(intent);
        }
        private void SendPressed(Object sender, EventArgs e)
        {
            Toast.MakeText(this, "Information sent successfully", ToastLength.Long).Show();
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
    [Activity(Label = "Profile")]
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
                username = FindViewById<EditText>(Resource.Id.editTextUsername);
                password = FindViewById<EditText>(Resource.Id.editTextPassword);
                firstname = FindViewById<EditText>(Resource.Id.editTextFirstName);
                lastname = FindViewById<EditText>(Resource.Id.editTextLastName);
                phonenumber = FindViewById<EditText>(Resource.Id.editTextMobileNumber);
                email = FindViewById<EditText>(Resource.Id.editTextEmailAddress);

                Updatebtn.Click += Updatepressed;
                Deletebtn.Click += Deletepressed;

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
    [Activity(Label = "Payment")]
    public class PaymentOptionActivity : Activity
    {
        ImageButton back;
        Button btncash;
        Button btncredit;
        ImageButton btnHome;
        ImageButton btnSearch;
        ImageButton btnContact;
        ImageButton btnProfile;
        TextView Totalamount;

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
                Totalamount = FindViewById<TextView>(Resource.Id.textViewTotalAmount);
                float Totalprice = Intent.GetFloatExtra("totalcost", 0);

                Totalamount.Text = "$ " + Totalprice.ToString();

                back.Click += BacktoOrder;
                btnHome.Click += HomePressed;
                btnContact.Click += ContactUsPressed;
                btnProfile.Click += ProfilePressed;
                btnSearch.Click += SearchPressed;

            }

        }
        private void SearchPressed(Object sender, EventArgs e)
        {
            SearchActivity search = new SearchActivity();
            Intent intent = new Intent(this, typeof(SearchActivity));
            StartActivity(intent);
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
    [Activity(Label = "Search")]
        public class SearchActivity : Activity
    {
        private EditText search_Item_editText, search_ItemDiet_editText, SelectItem_Protien_EditText;
        private Button search_Button;
        private TextView Searched_Items_TextView;
        ImageButton back;

        private const string ApiKey = "cd51d9b5304642539829fd4461adf141";
        private const string ApiUrl = "https://api.spoonacular.com/recipes/complexSearch";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Search);

            search_Item_editText = FindViewById<EditText>(Resource.Id.SelectItem_EditText);
            search_ItemDiet_editText = FindViewById<EditText>(Resource.Id.SelectItem_Diet_EditText);
            SelectItem_Protien_EditText = FindViewById<EditText>(Resource.Id.SelectItem_Protein_EditText);
            search_Button = FindViewById<Button>(Resource.Id.btn_Search);
            Searched_Items_TextView = FindViewById<TextView>(Resource.Id.SearchedItems_TextView);
            back = (ImageButton)FindViewById<ImageView>(Resource.Id.buttonBack);

            back.Click += backtoMenu;

            search_Button.Click += async (sender, e) =>
            {
                string searchdata = search_Item_editText.Text;
                string search_Diet_date = search_ItemDiet_editText.Text;
                string search_protine = SelectItem_Protien_EditText.Text;
                if (!string.IsNullOrEmpty(searchdata))
                {
                    string apiUrl = $"{ApiUrl}?apiKey={ApiKey}&query={searchdata}&diet={search_Diet_date}&minProtein={search_protine}";

                    Searched_Items_TextView.Text = await SearchRecipes(apiUrl);
                }
                else
                {
                    Searched_Items_TextView.Text = "Please enter Search Items and Diet type";
                }

            };
        }
        private void backtoMenu(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MenuActivity));
            StartActivity(intent);
        }
        private async Task<string> SearchRecipes(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage httpResponseMessage = await client.GetAsync(apiUrl);
                try
                {
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        string content = await httpResponseMessage.Content.ReadAsStringAsync();
                        var recipes = JsonConvert.DeserializeObject<Root>(content);

                        StringBuilder stringBuilder = new StringBuilder();
                        foreach (var recipe in recipes.results)
                        {
                            StringBuilder nutriValue = new StringBuilder();
                            foreach (var nutri in recipe.nutrition.nutrients)
                            {
                                nutriValue.AppendLine(nutri.amount.ToString() + nutri.unit);
                            }
                            stringBuilder.AppendLine($"Recipe Title: {recipe.title}  - " + nutriValue.ToString());

                        }
                        return stringBuilder.ToString();
                    }
                    else
                    {
                        return $"Error:{httpResponseMessage.StatusCode} - {httpResponseMessage.ReasonPhrase}";
                    }
                }
                catch (Exception ex)
                {
                    return $"Error:{ex.Message}";
                }
            }
        }

    }
    public class Nutrient
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("amount")]
        public double amount { get; set; }
        [JsonProperty("unit")]
        public string unit { get; set; }
    }

    public class Nutrition
    {
        [JsonProperty("nutrients")]
        public List<Nutrient> nutrients { get; set; }
    }

    public class Result
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("image")]
        public string image { get; set; }
        [JsonProperty("imageType")]
        public string imageType { get; set; }
        [JsonProperty("nutrition")]
        public Nutrition nutrition { get; set; }
    }

    public class Root
    {
        [JsonProperty("results")]
        public List<Result> results { get; set; }
        [JsonProperty("offset")]
        public int offset { get; set; }
        [JsonProperty("number")]
        public int number { get; set; }
        [JsonProperty("totalResults")]
        public int totalResults { get; set; }
    }


    [Activity(Label = "AddEdit")]
    public class AddEditActivity : Activity
    {
        Button addbutton;
        Button editbutton;
        Spinner Tablespin;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.AddEdit);
                addbutton = FindViewById<Button>(Resource.Id.buttonAdd);
                editbutton = FindViewById<Button>(Resource.Id.buttonEdit);
                Tablespin = FindViewById<Spinner>(Resource.Id.spinnerNumber);

                Tablespin.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
                var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.Table_Number, Android.Resource.Layout.SimpleSpinnerItem);
                adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
                Tablespin.Adapter = adapter;
            }

        }
        public void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            if (String.Format("{0}", spinner.GetItemAtPosition(e.Position)) == "Table 1")
            {

            }
            else if (String.Format("{0}", spinner.GetItemAtPosition(e.Position)) == "Table 2")
            {

            }
            else if (String.Format("{0}", spinner.GetItemAtPosition(e.Position)) == "Table 3")
            {

            }
            else if (String.Format("{0}", spinner.GetItemAtPosition(e.Position)) == "Table 4")
            {

            }
        }
    }

}