namespace WAMA.Core.ViewModel
{
    public class AdminConsoleHomeViewModel
    {
        public int NumberOfPatronCheckinsToday { get; set; }
        public int NumberOfNonPatronCheckinsToday { get; set; }
        public int NumberOfPatronsPendingApprobal { get; set; }
        public int NumberOfSuspendedPatrons { get; set; }
        public int NumberOfCertificationsExpiringInTheNextWeek { get; set; }
        public int NumberOfExpiredCertifications { get; set; }
    }
}