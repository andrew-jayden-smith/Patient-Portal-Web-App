namespace PatientPortalWebApp.Models
{
    public class MedicalRecords
    {
        public int Id { get; set; }

        public string PatientID { get; set; }

        public string DoctorID { get; set; }

        public string Medication { get; set; }

        public string Symptoms { get; set; }

    }
}
