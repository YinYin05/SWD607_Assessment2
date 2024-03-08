using Android.App;
using Android.Views;
using Android.Widget;
using SWD607_Assignment2.Models;
using System.Collections.Generic;
using SWD607_Assignment2;

public class ReservationAdapter : BaseAdapter<Reservation>
{
    private readonly Activity context;
    private readonly List<Reservation> reservations;

    public ReservationAdapter(Activity context, List<Reservation> reservations)
    {
        this.context = context;
        this.reservations = reservations;
    }

    public override int Count => reservations.Count;

    public override Reservation this[int position] => reservations[position];

    public override long GetItemId(int position) => position;

    public override View GetView(int position, View convertView, ViewGroup parent)
    {
        View view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.ReservationListItem, parent, false);

        // Get views from layout
        TextView textViewTableNumber = view.FindViewById<TextView>(Resource.Id.textViewTableNumber);
        TextView textViewDateTime = view.FindViewById<TextView>(Resource.Id.textViewDateTime);

        // Set data to views
        textViewTableNumber.Text = reservations[position].TableNumber;
        textViewDateTime.Text = reservations[position].ReservationDateTime.ToString();

        return view;
    }
}
