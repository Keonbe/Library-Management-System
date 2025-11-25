using System;
using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class LibrarySystem
    {
        [Key]
        public int Id { get; set; }

        // Borrower Name
        [Required]
        public string BorrowerName { get; set; }

        // Book Title
        [Required]
        public string BookTitle { get; set; }

        // Author
        [Required]
        public string Author { get; set; }

        // Borrow Date
        [Required]
        public DateTime BorrowDate { get; set; }

        // Return Date (User Input)
        [Required]
        public DateTime ReturnDate { get; set; }

        // Computed: Days Borrowed
        public int DaysBorrowed
        {
            get
            {
                return (ReturnDate - BorrowDate).Days;
            }
        }

        // Computed: Late Fee (₱10 per day after 7 days)
        public double LateFee
        {
            get
            {
                int extraDays = Math.Max(0, DaysBorrowed - 7);
                return extraDays * 10;
            }
        }

        // Computed: Borrow Duration Category
        public string BorrowDurationCategory
        {
            get
            {
                if (DaysBorrowed <= 7)
                    return "Short-term";
                if (DaysBorrowed <= 14)
                    return "Regular";

                return "Extended";
            }
        }
    }
}
