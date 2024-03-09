
using SWD607_Assignment2;
using Android.Content;
using Person_DataAndriod;
using SWD607_Assignment2.Models;
using Newtonsoft.Json;
using System.Text;
using System.Runtime.InteropServices;
using static Android.Provider.ContactsContract.CommonDataKinds;
using Javax.Security.Auth;
using Android.Widget;
using Android.Views;
namespace Auckland_Rangers
{
    [Activity(MainLauncher = true)]
    //Sign in progress
    public class SignInActivity : Activity
    {
        EditText edtusername, edtpassword;
        Button ButtonLogin;
        Button ButtonHome;
        string usernames;
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

            usernames = edtusername.Text;
            string password = edtpassword.Text;
            if (string.IsNullOrEmpty(usernames) || string.IsNullOrEmpty(password))
            {
                Toast.MakeText(this, "Please enter both username and password", ToastLength.Long).Show();
                return;
            }
            else
            {
                SignUp signup = Obj_databaseManager.GetUserName(usernames);

                if (signup != null && signup.Password == password)
                {
                    Intent Login_intent = new Intent(this, typeof(MenuActivity));
                    Login_intent.PutExtra("username", usernames);
                    StartActivity(Login_intent);
                }
                else
                {
                    Toast.MakeText(this, "Please enter correct username/password", ToastLength.Long).Show();
                    return;
                }
            }
        }
        private void SignUpPressed(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SignUpActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
            //'Unable to find explicit activity class {com.companyname.SWD607_Assignment2/crc64b8371ed0b9bbb922.SignUpActivity};
            //have you declared this activity in your AndroidManifest.xml, or does your intent not match its declared <intent-filter>?'
        }
    }

    [Activity(Label = "SignUp")]
    //SignUp progress
    public class SignUpActivity : Activity
    {
        string usernames;
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
            Intent intent = new Intent(this, typeof(SignInActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
    }

    //Menu progress
    [Activity(Label = "Menu")]
    public class MenuActivity : Activity
    {
        string usernames;
        ImageButton Ibtnmaincart;
        TextView txtMoreoptions;
        TextView txtViewall;
        Button buttonReservation1;
        Button buttonMenulist;
        ImageButton btnHome, btnSearch, btnContact, btnProfile, Ibtncart1, Ibtncart2;
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
            
            usernames = Intent.GetStringExtra("username");
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
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void MainCartPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(OrderdetailActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void ReservationPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ReservationActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void HomePressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MenuActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void ContactUsPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ContactActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void ProfilePressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ProfileActivity));
            intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
    }

    //Reservation progress
    [Activity(Label = "reservation")]
    public class ReservationActivity : Activity
    {
        string usernames;
        ImageButton backbtn;
        Button btnAddEdit;
        Button btnDelete;
        ListView listView; //jp
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.Reservation);
                btnAddEdit = FindViewById<Button>(Resource.Id.buttonAddEdit);
                backbtn = FindViewById<ImageButton>(Resource.Id.buttonBack);
                btnDelete = FindViewById<Button>(Resource.Id.buttonDelete);
                usernames = Intent.GetStringExtra("username");
                listView = FindViewById<ListView>(Resource.Id.listView); //jp

                backbtn.Click += BackPressed;
                btnAddEdit.Click += AddEditPressed;

                LoadReservations(); //jp
            }

        }
        private void LoadReservations() //jp
        {
            // Initialize database context
            var db = new ReservationDbContext();

            // Retrieve all reservations from the database
            List<Reservation> reservations = db.GetAllReservations().ToList();

            // Initialize adapter with the retrieved reservations
            ReservationAdapter adapter = new ReservationAdapter(this, reservations);

            // Set adapter to ListView
            listView.Adapter = adapter;
        } //jp
        private void BackPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MenuActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void AddEditPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AddEditActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
    }

    //Orderdetail
    [Activity(Label = "Orderdetail")]
    public class OrderdetailActivity : Activity
    {
        EditText CheeseRoll, Pavlova, OnionDip, HokeyPokey, Fritter, Salad;
        ImageButton backbtn;
        ImageView food1, food2, food3, food4, food5;
        Button deletebtn1, deletebtn2, deletebtn3, deletebtn4, deletebtn5, deletebtn6, btnPayment;
        ImageButton btnHome, btnSearch, btnContact, btnProfile;
        TextView cost1, cost2, cost3, cost4, cost5, cost6, orderdate, subtotal, totalGST, totalCost;
        int Quan1, Quan2, Quan3, Quan4, Quan5, Quan6, result1, result2, result3, result4, result5, result6;
        float TotalPrice;
        string usernames;

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
                usernames = Intent.GetStringExtra("username");
                Salad = FindViewById<EditText>(Resource.Id.foodQuantity6);
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
                deletebtn6 = FindViewById<Button>(Resource.Id.deleteButton6);
                cost1 = FindViewById<TextView>(Resource.Id.foodCost1);
                cost2 = FindViewById<TextView>(Resource.Id.foodCost2);
                cost3 = FindViewById<TextView>(Resource.Id.foodCost3);
                cost4 = FindViewById<TextView>(Resource.Id.foodCost4);
                cost5 = FindViewById<TextView>(Resource.Id.foodCost5);
                cost6 = FindViewById<TextView>(Resource.Id.foodCost6);

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
                deletebtn6.Click += delete6Pressed;
                orderdate.Text = DateTime.Now.ToString();
            }

        }
        private void SearchPressed(Object sender, EventArgs e)
        {
            SearchActivity search = new SearchActivity();
            Intent intent = new Intent(this, typeof(SearchActivity));
            Intent.PutExtra("username", usernames);
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
            int Subtotal = result1 + result2 + result3 + result4 + result5 + result6;
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
            int Subtotal = result1 + result2 + result3 + result4 + result5 + result6;
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
            int Subtotal = result1 + result2 + result3 + result4 + result5 + result6;
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
            int Subtotal = result1 + result2 + result3 + result4 + result5 + result6;
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
            int Subtotal = result1 + result2 + result3 + result4 + result5 + result6;
            subtotal.Text = "$ " + Subtotal + ".00";
            float gst = (float)(Subtotal * 0.15);
            totalGST.Text = "$ " + gst;
            TotalPrice = Subtotal + gst;
            totalCost.Text = "$ " + TotalPrice;
        }
        private void delete6Pressed(object sender, EventArgs e)
        {
            Quan6 = 0;
            if (Int32.TryParse(Salad.Text, out Quan6))
            {
                Quan6 = Convert.ToInt32(Salad.Text);
            }
            result6 = Quan6 * 38;
            cost6.Text = "$ " + result6.ToString() + ".00";
            int Subtotal = result1 + result2 + result3 + result4 + result5 + result6;
            subtotal.Text = "$ " + Subtotal + ".00";
            float gst = (float)(Subtotal * 0.15);
            totalGST.Text = "$ " + gst;
            TotalPrice = Subtotal + gst;
            totalCost.Text = "$ " + TotalPrice;
        }

        private void Food1description(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(FoodDescriptionActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void Food2description(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(FoodDescription2Activity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void Food3description(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(FoodDescription3Activity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void Food4description(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(FoodDescription4Activity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void Food5description(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(FoodDescription5Activity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void PaymentPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(PaymentOptionActivity));
            Intent.PutExtra("username", usernames);
            intent.PutExtra("totalcost", TotalPrice);
            StartActivity(intent);
        }
        private void HomePressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MenuActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void ContactUsPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ContactActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void ProfilePressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ProfileActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
    }

    [Activity(Label = "Food1")]
    public class FoodDescriptionActivity : Activity
    {
        ImageButton Nextbtn, Closebtn;
        Button Orderbtn;
        ImageButton btnHome, btnSearch, btnContact, btnProfile;
        string usernames;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.FoodDescription);
                Nextbtn = FindViewById<ImageButton>(Resource.Id.buttonNext);
                Closebtn = FindViewById<ImageButton>(Resource.Id.buttonClose);
                Orderbtn = FindViewById<Button>(Resource.Id.buttonOrderNow);
                usernames = Intent.GetStringExtra("username");
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
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void NextPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(FoodDescription2Activity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void BackToOrderdetail(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(OrderdetailActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void HomePressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MenuActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void ContactUsPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ContactActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void ProfilePressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ProfileActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
    }
    [Activity(Label = "Food2")]
    public class FoodDescription2Activity : Activity
    {
        string usernames;
        ImageButton Nextbtn;
        ImageButton Closebtn;
        Button Orderbtn;
        ImageButton btnHome, btnSearch, btnContact, btnProfile;
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
                usernames = Intent.GetStringExtra("username");
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
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void NextPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(FoodDescription3Activity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void BackToOrderdetail(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(OrderdetailActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void HomePressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MenuActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void ContactUsPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ContactActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void ProfilePressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ProfileActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
    }
    [Activity(Label = "Food3")]
    public class FoodDescription3Activity : Activity
    {
        string usernames;
        ImageButton Nextbtn, Closebtn;
        Button Orderbtn;
        ImageButton btnHome, btnSearch, btnContact, btnProfile;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.FoodDescription3);
                Nextbtn = FindViewById<ImageButton>(Resource.Id.buttonNext);
                Closebtn = FindViewById<ImageButton>(Resource.Id.buttonClose);
                usernames = Intent.GetStringExtra("username");
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
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void NextPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(FoodDescription4Activity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void BackToOrderdetail(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(OrderdetailActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void HomePressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MenuActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void ContactUsPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ContactActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void ProfilePressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ProfileActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
    }
    [Activity(Label = "Food4")]
    public class FoodDescription4Activity : Activity
    {
        ImageButton Nextbtn;
        ImageButton Closebtn;
        Button Orderbtn;
        ImageButton btnHome, btnSearch, btnContact, btnProfile;
        string usernames;
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
                usernames = Intent.GetStringExtra("username");
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
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void NextPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(FoodDescription5Activity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void BackToOrderdetail(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(OrderdetailActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void HomePressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MenuActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void ContactUsPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ContactActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void ProfilePressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ProfileActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
    }
    [Activity(Label = "Food5")]
    public class FoodDescription5Activity : Activity
    {
        ImageButton Nextbtn;
        ImageButton Closebtn;
        Button Orderbtn;
        ImageButton btnHome, btnSearch, btnContact, btnProfile;
        string usernames;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.FoodDescription5);
                Nextbtn = FindViewById<ImageButton>(Resource.Id.buttonNext);
                Closebtn = FindViewById<ImageButton>(Resource.Id.buttonClose);
                Orderbtn = FindViewById<Button>(Resource.Id.buttonOrderNow);
                btnHome = FindViewById<ImageButton>(Resource.Id.buttonHome);
                usernames = Intent.GetStringExtra("username");
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
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void NextPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(FoodDescriptionActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void BackToOrderdetail(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(OrderdetailActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void HomePressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MenuActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void ContactUsPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ContactActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void ProfilePressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ProfileActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
    }

    //Contact Us
    [Activity(Label = "Contact")]
    public class ContactActivity : Activity
    {
        Button btnSend;
        ImageButton btnHome, btnSearch, btnContact, btnProfile;
        string usernames;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.ContactUs);
                btnSend = FindViewById<Button>(Resource.Id.buttonSend);
                btnHome = FindViewById<ImageButton>(Resource.Id.buttonHome);
                btnSearch = FindViewById<ImageButton>(Resource.Id.buttonSearch);
                usernames = Intent.GetStringExtra("username");
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
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void SendPressed(Object sender, EventArgs e)
        {
            Toast.MakeText(this, "Information sent successfully", ToastLength.Long).Show();
        }
        private void HomePressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MenuActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void ContactUsPressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ContactActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void ProfilePressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ProfileActivity));
            Intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
    }


    //Profile
    [Activity(Label = "Profile")]
    public class ProfileActivity : Activity
    {
        Button Updatebtn, Deletebtn;
        ImageButton back;
        string usernames;
        int _userId;
        DatabaseManager _dbManager;
        SignUp obj_SignUp;
        TextView username, password, firstname, lastname, phonenumber, email;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.Profile);
                Updatebtn = FindViewById<Button>(Resource.Id.btnUpdate);

                Deletebtn = FindViewById<Button>(Resource.Id.btnDeleteAccount);
                username = FindViewById<TextView>(Resource.Id.txtUsername);
                password = FindViewById<TextView>(Resource.Id.txtPassword);
                firstname = FindViewById<TextView>(Resource.Id.editTextFirstName);
                lastname = FindViewById<TextView>(Resource.Id.editTextLastName);
                phonenumber = FindViewById<TextView>(Resource.Id.txtPhone);
                email = FindViewById<TextView>(Resource.Id.txtEmail);
                back = FindViewById<ImageButton>(Resource.Id.buttonBack);

                _dbManager = new DatabaseManager();


                usernames = Intent.GetStringExtra("username");
                obj_SignUp = _dbManager.GetUserName(usernames);

                if (obj_SignUp != null)
                {
                    username.Text = obj_SignUp.UserName;
                    password.Text = obj_SignUp.Password;
                    lastname.Text = obj_SignUp.LastName;
                    firstname.Text = obj_SignUp.FirstName;
                    phonenumber.Text = obj_SignUp.PhoneNumber;
                    email.Text = obj_SignUp.Email;
                }
                else
                {
                    Toast.MakeText(this, "Person Data Not Found", ToastLength.Long).Show();
                }
                Updatebtn.Click += Updatepressed;
                Deletebtn.Click += DeleteUser;
                back.Click += BackMenu;
            }

        }
        private void BackMenu(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MenuActivity));
            StartActivity(intent);
        }
        private void Updatepressed(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Updatepage));
            intent.PutExtra("UserId", obj_SignUp.Id);
            intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
        private void DeleteUser(object sender, EventArgs e)
        {
            _dbManager.DeleteUser(_userId);
            Toast.MakeText(this, "Person Data is deleted successfully", ToastLength.Long).Show();
            Intent intent = new Intent(this, typeof(SignInActivity));
            StartActivity(intent);
        }
        
    }
    [Activity(Label = "Update Users")]
    public class Updatepage : Activity
    {
        string usernames;
        private int userId;
        DatabaseManager dm;
        Button updatebtn;
        ImageButton back;
        EditText username, password, firstname, lastname, phonenumber, email;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Profile_Update);
            back = FindViewById<ImageButton>(Resource.Id.buttonBack);
            username = FindViewById<EditText>(Resource.Id.txtUsername);
            password = FindViewById<EditText>(Resource.Id.txtPassword);
            firstname = FindViewById<EditText>(Resource.Id.editTextFirstName);
            lastname = FindViewById<EditText>(Resource.Id.editTextLastName);
            phonenumber = FindViewById<EditText>(Resource.Id.txtPhone);
            email = FindViewById<EditText>(Resource.Id.txtEmail);
            updatebtn = FindViewById<Button>(Resource.Id.buttonSend);

            dm = new DatabaseManager();
            usernames = Intent.GetStringExtra("username");
            userId = Intent.GetIntExtra("UserId", 0);
            SignUp signUp = dm.GetUserId(userId);
            if (signUp != null)
            {
                username.Text = signUp.UserName;
                password.Text = signUp.Password;
                firstname.Text = signUp.FirstName;
                lastname.Text = signUp.LastName;
                phonenumber.Text = signUp.PhoneNumber;
                email.Text = signUp.Email;
            }
            else
            {   
                Toast.MakeText(this, "Persons Data Not Found", ToastLength.Long).Show();
            }
            back.Click += backtoProfile;
            updatebtn.Click += ButtonUpdateClick;
        }
        private void backtoProfile(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ProfileActivity));
            StartActivity(intent);
        }
        void ButtonUpdateClick(object sender, EventArgs e)
        {
            SignUp update = new SignUp()
            {
                Id = userId,
                UserName = username.Text,
                Password = password.Text,
                FirstName = firstname.Text,
                LastName = lastname.Text,
                PhoneNumber = phonenumber.Text,
                Email = email.Text
            };
            dm.UpdateUser(update);
            Toast.MakeText(this, "Changes have been made", ToastLength.Long).Show();
            usernames = username.Text;
            Intent intent = new Intent(this, typeof(ProfileActivity));
            intent.PutExtra("username", usernames);
            StartActivity(intent);
        }
    }
    //Payment
    [Activity(Label = "Payment")]
    public class PaymentOptionActivity : Activity
    {
        string usernames;
        ImageButton back;
        Button btncash, btncredit, Submit;
        ImageButton btnHome, btnSearch, btnContact, btnProfile;
        TextView Totalamount;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.PaymentOption);
                back = FindViewById<ImageButton>(Resource.Id.buttonBack);
                usernames = Intent.GetStringExtra("username");
                btncash = FindViewById<Button>(Resource.Id.buttonCash);
                btncredit = FindViewById<Button>(Resource.Id.buttonCard);
                btnHome = FindViewById<ImageButton>(Resource.Id.buttonHome);
                btnSearch = FindViewById<ImageButton>(Resource.Id.buttonSearch);
                btnContact = FindViewById<ImageButton>(Resource.Id.buttonContactUs);
                btnProfile = FindViewById<ImageButton>(Resource.Id.buttonProfile);
                Totalamount = FindViewById<TextView>(Resource.Id.textViewTotalAmount);
                Submit = FindViewById<Button>(Resource.Id.buttonProceedToPayment);
                float Totalprice = Intent.GetFloatExtra("totalcost", 0);

                Totalamount.Text = "$ " + Totalprice.ToString();

                back.Click += BacktoOrder;
                btnHome.Click += HomePressed;
                btnContact.Click += ContactUsPressed;
                btnProfile.Click += ProfilePressed;
                btnSearch.Click += SearchPressed;
                btncash.Click += CashClicked;
                btncredit.Click += CreditClicked;
                Submit.Click += BacktoMenu;

            }
        }
        private void BacktoMenu(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MenuActivity));
            StartActivity(intent);
            Toast.MakeText(this, "Rating Recorded", ToastLength.Long).Show();
        }
        private void CashClicked(Object sender, EventArgs e)
        {
            Toast.MakeText(this, "Thank you for purchase our food!", ToastLength.Long).Show();
        }
        private void CreditClicked(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(CreditActivity));
            StartActivity(intent);
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
    public class CreditActivity : Activity
    {
        ImageButton back;
        string usernames;
        Button cancel, proceed;
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CreditDebit);
            back = FindViewById<ImageButton>(Resource.Id.buttonBack);
            cancel = FindViewById<Button>(Resource.Id.buttonHome);
            proceed = FindViewById<Button>(Resource.Id.buttonLogin);

            back.Click += backClicked;
            cancel.Click += backClicked;
            usernames = Intent.GetStringExtra("username");
            proceed.Click += backClickedpurchase;
        }
        private void backClicked(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(PaymentOptionActivity));
            StartActivity(intent);
        }
        private void backClickedpurchase(Object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(PaymentOptionActivity));
            StartActivity(intent);
            Toast.MakeText(this, "Thank you for purchase our food!", ToastLength.Long).Show();
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
        string usernames;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Search);

            search_Item_editText = FindViewById<EditText>(Resource.Id.SelectItem_EditText);
            search_ItemDiet_editText = FindViewById<EditText>(Resource.Id.SelectItem_Diet_EditText);
            usernames = Intent.GetStringExtra("username");
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
        string usernames;
        Button addbutton;
        Button editbutton;
        Spinner Tablespin;
        ReservationDbContext dbContext; // Add database context (JP)
        TextView textView;
        DatePicker datePicker;
        TimePicker timePicker;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(SWD607_Assignment2.Resource.Layout.AddEdit);

            addbutton = FindViewById<Button>(Resource.Id.buttonAdd);
            usernames = Intent.GetStringExtra("username");
            editbutton = FindViewById<Button>(Resource.Id.buttonEdit);
            Tablespin = FindViewById<Spinner>(Resource.Id.spinnerNumber);
            textView = FindViewById<TextView>(Resource.Id.textView38);
            datePicker = FindViewById<DatePicker>(Resource.Id.datePicker1);
            timePicker = FindViewById<TimePicker>(Resource.Id.timePicker1);

            dbContext = new ReservationDbContext();

            PopulateSpinner();

            addbutton.Click += Addbutton_Click;
            //editbutton.Click += Editbutton_Click;
        }

        private void PopulateSpinner()
        {
            Tablespin.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.Table_Number, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            Tablespin.Adapter = adapter;
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            Reservation reservation = new Reservation
            {
                username = usernames,
                ReservationDateTime = GetSelectedDateTime(),
                TableNumber = Tablespin.SelectedItem.ToString()
            };

            AddReservationToListView(reservation);

            dbContext.AddOrUpdateReservation(reservation);

            Toast.MakeText(this, "Reservation added successfully", ToastLength.Short).Show();
        }

        private void AddReservationToListView(Reservation reservation)
        {
            // Find the TextView to display reservation details
            TextView textView = FindViewById<TextView>(Resource.Id.textView38);

            // Create a string to hold reservation details
            string reservationDetails = "Table Number: " + reservation.TableNumber + "\n" +
                                         "Date & Time: " + reservation.ReservationDateTime.ToString("dd/MM/yyyy HH:mm") + "\n";

            // Append the new reservation details to the existing text
            textView.Append(reservationDetails);
        }

        /*private void Editbutton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ReservationListActivity));
            intent.PutExtra("username", usernames);
            StartActivity(intent);
        }*/

        private DateTime GetSelectedDateTime()
        {
            // Get selected date from date picker
            int year = datePicker.Year;
            int month = datePicker.Month + 1; // DatePicker month is zero-based
            int day = datePicker.DayOfMonth;

            // Get selected time from time picker
            int hour = timePicker.Hour;
            int minute = timePicker.Minute;

            // Create DateTime object from selected date and time
            DateTime selectedDateTime = new DateTime(year, month, day, hour, minute, 0);

            return selectedDateTime;
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
