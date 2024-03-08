using SWD607_Assignment2.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SWD607_Assignment2
{
    public class ReservationDbContext
    {
        readonly SQLiteConnection connection;

        public ReservationDbContext()
        {
            string directoryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
            
            string dbPath = Path.Combine(directoryPath, "Reservation_Data.db");

            if (Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            try
            {
                connection = new SQLiteConnection(dbPath);

                connection.CreateTable<Reservation>();
            }
            catch (SQLiteException ex)
            {
                // Handle SQLite exceptions
                Console.WriteLine("SQLite Exception: " + ex.Message);
                throw; // Rethrow the exception to handle it at a higher level
            }                  
        }  

        // Method to add or update a reservation
        public void AddOrUpdateReservation(Reservation reservation)
        {
            if (reservation.ReservationId != 0)
            {
                connection.Update(reservation);
            }
            else
            {
                connection.Insert(reservation);
            }
        }

        // Method to retrieve all reservations
        public TableQuery<Reservation> GetAllReservations()
        {
            return connection.Table<Reservation>();
        }
        public void Dispose()
        {
            connection.Dispose();
        }
    }
}